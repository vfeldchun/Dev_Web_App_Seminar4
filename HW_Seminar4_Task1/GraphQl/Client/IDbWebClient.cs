namespace GraphQl.Client
{
    public interface IDbWebClient
    {
        public Task<string> GetProductsAsync();
        public Task<string> GetGroupsAsync();
        public Task AddProductAsync(string name, string descriptions, string groupId);
        public Task AddGroupAsync(string name, string descriptions);
    }
}
