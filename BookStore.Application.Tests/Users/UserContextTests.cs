using BookStore.Application.Users;
using BookStore.Domain.Constants;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Application.Users.Tests
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            // arrange
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var claims = new List<Claim>()
            {
                new (ClaimTypes.NameIdentifier, "1"),
                new (ClaimTypes.Email, "test@test.com"),
                new (ClaimTypes.Role, UserRoles.Admin),
                new (ClaimTypes.Role, UserRoles.User),
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user
            });

            var userContext = new UserContext(httpContextAccessorMock.Object);
        
            // act
            var currentUser = userContext.GetCurrentUser();

            // assert
            currentUser.Should().NotBeNull();
            currentUser.Id.Should().Be("1");
            currentUser.Email.Should().Be("test@test.com");
            currentUser.Roles.Should().ContainInOrder(UserRoles.Admin, UserRoles.User);
        }

        [Fact()]
        public void GetCurrentUser_WithUserContextNotPresent_ThrowsInvalidOperationException()
        {
            // arrange
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext).Returns((HttpContext)null);

            var userContext = new UserContext(httpContextAccessorMock.Object);

            // act
            Action action = () => userContext.GetCurrentUser();

            // assert
            action.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("User context is not present");
        }
    }
}