using LibraryService.Models.Dto;

namespace LibraryService.Repo
{
    public interface ILibraryRepo
    {
        public void AddAuthor(AuthorDto author);
        public void AddBook(BookDto book);
        public IEnumerable<AuthorDto> GetAuthors();
        public IEnumerable<BookDto> GetBooks();
        public bool CheckBook(Guid bookId);
    }
}
