using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	internal class GraphQLQueryObject : IGraphQLObject
	{
		public string Name { get; }

		internal GraphQLQueryObject(string key)
		{
			Name = key;
		}
	}
}
