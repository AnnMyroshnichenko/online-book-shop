using BookStore.Application.Books.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Querries.GetRestaurants
{
    public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
    {
        public string? SearchPhrase { get; set; }
    }
}
