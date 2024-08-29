// <copyright file="GetUserTests.cs" company="Transilvania University of Brasov">
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
    /// Test class for
    ///  <see cref="UserServicesImplementation.GetAllUsers()"/>,
    ///  <see cref="UserServicesImplementation.GetUserById(int)"/> and
    ///  <see cref="UserServicesImplementation.GetUserByEmailAndPassword(string, string)"/>
    ///  methods.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class GetUserTests
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        [Test]
        public void GET_AllUsers()
        {
            List<User> users = GetSampleUsers();

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetAllUsers()).Returns(users);
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            var expected = users;
            var actual = userServices.GetAllUsers();

            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i].Id, Is.EqualTo(expected[i].Id));
                Assert.That(actual[i].FirstName, Is.EqualTo(expected[i].FirstName));
                Assert.That(actual[i].LastName, Is.EqualTo(expected[i].LastName));
                Assert.That(actual[i].UserName, Is.EqualTo(expected[i].UserName));
                Assert.That(actual[i].PhoneNumber, Is.EqualTo(expected[i].PhoneNumber));
                Assert.That(actual[i].Email, Is.EqualTo(expected[i].Email));
                Assert.That(actual[i].Password, Is.EqualTo(expected[i].Password));
                Assert.That(actual[i].AccountType, Is.EqualTo(expected[i].AccountType));
            }
        }

        /// <summary>
        /// Test for retrieving all existing users but none were found.
        /// </summary>
        [Test]
        public void GET_AllUsers_NoneFound()
        {
            List<User> emptyUserList = new List<User>();

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetAllUsers()).Returns(emptyUserList);
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsEmpty(userServices.GetAllUsers());
        }

        /// <summary>
        /// Test for retrieving an existing user with the specified id.
        /// </summary>
        [Test]
        public void GET_UserById()
        {
            User user = GetSampleUser();

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserById(user.Id)).Returns(user);
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            var expected = user;
            var actual = userServices.GetUserById(user.Id);

            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.FirstName, Is.EqualTo(expected.FirstName));
            Assert.That(actual.LastName, Is.EqualTo(expected.LastName));
            Assert.That(actual.UserName, Is.EqualTo(expected.UserName));
            Assert.That(actual.PhoneNumber, Is.EqualTo(expected.PhoneNumber));
            Assert.That(actual.Email, Is.EqualTo(expected.Email));
            Assert.That(actual.Password, Is.EqualTo(expected.Password));
            Assert.That(actual.AccountType, Is.EqualTo(expected.AccountType));
        }

        /// <summary>
        /// Test for retrieving an existing user with the specified id but no such user was found.
        /// </summary>
        [Test]
        public void GET_UserById_NotFound()
        {
            User user = GetSampleUser();
            User? nullUser = null;

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserById(user.Id)).Returns(nullUser!);
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsNull(userServices.GetUserById(user.Id));
        }

        /// <summary>
        /// Test for retrieving an existing user with the specified email address and password.
        /// </summary>
        [Test]
        public void GET_UserByEmailAndPassword()
        {
            User user = GetSampleUser();

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserByEmailAndPassword(user.Email, user.Password)).Returns(user);
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            var expected = user;
            var actual = userServices.GetUserByEmailAndPassword(user.Email, user.Password);

            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.FirstName, Is.EqualTo(expected.FirstName));
            Assert.That(actual.LastName, Is.EqualTo(expected.LastName));
            Assert.That(actual.UserName, Is.EqualTo(expected.UserName));
            Assert.That(actual.PhoneNumber, Is.EqualTo(expected.PhoneNumber));
            Assert.That(actual.Email, Is.EqualTo(expected.Email));
            Assert.That(actual.Password, Is.EqualTo(expected.Password));
            Assert.That(actual.AccountType, Is.EqualTo(expected.AccountType));
        }

        /// <summary>
        /// Test for retrieving an existing user with the specified email address and password but no such user was found.
        /// </summary>
        [Test]
        public void GET_UserByEmailAndPassword_NotFound()
        {
            User user = GetSampleUser();
            User? nullUser = null;

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserByEmailAndPassword(user.Email, user.Password)).Returns(nullUser!);
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsNull(userServices.GetUserByEmailAndPassword(user.Email, user.Password));
        }

        /// <summary>
        /// Gets the sample user.
        /// </summary>
        /// <returns>user.</returns>
        private static User GetSampleUser()
        {
            return new User("Matei", "Debu", "MateiDebu12", "0770463123", "mateidebu@yahoo.com", "Matei12!");
        }

        /// <summary>
        /// Gets the sample users.
        /// </summary>
        /// <returns>a list of users.</returns>
        private static List<User> GetSampleUsers()
        {
            return new List<User>
            {
                new User("Matei", "Debu", "MateiDebu12", "0770463123", "mateidebu@yahoo.com", "Matei12!"),
                new User("Vadut", "Andrei", "Valdut3", null!, "vld@yahoo.com", "Andrei12!"),
                new User("Popescu", "Ana", "Ana12A", null!, "anau@yahoo.com", "Parola!12"),
            };
        }
    }
}
