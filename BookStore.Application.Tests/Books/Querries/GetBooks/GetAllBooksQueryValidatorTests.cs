using BookStore.Application.Books.Commands.CreateBook;
using BookStore.Application.Books.Querries.GetBooks;
using BookStore.Application.Categories.Dtos;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Application.Books.Querries.GetBooks.Tests
{
    public class GetAllBooksQueryValidatorTests
    {
        [Theory()]
        [InlineData(1, 5)]
        [InlineData(2, 15)]
        [InlineData(1, 10)]
        public void Validator_ForValidQuery_ShouldNotHaveValidationErrors(int pageNumber, int pageSize)
        {
            // arrange
            var query = new GetAllBooksQuery()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var validator = new GetAllBooksQueryValidator();

            // act
            var result = validator.TestValidate(query);

            // assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory()]
        [InlineData(-1, 0)]
        [InlineData(-10, 10000)]
        [InlineData(0, -20)]
        public void Validator_ForInvalidQuery_ShouldHaveValidationErrors(int pageNumber, int pageSize)
        {
            // arrange
            var query = new GetAllBooksQuery()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var validator = new GetAllBooksQueryValidator();

            // act
            var result = validator.TestValidate(query);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.PageNumber);
            result.ShouldHaveValidationErrorFor(x => x.PageSize);
        }

        [Theory()]
        [InlineData(5)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(15)]
        [InlineData(30)]
        public void Validator_ForValidPageSize_ShouldNotHaveValidationErrorsForCategoryProperty(int pageSize)
        {
            // arrange
            var query = new GetAllBooksQuery()
            {
                PageNumber = 1,
                PageSize = pageSize
            };

            var validator = new GetAllBooksQueryValidator();

            // act
            var result = validator.TestValidate(query);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.PageSize);
        }
    }
}