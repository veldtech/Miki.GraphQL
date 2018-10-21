using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class GraphQLSchemaAttribute : Attribute
	{
		public string Name { get; }

		public GraphQLSchemaAttribute() { }
		public GraphQLSchemaAttribute(string name)
		{
			Name = name;
		}
	}
}
