using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BookStoreAPI.Controllers.Tests
{
    public class BooksControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BooksControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
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
    }
}