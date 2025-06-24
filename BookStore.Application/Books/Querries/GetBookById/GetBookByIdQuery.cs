using BookStore.Application.Books.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Querries.GetBookById
{
    public class GetBookByIdQuery(int id) : IRequest<BookDto>
    {
        public int Id { get;} = id;
    }
}
