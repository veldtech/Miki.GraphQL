using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Miki.GraphQL.Queries
{
	public interface IGraphQLQuery
	{
		IReadOnlyList<IGraphQLParameter> Parameters { get; }

		Task<TResult> ExecuteAsync<TResult>(params ValueTuple<string, object>[] parameters);
	}
}