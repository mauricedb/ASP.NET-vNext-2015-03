using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ASP.NET_vNext_2015_03.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;

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
                if (ModelState.IsValid)
                {
                    var book = await _repo.AddBook(newBook);

                    CreatedAtRoute("GetByIdRoute", new {id = book.Id});
                }
                else
                {
                    HttpBadRequest(ModelState);
                }
            }
            catch (ValidationException ex)
            {
                HttpBadRequest(new { ex.Message });
            }
        }

        public async Task Put(int id, Book newBook)
        {
            try
            {
                if (newBook.Id != id)
                {
                    throw new ValidationException("Invalid book ID.");
                }
                if (ModelState.IsValid)
                {
                    await _repo.UpdateBook(newBook);
                }
                else
                {
                    HttpBadRequest(ModelState);
                }
            }
            catch (ValidationException ex)
            {
                HttpBadRequest(new { ex.Message });
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _repo.DeleteBook(id);

                Response.StatusCode = (int)HttpStatusCode.NoContent;
            }
            catch (ValidationException ex)
            {
                HttpBadRequest(new { ex.Message });
            }
        }
    }
}