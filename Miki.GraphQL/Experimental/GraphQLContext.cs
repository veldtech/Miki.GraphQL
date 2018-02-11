using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Experimental
{
    public class GraphQLContext
    {
		public GraphQLContext()
		{
		}

		public static GraphQLContext Create<T>() where T : GraphQLContext, new()
		{
			T t = new T();

			// TODO: initialize

			return t;
		}
    }
}
