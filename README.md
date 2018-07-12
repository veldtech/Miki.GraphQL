# Miki.GraphQL
[![](https://img.shields.io/nuget/dt/Miki.GraphQL.svg?style=for-the-badge)](https://www.nuget.org/packages/Miki.GraphQL)
[![](https://img.shields.io/discord/259343729586864139.svg?style=for-the-badge&logo=discord)](https://discord.gg/XpG4kwE)

GraphQL client

> Install-Package Miki.GraphQL

## Usage
```cs
// Create an instance of your client
GraphQLClient graph = new GraphQLClient("https://your-endpoint.website/");

// Prepare your query
var query = "query($p0 :Int) { User(id: $p0) { name, object { something_needed } } }";

// Query to your endpoint
await graph.QueryAsync<User>(query, 22);
```
