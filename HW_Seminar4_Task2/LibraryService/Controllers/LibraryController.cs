using LibraryService.Models.Dto;
using LibraryService.Repo;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private ILibraryRepo _library;

        public LibraryController(ILibraryRepo library)
        {
            _library = library;
        }

        [HttpPost(template: "AddAuthor")]
        public ActionResult AddAuthor(AuthorDto author)
        {
            _library.AddAuthor(author);
            return Ok();
        }

        [HttpGet(template: "GetAuthors")]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            return Ok(_library.GetAuthors());
        }

        [HttpPost(template: "AddBook")]
        public ActionResult AddBook(BookDto book)
        {
            _library.AddBook(book);
            return Ok();
        }

        [HttpGet(template: "GetBooks")]
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            return Ok(_library.GetBooks());
        }

        [HttpGet(template: "CheckBook")]
        public ActionResult<bool> CheckBook(Guid bookId)
        {
            return Ok(_library.CheckBook(bookId));
        }
    }
}
