using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class GraphQLFieldAttribute : Attribute
	{
		public string Name { get; }
		public bool IsRequired { get; }

		public GraphQLFieldAttribute(string name, bool required = false)
		{
			Name = name;
			IsRequired = required;
		}
	}
}
