namespace TakeBookService.Client
{
    public class LibraryBooksClient : ILibraryBooksClient
    {
        readonly HttpClient _client = new HttpClient();

        public async Task<bool> Exists(Guid id)
        {
            using HttpResponseMessage response = await _client.GetAsync($"https://libhost:8097/Library/CheckBook?bookId={id.ToString()}");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody == "true")
                return true;

            if (responseBody == "false")
                return false;

            throw new Exception("Unknown rsponse");

        }
    }
}
