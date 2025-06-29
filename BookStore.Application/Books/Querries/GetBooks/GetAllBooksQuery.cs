using BookStore.Application.Books.Dtos;
using BookStore.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Querries.GetBooks
{
    public class GetAllBooksQuery : IRequest<PageResult<BookDto>>
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 12;
    }
}
