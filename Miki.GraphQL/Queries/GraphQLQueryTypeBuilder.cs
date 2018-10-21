using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	public class GraphQLQueryTypeBuilder : ITypeBuilder
	{
		public IReadOnlyList<IGraphQLObject> Types => _types;

		public IReadOnlyList<IGraphQLParameter> Parameters => _parameters;

		private readonly string _key;

		private readonly List<IGraphQLParameter> _parameters;

		private readonly List<IGraphQLObject> _types;

		public GraphQLQueryTypeBuilder(string key)
		{
			_key = key;
			_parameters = new List<IGraphQLParameter>();
			_types = new List<IGraphQLObject>();
		}

		public IGraphQLType ToType()
		{
			return new GraphQLQueryType(_key, _parameters, _types);
		}

		public ITypeBuilder WithConstantParameter<T>(string key, T value)
		{
			_parameters.Add(new GraphQLConstantParameter(key, value));
			return this;
		}

		public ITypeBuilder WithDynamicParameter<T>(string key, bool required = false)
		{
			_parameters.Add(new GraphQLDynamicParameter(key, typeof(T), required));
			return this;
		}

		public ITypeBuilder WithObject(string key)
		{
			_types.Add(new GraphQLQueryObject(key));
			return this;
		}

		public ITypeBuilder WithType(IGraphQLType type)
		{
			_types.Add(type);
			return this;
		}

		public ITypeBuilder WithType(string key, Func<ITypeBuilder, ITypeBuilder> predicate)
		{
			var graphQLTypeBuilder = new GraphQLQueryTypeBuilder(key);
			ITypeBuilder builder = predicate(graphQLTypeBuilder);

			if (builder.Types.Count == 0 && builder.Parameters.Count == 0)
			{
				return WithObject(key);
			}
			return WithType(builder.ToType());
		}
	}
}
