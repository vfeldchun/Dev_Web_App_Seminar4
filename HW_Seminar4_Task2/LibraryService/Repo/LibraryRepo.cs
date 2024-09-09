using AutoMapper;
using LibraryService.Models;
using LibraryService.Models.Dto;

namespace LibraryService.Repo
{
    public class LibraryRepo : ILibraryRepo
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public LibraryRepo(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddAuthor(AuthorDto author)
        {
            _context.Authors.Add(_mapper.Map<Author>(author));
            _context.SaveChanges();
        }

        public void AddBook(BookDto book)
        {
            _context.Books.Add(_mapper.Map<Book>(book));
            _context.SaveChanges();
        }

        public bool CheckBook(Guid bookId)
        {
            return _context.Books.Any(x => x.Id == bookId);
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            return _context.Authors.Select(_mapper.Map<AuthorDto>).ToList();
        }

        public IEnumerable<BookDto> GetBooks()
        {
            return _context.Books.Select(_mapper.Map<BookDto>).ToList();
        }
    }
}
