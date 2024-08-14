using DataMapper.Interfaces;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServiceLayer.UserServiceTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class DeleteUserTests
    {
        [Test]
        public void DELETE_NullUser()
        {
            User user = null;

            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.DeleteUser(user));
        }

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

        [Test]
        public void DELETE_ValidUser()
        {
            User user = new User("Matei", "Debu", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", "aaAAaaa1!");

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserById(user.Id)).Returns(user);
            userServiceMock.Setup(x => x.DeleteUser(user)).Returns(true);

            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.That(userServices.DeleteUser(user), Is.True);
        }
    }
}
