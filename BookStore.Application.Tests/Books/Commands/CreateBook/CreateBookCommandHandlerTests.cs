using Xunit;
using BookStore.Application.Books.Commands.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Castle.Core.Logging;
using AutoMapper;
using Microsoft.Extensions.Logging;
using BookStore.Domain.Repositories;
using BookStore.Domain.Entities;
using BookStore.Application.Users;
using FluentAssertions;

namespace BookStore.Application.Books.Commands.CreateBook.Tests
{
    public class CreateBookCommandHandlerTests
    {
        [Fact()]
        public async Task Handle_ForValidCommand_ReturnCreatedBook()
        {
            // arrange
            var loggerMock = new Mock<ILogger<CreateBookCommandHandler>>();
            var mapperMock = new Mock<IMapper>();
            var command = new CreateBookCommand();
            var book = new Book();
            mapperMock.Setup(m => m.Map<Book>(command)).Returns(book);

            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(repo => repo.Create(It.IsAny<Book>()))
                .ReturnsAsync(1);

            var commandHandler = new CreateBookCommandHandler(loggerMock.Object,
                bookRepositoryMock.Object,
                mapperMock.Object);

            // act
            var result  = await commandHandler.Handle(command, CancellationToken.None);

            // asssrt
            result.Should().Be(1);
            bookRepositoryMock.Verify(x => x.Create(book), Times.Once);
        }
    }
}