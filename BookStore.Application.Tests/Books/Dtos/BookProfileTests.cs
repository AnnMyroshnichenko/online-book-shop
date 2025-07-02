using AutoMapper;
using BookStore.Application.Books.Commands.CreateBook;
using BookStore.Application.Books.Commands.UpdateBook;
using BookStore.Application.Categories.Dtos;
using BookStore.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace BookStore.Application.Books.Dtos.Tests
{
    public class BookProfileTests
    {
        private readonly IMapper _mapper;

        public BookProfileTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BookProfile>();
            });
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void CreateMap_ForBookToBookDto_MapsCorrectly()
        {
            // Arrange
            var book = new Book
            {
                Id = 1,
                Title = "Test",
                Author = "Test",
                ISBN = "12345",
                Description = "Test",
                Publisher = "Test",
                PublishedDate = new DateTime(2020, 1, 1),
                CoverImageUrl = "Test",
                IsAvailableForSale = true,
                Price = 5.50m,
                Categories = new List<Category> { new Category { Name = "Fantasy" } }
            };

            // Act
            var bookDto = _mapper.Map<BookDto>(book);

            // Assert
            bookDto.Should().NotBeNull();
            bookDto.Id.Should().Be(book.Id);
            bookDto.Title.Should().Be(book.Title);
            bookDto.Author.Should().Be(book.Author);
            bookDto.ISBN.Should().Be(book.ISBN);
            bookDto.Description.Should().Be(book.Description);
            bookDto.Publisher.Should().Be(book.Publisher);
            bookDto.PublishedDate.Should().Be(book.PublishedDate);
            bookDto.CoverImageUrl.Should().Be(book.CoverImageUrl);
            bookDto.IsAvailableForSale.Should().Be(book.IsAvailableForSale);
            bookDto.Price.Should().Be(book.Price);
            bookDto.Categories.Should().NotBeNull();
            bookDto.Categories.Should().HaveCount(1);
            book.Categories.ElementAt(0).Name.Should().Be("Fantasy");
        }

        [Fact]
        public void CreateMap_ForCreateBookCommandToBook_MapsCorrectly()
        {
            // Arrange
            var createBookCommand = new CreateBookCommand
            {
                Id = 1,
                Title = "Test",
                Author = "Test",
                ISBN = "12345",
                Description = "Test",
                Publisher = "Test",
                PublishedDate = new DateTime(2020, 1, 1),
                CoverImageUrl = "Test",
                IsAvailableForSale = true,
                Price = 5.50m,
                Categories = new List<CategoryDto> { new CategoryDto { Name = "Fantasy" } }
            };

            // Act
            var book = _mapper.Map<Book>(createBookCommand);

            // Assert
            book.Should().NotBeNull();
            book.Id.Should().Be(createBookCommand.Id);
            book.Title.Should().Be(createBookCommand.Title);
            book.Author.Should().Be(createBookCommand.Author);
            book.ISBN.Should().Be(createBookCommand.ISBN);
            book.Description.Should().Be(createBookCommand.Description);
            book.Publisher.Should().Be(createBookCommand.Publisher);
            book.PublishedDate.Should().Be(createBookCommand.PublishedDate);
            book.CoverImageUrl.Should().Be(createBookCommand.CoverImageUrl);
            book.IsAvailableForSale.Should().Be(createBookCommand.IsAvailableForSale);
            book.Price.Should().Be(createBookCommand.Price);
            book.Categories.Should().NotBeNull();
            book.Categories.Should().HaveCount(1);
            book.Categories.ElementAt(0).Name.Should().Be("Fantasy");
        }

        [Fact]
        public void CreateMap_ForUpdateBookCommandToBook_MapsCorrectly()
        {
            // Arrange
            var updateBookCommand = new UpdateBookCommand
            {
                Id = 1,
                Title = "Test",
                Author = "Test",
                ISBN = "12345",
                Description = "Test",
                Publisher = "Test",
                PublishedDate = new DateTime(2020, 1, 1),
                CoverImageUrl = "Test",
                IsAvailableForSale = true,
                Price = 5.50m,
                Categories = new List<CategoryDto> { new CategoryDto { Name = "Fantasy" } }
            };

            // Act
            var book = _mapper.Map<Book>(updateBookCommand);

            // Assert
            book.Should().NotBeNull();
            book.Id.Should().Be(updateBookCommand.Id);
            book.Title.Should().Be(updateBookCommand.Title);
            book.Author.Should().Be(updateBookCommand.Author);
            book.ISBN.Should().Be(updateBookCommand.ISBN);
            book.Description.Should().Be(updateBookCommand.Description);
            book.Publisher.Should().Be(updateBookCommand.Publisher);
            book.PublishedDate.Should().Be(updateBookCommand.PublishedDate);
            book.CoverImageUrl.Should().Be(updateBookCommand.CoverImageUrl);
            book.IsAvailableForSale.Should().Be(updateBookCommand.IsAvailableForSale);
            book.Price.Should().Be(updateBookCommand.Price);
            book.Categories.Should().NotBeNull();
            book.Categories.ElementAt(0).Name.Should().Be("Fantasy");
        }
    }
}