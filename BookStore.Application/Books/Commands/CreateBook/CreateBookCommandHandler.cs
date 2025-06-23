using AutoMapper;
using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler(ILogger <CreateBookCommandHandler> logger,
        IBookRepository bookRepository, IMapper mapper) : IRequestHandler<CreateBookCommand, int>
    {
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new book");
            var book = mapper.Map<Book>(request);
            int id = await bookRepository.Create(book);
            return id;
        }
    }
}
