using AutoMapper;
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
    internal class UpdateBookCommandHandler (ILogger<UpdateBookCommandHandler> logger,
        IBookRepository bookRepository, IMapper mapper)
        : IRequestHandler<UpdateBookCommand, bool>
    {
        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating book with id: {request.Id}");
            var book = await bookRepository.GetByIdAsync(request.Id);
            if (book == null)
            {
                return false;
            } 
            
            mapper.Map(request, book);

            await bookRepository.SaveChanges();
            return true;
        }
    }
}
