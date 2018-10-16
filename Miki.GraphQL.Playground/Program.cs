using Miki.GraphQL.Queries;
using Miki.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.GraphQL.Playground
{
	public struct User
	{
		public string id;
		public string firstName;
	}

	public class UserCollection
	{
		public List<User> allUsers;
	}

	class Program
	{
		static void  Main(string[] args)
		{
			GraphQLClient client = new GraphQLClient("https://fakerql.com/graphql");

			IGraphQLQuery query = client.CreateQuery()
				.WithType("allUsers", 
					x => x.WithDynamicParameter<long>("count")
						.WithObject("id")
						.WithObject("firstName")
				)
				.Compile();

			var users = query.ExecuteAsync<UserCollection>(("count", 5)).Result;

			Console.WriteLine(string.Join(",", users.allUsers.Select(x => x.firstName)));
			Console.Read();
		}
	}
}
