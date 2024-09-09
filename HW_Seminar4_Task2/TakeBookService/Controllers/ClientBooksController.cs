using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TakeBookService.Client;
using TakeBookService.Models.Dto;
using TakeBookService.Repo;

namespace TakeBookService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientBooksController : ControllerBase
    {
        private IClientBookRepo _repo;

        public ClientBooksController(IClientBookRepo repo)
        {
            _repo = repo;
        }

        //[HttpPost(template: "TakeBook")]
        //public ActionResult TakeBook(ClientBookDto record)
        //{
        //    _repo.TakeBook(record);
        //    return Ok();
        //}

        [HttpPost(template: "TakeBook")]
        public async Task<TakeBookResultDto> TakeBookAsync(ClientBookDto record)
        {
            var userExistsTask = new LibraryUsersClient().Exists(record.ClientId);
            var bookExistsTask = new LibraryBooksClient().Exists(record.BookId);

            var userExists = await userExistsTask;
            var bookExists = await bookExistsTask;

            if (userExists && bookExists)
            {
                try
                {
                    _repo.TakeBook(record);
                    return new TakeBookResultDto { Success = true };
                }
                catch (Exception ex)
                {
                    if (ex is DbUpdateException && ex.InnerException is PostgresException && ex?.InnerException?.Message?.Contains("duplicate") == true)
                    {
                        return new TakeBookResultDto { Error = "This book was taken!" };
                    }
                    throw;
                }
            }
            else
            {
                if (!userExists)
                    return new TakeBookResultDto { Error = "User is not found!" };
                else
                    return new TakeBookResultDto { Error = "The book is not found!" };
            }
        }

        [HttpGet(template: "ReturnBook")]
        public ActionResult ReturnBook(Guid bookId)
        {
            _repo.ReturnBook(bookId);
            return Ok();
        }

        [HttpPost(template: "ListBook")]
        public ActionResult<IEnumerable<Guid>> ListBook(Guid clientId)
        {
            return Ok(_repo.ListBooks(clientId));
        }

    }
}
