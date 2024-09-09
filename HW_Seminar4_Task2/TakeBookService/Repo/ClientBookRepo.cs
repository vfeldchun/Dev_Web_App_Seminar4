using AutoMapper;
using TakeBookService.Models;
using TakeBookService.Models.Dto;

namespace TakeBookService.Repo
{
    public class ClientBookRepo : IClientBookRepo
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public ClientBookRepo(IMapper mapper, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<Guid?> ListBooks(Guid clientId)
        {
            using (_context)
            {
                return _context.ClientBooks.Where(x => x.ClientId == clientId).Select(x => x.BookId).ToList();
            }
        }

        public void ReturnBook(Guid bookId)
        {
            using (_context)
            {
                var book = _context.ClientBooks.First(x => x.BookId == bookId);

                _context.ClientBooks.Remove(book);
                _context.SaveChanges();
            }
        }

        public void TakeBook(ClientBookDto record)
        {
            using (_context)
            {
                _context.Add(_mapper.Map<ClientBook>(record));
                _context.SaveChanges();
            }
        }
    }
}
