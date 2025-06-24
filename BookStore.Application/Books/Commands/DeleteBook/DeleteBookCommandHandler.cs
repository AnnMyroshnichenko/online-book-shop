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

namespace BookStore.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler (ILogger<DeleteBookCommandHandler> logger,
        IBookRepository bookRepository)
        : IRequestHandler<DeleteBookCommand>
    {
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting book with id: {request.Id}");
            var book = await bookRepository.GetByIdAsync(request.Id);  
            if( book == null )
            {
                throw new NotFoundException(nameof(Book), request.Id.ToString());
            }

            await bookRepository.Delete(book);
        }
    }
}
