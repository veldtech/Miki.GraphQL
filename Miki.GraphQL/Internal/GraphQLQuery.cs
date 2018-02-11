using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL.Internal
{
	internal class GraphQLQuery<T>
	{
		[JsonProperty("data")]
		internal T Data = default(T);
	}
}
