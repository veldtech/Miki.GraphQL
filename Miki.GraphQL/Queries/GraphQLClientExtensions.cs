using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	public static class GraphQLClientExtensions
	{
		public static IQueryBuilder CreateQuery(this GraphQLClient client)
			=> new GraphQLQueryBuilder(client);
	}
}
