using BookStore.Application.Books.Dtos;
using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using System.Net.Http.Json;
using Xunit;

namespace BookStoreAPI.Controllers.Tests
{
    public class BooksControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<IBookRepository> _bookRepositoryMock = new();

        public BooksControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.Replace(ServiceDescriptor.Scoped(typeof(IBookRepository),
                        _ => _bookRepositoryMock.Object));
                });
            });   
        }

        [Fact()]
        public async Task GetAll_ForValidrequest_Returns200Ok()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var result = await client.GetAsync("/api/books?pageNumber=1&pageSize=10");

            // assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact()]
        public async Task GetAll_ForInValidrequest_Returns400BadRequest()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var result = await client.GetAsync("/api/books");

            // assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact()]
        public async Task GetById_ForNonExistingId_Returns404NotFound()
        {
            // arrange
            var id = 123123;

            _bookRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Book?)null);
            
            var client = _factory.CreateClient();

            // act
            var result = await client.GetAsync($"/api/books/{id}");

            // assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact()]
        public async Task GetById_ForExistingId_Returns200Ok()
        {
            // arrange
            var id = 1;

            var book = new Book
            {
                Id = 1,
                Title = "Test",
                Author = "Test",
                ISBN = "12345",
                Description = "Test",
                Publisher = "Test",
                IsAvailableForSale = true,
                Price = 5.50m,
                Categories = new List<Category> { new Category { Name = "Fantasy" } }
            };

            _bookRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(book);

            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync($"/api/books/{id}");
            var bookDto = await response.Content.ReadFromJsonAsync<BookDto>();

            // assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            bookDto.Should().NotBeNull();
            bookDto.Title.Should().Be("Test");
            bookDto.Author.Should().Be("Test");
            bookDto.ISBN.Should().Be("12345");
        }
    }
}