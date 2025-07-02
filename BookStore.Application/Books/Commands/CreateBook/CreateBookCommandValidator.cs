using BookStore.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        private readonly List<string> validCategories = new()
        {
            "Fantasy", "Science Fiction", "Thriller", "Romance", "Horror",
            "Historical", "Biography", "Philosophy", "Classic", "Dystopian",
            "Adventure", "Children's"
        };

        public CreateBookCommandValidator() 
        {
            RuleFor(dto => dto.Categories)
              .Must(categories => categories.All(c => validCategories.Contains(c.Name)))
              .WithMessage("Invalid category. Please choose from the valid categories.");

            RuleFor(dto => dto.PublishedDate)
              .LessThanOrEqualTo(DateTime.Today)
              .WithMessage("Publication date cannot be in the future.");

            RuleFor(dto => dto.Price)
              .GreaterThan(0)
              .WithMessage("Price must be greater than zero.");

        }
    }
}
