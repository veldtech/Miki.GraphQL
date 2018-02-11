# Miki.GraphQL
GraphQL client

## Usage
```cs
// Create an instance of your client
GraphQLClient graph = new GraphQLClient("https://your-endpoint.website/");

// Prepare your query
var query = "query($p0 :Int) { User(id: $p0) { name, object { something_needed } } }";

// Query to your endpoint
await graph.QueryAsync<User>(query, 22);
```
