using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL
{
	public class GraphQLParameter
	{
		public string Key { get; internal set; }
		public object Value { get; internal set; }

		Type type;

		public GraphQLParameter(string key, object value)
		{
			Key = key;
			Value = value;

			type = value.GetType();
		}
	}
}
