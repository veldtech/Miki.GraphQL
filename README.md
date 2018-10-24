# Miki.GraphQL
[![](https://img.shields.io/nuget/dt/Miki.GraphQL.svg?style=for-the-badge)](https://www.nuget.org/packages/Miki.GraphQL)
[![](https://img.shields.io/discord/259343729586864139.svg?style=for-the-badge&logo=discord)](https://discord.gg/XpG4kwE)

GraphQL client

## Install
Install directly from NuGet
> Install-Package Miki.GraphQL

## Usage

### Basic usage
For simple usage, you can use `QueryAsync`
```cs
// Create an instance of your client
GraphQLClient graph = new GraphQLClient("https://your-endpoint.website/");

// Prepare your query
var query = "query($p0 :Int) { User(id: $p0) { name, object { something_needed } } }";

// Query to your endpoint
await graph.QueryAsync<User>(query, 22);
```

### Query builders
Use `graph.CreateQuery` for easy reusable queries.
```cs
// Create an instance of your client
GraphQLClient graph = new GraphQLClient("https://your-endpoint.website/");

// Prepare your query
var query = graph.CreateQuery()
  .WithSchema<User>()
  .WithDynamicParameter("id")
  .Compile();

// Query to your endpoint
await query.ExecuteAsync<User>("id", 22);
