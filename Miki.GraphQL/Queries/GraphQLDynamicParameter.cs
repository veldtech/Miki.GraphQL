using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	internal class GraphQLDynamicParameter : IGraphQLParameter
	{
		public bool IsConstant => false;

		public bool IsRequired { get; }

		public string Name { get; }

		public object Value { get; }

		public Type ValueType { get; }

		public GraphQLDynamicParameter(string name, Type type, bool required = false)
		{
			Name = name;
			Value = "$" + name;
			ValueType = type;
			IsRequired = required;
		}
	}
}
