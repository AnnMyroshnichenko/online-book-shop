using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<int> Create(Book book);
        Task Delete(Book book);
        Task SaveChanges();
        Task<(IEnumerable<Book>, int)> GetAllByNameAsync(string? searchPhrase, int pageNumber, int pageSize);
    }
}
