namespace TakeBookService.Client
{
    public interface ILibraryUsersClient
    {
        public Task<bool> Exists(Guid id);
    }
}
