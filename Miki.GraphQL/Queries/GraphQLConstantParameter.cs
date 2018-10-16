using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	class GraphQLConstantParameter : IGraphQLParameter
	{
		public bool IsConstant => true;

		public bool IsRequired => false;

		public object Value { get; }

		public Type ValueType { get; }

		public string Name { get; }

		public GraphQLConstantParameter(string name, object value)
		{
			Name = name;
			Value = value;
			ValueType = value.GetType();
		}
	}
}
