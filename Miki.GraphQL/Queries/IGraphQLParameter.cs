using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	public interface IGraphQLParameter : IGraphQLObject
	{
		bool IsConstant { get; }
		bool IsRequired { get; }

		object Value { get; }

		Type ValueType { get; }
	}
}
