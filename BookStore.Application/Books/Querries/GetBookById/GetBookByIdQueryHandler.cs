using AutoMapper;
using BookStore.Application.Books.Dtos;
using BookStore.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Querries.GetBookById
{
    public class GetBookByIdQueryHandler (ILogger<GetBookByIdQueryHandler> logger,
        IBookRepository bookRepository, IMapper mapper)
        : IRequestHandler<GetBookByIdQuery, BookDto?>
    {
        public async Task<BookDto?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting books {request.Id}");
            var book = await bookRepository.GetByIdAsync(request.Id);
            var bookDto = mapper.Map<BookDto>(book);

            return bookDto;
        }
    }
}
