using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Queries
{
	public interface ITypeBuilder : IObjectBuilder<ITypeBuilder>
	{
		IReadOnlyList<IGraphQLParameter> Parameters { get; }

		ITypeBuilder WithDynamicParameter<T>(string key, bool required = false);
		ITypeBuilder WithConstantParameter<T>(string key, T value);

		IGraphQLType ToType();
	}
}
