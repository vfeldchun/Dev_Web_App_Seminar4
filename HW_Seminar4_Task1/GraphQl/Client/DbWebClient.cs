
namespace GraphQl.Client
{
    public class DbWebClient : IDbWebClient
    {
        readonly HttpClient _httpClient = new HttpClient(); 

        public async Task<string> GetProductsAsync()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"http://localhost:8095/Products/getproducts");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> GetGroupsAsync()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"http://localhost:8095/ProductGroup/getgroups");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task AddGroupAsync(string name, string description)
        {
            var content = new StringContent("text/json");
            using HttpResponseMessage response = await _httpClient.PostAsync($"http://localhost:8095/ProductGroup/addgroup?name={name}&description={description}", content);
            response.EnsureSuccessStatusCode();            
        }

        public async Task AddProductAsync(string name, string description, string groupId)
        {
            var content = new StringContent("text/json");
            using HttpResponseMessage response = await _httpClient.PostAsync($"http://localhost:8095/Products/addproduct?name={name}&description={description}&groupId={groupId}", content);
            response.EnsureSuccessStatusCode();
        }        
    }
}
