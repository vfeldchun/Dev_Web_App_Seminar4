using GraphQl.Client;

namespace GraphQl.Queries
{
    public class QueryDb
    {
        public async Task<string> GetProductsAsync([Service] IDbWebClient dbClient) => await dbClient.GetProductsAsync();
        public async Task<string> GetGroupsAsync([Service] IDbWebClient dbClient) => await dbClient.GetGroupsAsync();        
    }
}
