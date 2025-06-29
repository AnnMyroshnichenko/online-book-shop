using AutoMapper;
using BookStore.Application.Books.Dtos;
using BookStore.Application.Books.Querries.GetBooks;
using BookStore.Application.Common;
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
        : IRequestHandler<GetAllBooksQuery, PageResult<BookDto>>
    {
        public async Task<PageResult<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all books");
            
            var (books, totalCount) = await bookRepository.GetAllByNameAsync(request.SearchPhrase,
                request.PageNumber,
                request.PageSize);
            var booksDtos = mapper.Map<IEnumerable<BookDto>>(books);
            var result = new PageResult<BookDto>(booksDtos, totalCount, request.PageSize, request.PageNumber);
            return result;
        }
    }
}
