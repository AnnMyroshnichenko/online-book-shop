using AutoMapper;
using BookStore.Domain.Entities;
using BookStore.Domain.Exceptions;
using BookStore.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler (ILogger<UpdateBookCommandHandler> logger,
        IBookRepository bookRepository, IMapper mapper)
        : IRequestHandler<UpdateBookCommand>
    {
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating book with id: {request.Id}");
            var book = await bookRepository.GetByIdAsync(request.Id);
            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id.ToString());
            } 
            
            mapper.Map(request, book);

            await bookRepository.SaveChanges();
        }
    }
}
