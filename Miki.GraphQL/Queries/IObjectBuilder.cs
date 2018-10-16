using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	public interface IObjectBuilder<T>
	{
		IReadOnlyList<IGraphQLObject> Types { get; }

		T WithObject(string key);

		T WithType(IGraphQLType type);
		T WithType(string key, Func<ITypeBuilder, ITypeBuilder> predicate);
	}
}
