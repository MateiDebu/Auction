using DataMapper.Interfaces;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace TestServiceLayer.UserServiceTests
{
    /// <summary>
    /// Test class for <see cref="UserServicesImplementation.DeleteUser(User)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class DeleteUserTests
    {
        /// <summary>
        /// Deletes the null user.
        /// </summary>
        [Test]
        public void DELETE_NullUser()
        {
            User user = null;

            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.DeleteUser(user));
        }

        /// <summary>
        /// Deletes the valid user non existing user.
        /// </summary>
        [Test]
        public void DELETE_ValidUser_NonExistingUser()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", "aaAAaaaa1!");
            User nullUser = null;

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserById(user.Id)).Returns(nullUser);

            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.DeleteUser(user));
        }

        /// <summary>
        /// Deletes the valid user.
        /// </summary>
        [Test]
        public void DELETE_ValidUser()
        {
            User user = new User("Matei", "Debu", "MateiDebu", "0123456789", "mateidebu@yahoo.com", "aaAAaa81!");

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserById(user.Id)).Returns(user);
            userServiceMock.Setup(x => x.DeleteUser(user)).Returns(true);

            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.That(userServices.DeleteUser(user), Is.True);
        }
    }
}
