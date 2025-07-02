using BookStore.Application.Categories.Dtos;
using FluentValidation.TestHelper;
using Xunit;

namespace BookStore.Application.Books.Commands.CreateBook.Tests
{
    public class CreateBookCommandValidatorTests
    {
        [Fact()]
        public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
        {
            // arrange
            var command = new CreateBookCommand()
            {
                Categories = new List<CategoryDto>
                {
                    new CategoryDto() {
                        Id = 1,
                        Name = "Science Fiction"
                    }
                },
                PublishedDate = new DateTime(2000, 10, 14),
                Price = 20
            };

            var validator = new CreateBookCommandValidator();

            // act
            var result = validator.TestValidate(command);

            // assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void Validator_ForInvalidCommand_ShouldHaveValidationErrors()
        {
            // arrange
            var command = new CreateBookCommand()
            {
                Categories = new List<CategoryDto>
                {
                    new CategoryDto() {
                        Id = 1,
                        Name = "Invalid category"
                    }
                },
                PublishedDate = new DateTime(2050, 10, 14),
                Price = -60
            };

            var validator = new CreateBookCommandValidator();

            // act
            var result = validator.TestValidate(command);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.Categories);
            result.ShouldHaveValidationErrorFor(x => x.PublishedDate);
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Theory()]
        [InlineData("Fantasy")]
        [InlineData("Science Fiction")]
        [InlineData("Thriller")]
        [InlineData("Romance")]
        [InlineData("Horror")]
        [InlineData("Historical")]
        [InlineData("Biography")]
        [InlineData("Philosophy")]
        [InlineData("Classic")]
        [InlineData("Dystopian")]
        [InlineData("Adventure")]
        [InlineData("Children's")]
        public void Validator_ForValidCategory_ShouldNotHaveValidationErrorsForCategoryProperty(string categoryName)
        {
            // arrange
            var command = new CreateBookCommand()
            {
                Categories = new List<CategoryDto>
                {
                    new CategoryDto() {
                        Id = 1,
                        Name = categoryName
                    }
                },
            };

            var validator = new CreateBookCommandValidator();

            // act
            var result = validator.TestValidate(command);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.Categories);

        }
    }
}