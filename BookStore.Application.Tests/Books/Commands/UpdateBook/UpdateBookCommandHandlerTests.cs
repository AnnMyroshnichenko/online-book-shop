using AutoMapper;
using Azure.Core;
using BookStore.Domain.Entities;
using BookStore.Domain.Exceptions;
using BookStore.Domain.Repositories;
using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Application.Books.Commands.UpdateBook.Tests
{
    public class UpdateBookCommandHandlerTests
    {
        private readonly Mock<ILogger<UpdateBookCommandHandler>> _logger;
        private readonly Mock<IBookRepository> _bookRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly UpdateBookCommandHandler _handler;

        public UpdateBookCommandHandlerTests()
        {
            _logger = new Mock<ILogger<UpdateBookCommandHandler>>();
            _mapper = new Mock<IMapper>();
            _bookRepository = new Mock<IBookRepository>();

            _handler = new UpdateBookCommandHandler(
                _logger.Object,
               _bookRepository.Object,
               _mapper.Object);
        }

        [Fact()]
        public async Task Handle_WithValidRequest_ShouldUpdateBooks()
        {
            // arrange
            var bookId = 1;
            var command = new UpdateBookCommand()
            {
                Id = bookId,
                Title = "Test",
                Author = "Test",
                ISBN = "12345",
                Description = "Test",
                Publisher = "Test",
                PublishedDate = new DateTime(2020, 1, 1),
                CoverImageUrl = "Test",
                IsAvailableForSale = true,
                Price = 5.50m
            };

            var book = new Book()
            {
                Id = bookId,
                Title = "Test",
                Author = "Test",
                ISBN = "12345",
                Description = "Test",
                Publisher = "Test",
                PublishedDate = new DateTime(2020, 1, 1),
                CoverImageUrl = "Test",
                IsAvailableForSale = true,
                Price = 5.50m
            };

            _bookRepository.Setup(x => x.GetByIdAsync(bookId))
                .ReturnsAsync(book);

            // act
            await _handler.Handle(command, CancellationToken.None);

            // assert
            _bookRepository.Verify(x => x.SaveChanges(), Times.Once);
            _mapper.Verify(x => x.Map(command, book), Times.Once);
        }

        [Fact()]
        public async Task Handle_WithNonExistingBook_ShouldThrowNotFoundException()
        {
            // arrange
            var bookId = 2;
            var command = new UpdateBookCommand()
            {
                Id = bookId,

            };

            _bookRepository.Setup(x => x.GetByIdAsync(bookId))
                .ReturnsAsync((Book?)null);

            // act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // assert
            await act.Should().ThrowAsync<NotFoundException>()
                .WithMessage($"Book with id {bookId} doesn't exist");
        }
    }
}