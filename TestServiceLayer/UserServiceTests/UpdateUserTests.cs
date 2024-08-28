// <copyright file="UpdateUserTests.cs" company="Transilvania University of Brasov">
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
    /// Test class for <see cref="UserServicesImplementation.UpdateUser(User)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class UpdateUserTests
    {
        /// <summary>
        /// Updates the null user.
        /// </summary>
        [Test]
        public void UPDATE_NullUser()
        {
            User user = null;
            var userServiceMock = new Mock<IUserDataServices>();
            var userService = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userService.UpdateUser(user));
        }

        /// <summary>
        /// Updates the invalid user first name null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_FirstName_Null()
        {
            User user = new User(null, "Debu", "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user first name empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_FirstName_Empty()
        {
            User user = new User(string.Empty, "Debu", "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user first name too long.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_FirstName_TooLong()
        {
            User user = new User('X' + new string('a', 20), "Debu", "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user first name no upper case letter.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_FirstName_NoUpperCaseLetter()
        {
            User user = new User(new string('x', 10), "Debu", "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user first name no lower case letter.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_FirstName_NoLowerCaseLetter()
        {
            User user = new User(new string('A', 10), "Debu", "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user first name contains symbol.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_FirstName_ContainsSymbol()
        {
            User user = new User("Matei!", "Debu", "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }


        /// <summary>
        /// Adds the invalid user first name contains number.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_FirstName_ContainsNumber()
        {
            User user = new User("Matei12", "Debu", "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user last name null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_LastName_Null()
        {
            User user = new User("Matei12", null, "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user last name empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_LastName_Empty()
        {
            User user = new User("Matei", string.Empty, "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user last name too long.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_LastName_TooLong()
        {
            User user = new User("Matei", 'X' + new string('x', 20), "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user last name no upper case letter.
        /// </summary>
        [Test]
        public void ADD_InvalidUser_LastName_NoUpperCaseLetter()
        {
            User user = new User("Matei", new string('x', 10), "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.AddUser(user));
        }

        /// <summary>
        /// Adds the invalid user last name no lower case letter.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_LastName_NoLowerCaseLetter()
        {
            User user = new User("Matei", new string('A', 10), "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user last name contains symbol.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_LastName_ContainsSymbol()
        {
            User user = new User("Matei", "Mate!", "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user last name contains number.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_LastName_ContainsNumber()
        {
            User user = new User("Matei", "Mate2", "MateiDebu", "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user user name null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_UserName_Null()
        {
            User user = new User("Matei", "Matei", null, "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user user name empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_UserName_Empty()
        {
            User user = new User("Matei", "Matei", string.Empty, "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user user name too long.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_UserName_TooLong()
        {
            User user = new User("Matei", "Matei", new string('x', 31), "0770123456", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();

            var userServices = new UserServicesImplementation(userServiceMock.Object);
            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the valid user phone number null.
        /// </summary>
        [Test]
        public void UPDATE_ValidUser_PhoneNumber_Null()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", null, "mateidebu@yahoo.com", "Matei!123");

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserById(user.Id)).Returns(user);
            userServiceMock.Setup(x => x.UpdateUser(user)).Returns(true);

            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsTrue(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user phone number too long.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_PhoneNumber_TooLong()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", new string('0', 20), "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user phone number invalid.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_PhoneNumber_Invalid()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "abc", "mateidebu@yahoo.com", "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user email empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_Email_Empty()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", string.Empty, "Matei!123");
            var userServiceMock = new Mock<IUserDataServices>();
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user password null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_Password_Null()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", null);
            var userServiceMock = new Mock<IUserDataServices>();
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user password empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_Password_Empty()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", string.Empty);
            var userServiceMock = new Mock<IUserDataServices>();
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user password too short.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_Password_TooShort()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", "aa!A1");
            var userServiceMock = new Mock<IUserDataServices>();
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user password missing lower case letter.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_Password_MissingLowerCaseLetter()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", "PASSWORD!1");
            var userServiceMock = new Mock<IUserDataServices>();
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user password missing upper case letter.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_Password_MissingUpperCaseLetter()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", "aaaaaaa!1");
            var userServiceMock = new Mock<IUserDataServices>();
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user password missing symbols.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_Password_MissingSymbols()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", "aaAaaaa1");
            var userServiceMock = new Mock<IUserDataServices>();
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Adds the invalid user password missing number.
        /// </summary>
        [Test]
        public void UPDATE_InvalidUser_Password_MissingNumber()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", "aaAAaaaa!");
            var userServiceMock = new Mock<IUserDataServices>();
            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Updates the non existing user.
        /// </summary>
        [Test]
        public void UPDATE_NonExistingUser()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", "aaAAa2a!");
            User nullUser = null;

            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserById(user.Id)).Returns(nullUser);

            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsFalse(userServices.UpdateUser(user));
        }

        /// <summary>
        /// Updates the valid user.
        /// </summary>
        [Test]
        public void UPDATE_ValidUser()
        {
            User user = new User("Matei", "Matei", "MateiDebu1", "0123456789", "mateidebu@yahoo.com", "aaAAa2a!");
            var userServiceMock = new Mock<IUserDataServices>();
            userServiceMock.Setup(x => x.GetUserById(user.Id)).Returns(user);
            userServiceMock.Setup(x => x.UpdateUser(user)).Returns(true);

            var userServices = new UserServicesImplementation(userServiceMock.Object);

            Assert.IsTrue(userServices.UpdateUser(user));
        }
    }
}
