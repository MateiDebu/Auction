// <copyright file="DeleteUserTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestServiceLayer.UserServiceTests
{
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;
    using ServiceLayer.Implementation;

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
            User? user = null;

            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.DeleteUser(user!));
        }

        /// <summary>
        /// Deletes the valid user non existing user.
        /// </summary>
        [Test]
        public void DELETE_ValidUser_NonExistingUser()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", "aaAAaaaa1!");
            User? nullUser = null;

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserById(user.Id)).Returns(nullUser!);

            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.DeleteUser(user));
        }
    }
}
