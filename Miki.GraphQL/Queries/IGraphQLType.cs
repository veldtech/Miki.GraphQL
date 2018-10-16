using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	public interface IGraphQLType : IGraphQLObject
	{
		IReadOnlyList<IGraphQLParameter> Parameters { get; }
		IReadOnlyList<IGraphQLObject> Types { get; }
	}
}
