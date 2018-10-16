using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	internal class GraphQLQueryType : IGraphQLType
	{
		public IReadOnlyList<IGraphQLParameter> Parameters { get; }

		public IReadOnlyList<IGraphQLObject> Types { get; }

		public string Name { get; }

		public GraphQLQueryType(string name, List<IGraphQLParameter> parameters, List<IGraphQLObject> objects)
		{
			Name = name;
			Parameters = parameters;
			Types = objects;
		}
	}
}
