using AutoMapper;
using BookStore.Application.Books.Commands.CreateBook;
using BookStore.Application.Books.Commands.UpdateBook;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Dtos
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            CreateMap<Book, BookDto>()
                .ForMember(c => c.Categories, opt => opt.MapFrom(src => src.Categories));

            CreateMap<CreateBookCommand, Book>()
                .ForMember(c => c.Categories, opt => opt.MapFrom(src => src.Categories));
       
            CreateMap<UpdateBookCommand, Book>()
                .ForMember(c => c.Categories, opt => opt.MapFrom(src => src.Categories));
        }
    }
}
