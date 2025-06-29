using AutoMapper;
using BookStore.Application.Books.Dtos;
using BookStore.Application.Books.Querries.GetRestaurants;
using BookStore.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Querries.GetBooks
{
    public class GetAllBooksQueryHandler (ILogger<GetAllBooksQueryHandler> logger,
        IMapper mapper, IBookRepository bookRepository)
        : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all books");
            var books = await bookRepository.GetAllByNameAsync(request.SearchPhrase);
            var booksDtos = mapper.Map<IEnumerable<BookDto>>(books);
            return booksDtos!;
        }
    }
}
