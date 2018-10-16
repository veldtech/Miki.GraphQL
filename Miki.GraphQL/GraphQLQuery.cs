using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.GraphQL
{
	internal class GraphQLQuery<T>
	{
		[JsonProperty("data")]
		internal T Data = default(T);
	}
}
