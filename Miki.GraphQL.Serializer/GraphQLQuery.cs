using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;

namespace Miki.GraphQL.Experimental
{
	public interface IGraphQLQuery<TResult>
	{
		IReadOnlyDictionary<string, object> Parameters { get; }

		TResult Execute();
	}
	
	public interface IGraphQLQueryBuilder
	{
		IGraphQLQueryBuilder WithType(Func<IGraphQLTypeBuilder, IGraphQLTypeBuilder> predicate);
	}

	public interface IGraphQLTypeBuilder : IGraphQLQueryBuilder
	{
		IGraphQLTypeBuilder WithDynamicParameter<T>(string key, T value);
	}

	public class GraphQLQueryBuilder
	{
		public GraphQLQueryBuilder(HttpClient client)
		{

		}

		public GraphQLQueryBuilder WithType(Func<GraphQLQueryTypeBuilder, GraphQLQueryTypeBuilder> predicate)
		{

			return this;
		}
	}

	public class GraphQLQueryTypeBuilder
	{

	}
}
