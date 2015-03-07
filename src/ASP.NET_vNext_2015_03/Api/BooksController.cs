using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ASP.NET_vNext_2015_03.Models;
using Microsoft.AspNet.Mvc;

namespace ASP.NET_vNext_2015_03.Api
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private IBooksRepository _repo;

        public BooksController(IBooksRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public Task<IEnumerable<Book>> Get()
        {
            return _repo.GetBooks();
        }

        [HttpGet("{id}", Name = "GetByIdRoute")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _repo.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(book);
        }


        // POST api/books
        public async Task Post(Book newBook)
        {
            try
            {
                var book = await _repo.AddBook(newBook);

                CreatedAtRoute("GetByIdRoute", new { id = book.Id });
            }
            catch (ValidationException ex)
            {
                HttpBadRequest(new { ex.Message });
            }
        }

    }
}