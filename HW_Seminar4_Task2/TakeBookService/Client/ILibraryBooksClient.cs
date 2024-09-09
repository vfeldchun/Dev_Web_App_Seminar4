namespace TakeBookService.Client
{
    public interface ILibraryBooksClient
    {
        public Task<bool> Exists(Guid id);
    }
}
