using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miki.GraphQL.Queries
{
	public class GraphQLQueryBuilder : IQueryBuilder
	{
		public IReadOnlyList<IGraphQLObject> Types => _types;

		private readonly GraphQLClient _client;

		private List<IGraphQLObject> _types = new List<IGraphQLObject>();

		public GraphQLQueryBuilder(GraphQLClient client)
		{
			_client = client;
		}

		public IGraphQLQuery Compile()
		{
			List<IGraphQLParameter> parameters = new List<IGraphQLParameter>();

			foreach(var o in Types)
			{
				FetchDynamicParameters(o, parameters);	
			}

			string query = GraphQLQuerySerializer.Serialize(this, parameters);

			return new GraphQLCompiledQuery(_client, query);
		}

		public IQueryBuilder WithObject(string key)
		{
			_types.Add(new GraphQLQueryObject(key));
			return this;
		}

		public IQueryBuilder WithType(IGraphQLType type)
		{
			_types.Add(type);
			return this;
		}
		public IQueryBuilder WithType(string key, Func<ITypeBuilder, ITypeBuilder> predicate)
		{
			ITypeBuilder builder = predicate(new GraphQLQueryTypeBuilder(key));

			if (builder.Types.Count == 0 && builder.Parameters.Count == 0)
			{
				return WithObject(key);
			}
			return WithType(builder.ToType());
		}

		private void FetchDynamicParameters(IGraphQLObject o, List<IGraphQLParameter> parameters)
		{
			if(o is IGraphQLType type)
			{
				parameters.AddRange(type.Parameters.Where(x => !x.IsConstant));
				foreach(var t in type.Types)
				{
					FetchDynamicParameters(t, parameters);
				}
			}
		}
	}
}