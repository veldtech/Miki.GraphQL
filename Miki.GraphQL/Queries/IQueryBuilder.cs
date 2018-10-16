using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	public interface IQueryBuilder : IObjectBuilder<IQueryBuilder>
	{
		IGraphQLQuery Compile();
	}
}
