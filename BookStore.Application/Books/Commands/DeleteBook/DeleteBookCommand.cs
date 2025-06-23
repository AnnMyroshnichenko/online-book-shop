using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand(int id) : IRequest<bool>
    {
        public int Id { get;} = id;
    }
}
