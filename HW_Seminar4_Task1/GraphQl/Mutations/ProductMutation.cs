
using GraphQl.Client;

namespace GraphQl.Mutations
{
    public class ProductMutation
    {
        public async Task<bool> AddProductAsync([Service] IDbWebClient dbClient, string name, string description, string groupId)
        {
            await dbClient.AddProductAsync(name, description, groupId);
            return true;
        }

        public async Task<bool> AddGroupAsync([Service] IDbWebClient dbClient, string name, string description)
        {
            await dbClient.AddGroupAsync(name, description);
            return true;
        }        
    }
}
