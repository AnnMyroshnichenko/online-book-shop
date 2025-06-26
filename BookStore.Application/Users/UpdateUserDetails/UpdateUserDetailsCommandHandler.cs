using BookStore.Domain.Entities;
using BookStore.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Users.UpdateUserDetails
{
    public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger,
        IUserContext userContext,
        IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailsCommand>
    {
        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            logger.LogInformation("Updating user: {UserId}, with {@Request}", user!.Id, request);

            var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);

            if(dbUser == null)
            {
                throw new NotFoundException(nameof(User), user!.Id);
            }

            dbUser.Street = request.Street;
            dbUser.City = request.City;
            dbUser.Country = request.Country;
            dbUser.State = request.State;
            dbUser.PostalCode = request.PostalCode;


            userStore.UpdateAsync(dbUser, cancellationToken);
        }
    }
}
