using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL
{
	public class GraphQLParameter
	{
		public object Value { get; internal set; }

		public string ParamType { get; internal set; }

		public GraphQLParameter(object value, string type = "String")
		{
			Value = value;
			ParamType = type;
		}
	}
}
