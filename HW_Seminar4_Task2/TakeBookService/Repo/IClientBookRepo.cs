using TakeBookService.Models.Dto;

namespace TakeBookService.Repo
{
    public interface IClientBookRepo
    {
        public void TakeBook(ClientBookDto record);
        public void ReturnBook(Guid bookId);
        public IEnumerable<Guid?> ListBooks(Guid clientId);
    }
}
