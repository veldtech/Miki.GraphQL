using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Miki.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Miki.GraphQL.Queries
{
	internal class GraphQLCompiledQuery : IGraphQLQuery
	{
		public IReadOnlyList<IGraphQLParameter> Parameters { get; }

		private readonly string _rawQuery;
		private readonly GraphQLClient _client;

		internal GraphQLCompiledQuery(GraphQLClient client, string query)
		{
			_client = client;
			_rawQuery = query;
		}

		public async Task<TResult> ExecuteAsync<TResult>(params ValueTuple<string, object>[] parameters)
			=> await _client.QueryAsync<TResult>(_rawQuery, parameters);
	}
}