using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_vNext_2015_03.Models
{
    public interface IBooksRepository : IDisposable
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<Book> AddBook(Book newBook);
        Task<Book> UpdateBook(Book newBook);
        Task DeleteBook(int id);
    }
}