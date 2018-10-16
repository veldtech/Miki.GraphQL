using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Miki.Rest;
using System.Reflection;
using System.Threading.Tasks;
using Miki.Net.Http;
using Miki.GraphQL.Queries;

namespace Miki.GraphQL
{
    public class GraphQLClient
    {
		HttpClient restClient;

		public GraphQLClient(string url)
		{
			restClient = new HttpClient(url);
		}

		/// <summary>
		/// Query the endpoint with a raw function and receive the json response, for parameters use $p0, $p1... to access your variables
		/// </summary>
		/// <param name="query">GraphQL query</param>
		/// <param name="variables">Variables used in query</param>
		/// <returns>Json response</returns>
		public async Task<string> QueryAsync(string query, params object[] variables)
			=> await InternalQueryAsync(CreateQueryJson(query, variables));

		/// <summary>
		/// Query the endpoint with a raw function, for parameters use $p0, $p1... to access your variables
		/// </summary>
		/// <typeparam name="T">The output object serialized to</typeparam>
		/// <param name="query">GraphQL query</param>
		/// <param name="variables">Variables used in query</param>
		/// <returns>Object of type T converted</returns>
		public async Task<T> QueryAsync<T>(string query, params object[] variables)
			=> await InternalQueryAsync<T>(CreateQueryJson(query, variables));

		/// <summary>
		/// Query the endpoint with a raw function and receive the json response, for parameters use $p0, $p1... to access your variables
		/// </summary>
		/// <param name="query">GraphQL query</param>
		/// <param name="variables">Variables used in query</param>
		/// <returns>Json response</returns>
		public async Task<string> QueryAsync(string query, params ValueTuple<string,object>[] variables)
			=> await InternalQueryAsync(CreateQueryJson(query, variables));

		/// <summary>
		/// Query the endpoint with a raw function, for parameters use $p0, $p1... to access your variables
		/// </summary>
		/// <typeparam name="T">The output object serialized to</typeparam>
		/// <param name="query">GraphQL query</param>
		/// <param name="variables">Variables used in query</param>
		/// <returns>Object of type T converted</returns>
		public async Task<T> QueryAsync<T>(string query, params ValueTuple<string, object>[] variables)
			=> await InternalQueryAsync<T>(CreateQueryJson(query, variables));

		/// <summary>
		/// Query GraphQL string and receive json
		/// </summary>
		/// <param name="query">GraphQL query</param>
		/// <returns>Json response</returns>
		internal async Task<string> InternalQueryAsync(string query)
			=> (await restClient.PostAsync("", query)).Body;

		/// <summary>
		/// Query GraphQL string and receive serialized object
		/// </summary>
		/// <param name="query">GraphQL query</param>
		/// <returns>Response of type T</returns>
		internal async Task<T> InternalQueryAsync<T>(string query)
		{
			HttpResponse<GraphQLQuery<T>> response = await restClient.PostAsync<GraphQLQuery<T>>("", query);
			if (response.Success)
			{
				return response.Data.Data;
			}
			return default(T);
		}

		/// <summary>
		/// Utility function to create queries for post messages
		/// </summary>
		/// <param name="query">base query</param>
		/// <param name="variables">variables from query</param>
		/// <returns>postable query</returns>
		string CreateQueryJson(string query, params object[] variables)
		{
			Dictionary<string, object> allVariables = new Dictionary<string, object>();

			for (int i = 0; i < variables.Length; i++)
			{
				allVariables.Add($"p{i}", variables[i]);
			}

			return CreateQueryJson(query, allVariables);
		}

		/// <summary>
		/// Utility function to create queries for post messages
		/// </summary>
		/// <param name="query">base query</param>
		/// <param name="variables">variables from query</param>
		/// <returns>postable query</returns>
		string CreateQueryJson(string query, params ValueTuple<string, object>[] variables)
		{
			Dictionary<string, object> allVariables = new Dictionary<string, object>();

			for (int i = 0; i < variables.Length; i++)
			{
				allVariables.Add(variables[i].Item1, variables[i].Item2);
			}

			return CreateQueryJson(query, allVariables);
		}

		/// <summary>
		/// Utility function to create queries for post messages
		/// </summary>
		/// <param name="query">base query</param>
		/// <param name="variables">variables from query</param>
		/// <returns>postable query</returns>
		string CreateQueryJson(string query, Dictionary<string, object> variables)
		{
			string serializedVariables = JsonConvert.SerializeObject(variables);
			return FormatQueryString(query, serializedVariables);
		}

		/// <summary>
		/// Formats the query in a GraphQL-like json structure
		/// </summary>
		/// <param name="query">query string</param>
		/// <param name="variables">variable string</param>
		/// <returns>GraphQL-formatted json</returns>
		string FormatQueryString(string query, string variables)
			=> $"{{ \"query\": \"{query}\", \"variables\": {variables} }}";
	}
}
