// <copyright file="SQLUserDataServicesTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestDataMapper.TestSqlServerDAO
{
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using DataMapper;
    using DataMapper.SqlServerDAO;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// The SQLUSerDataServicesTests class.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class SQLUserDataServicesTests
    {
        /// <summary>
        /// The mock context.
        /// </summary>
        private Mock<AuctionContext> mockContext;

        /// <summary>
        /// The mock database set.
        /// </summary>
        private Mock<DbSet<User>> mockDbSet;

        /// <summary>
        /// The user data services.
        /// </summary>
        private SQLUserDataServices userDataServices;

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.mockContext = new Mock<AuctionContext>();
            this.mockDbSet = new Mock<DbSet<User>>();

            this.mockContext.Setup(m => m.Users).Returns(this.mockDbSet.Object);

            this.userDataServices = new SQLUserDataServices(this.mockContext.Object);
        }

        /// <summary>
        /// Adds the user should add user to context and save changes.
        /// </summary>
        [Test]
        public void AddUser_ShouldAddUserToContextAndSaveChanges()
        {
            var user = new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12");

            this.mockDbSet.Setup(m => m.Add(It.IsAny<User>())).Returns((User u) => u);

            var result = this.userDataServices.AddUser(user);

            this.mockDbSet.Verify(m => m.Add(It.Is<User>(u => u == user)), Times.Once());
            this.mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Adds the user should return false when add fails.
        /// </summary>
        [Test]
        public void AddUser_ShouldReturnFalse_WhenAddFails()
        {
            var user = new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12");

            this.mockDbSet.Setup(m => m.Add(It.IsAny<User>())).Returns((User u) => u);
            this.mockContext.Setup(m => m.SaveChanges()).Throws(new Exception());

            var result = this.userDataServices.AddUser(user);

            this.mockDbSet.Verify(m => m.Add(It.Is<User>(u => u == user)), Times.Once());
            this.mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Deletes the user should remove user from context and save changes.
        /// </summary>
        [Test]
        public void DeleteUser_ShouldRemoveUserFromContextAndSaveChanges()
        {
            var user = new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12");

            this.mockDbSet.Setup(m => m.Attach(It.IsAny<User>())).Returns((User u) => u);
            this.mockDbSet.Setup(m => m.Remove(It.IsAny<User>())).Returns((User u) => u);
            this.mockContext.Setup(m => m.SaveChanges()).Returns(1);

            var result = this.userDataServices.DeleteUser(user);

            this.mockDbSet.Verify(m => m.Attach(It.Is<User>(u => u == user)), Times.Once());
            this.mockDbSet.Verify(m => m.Remove(It.Is<User>(u => u == user)), Times.Once());
            this.mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Usernames the already exists should return true when username exists.
        /// </summary>
        [Test]
        public void UsernameAlreadyExists_ShouldReturnTrue_WhenUsernameExists()
        {
            var username = "MateiDebu";
            var users = new List<User>
            {
               new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12"),
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            this.mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = this.userDataServices.UsernameAlreadyExists(username);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Usernames the already exists should return false when username does not exist.
        /// </summary>
        [Test]
        public void UsernameAlreadyExists_ShouldReturnFalse_WhenUsernameDoesNotExist()
        {
            var username = "NonExist";
            var users = new List<User>().AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            this.mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = this.userDataServices.UsernameAlreadyExists(username);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Emails the already exists should return true when email exists.
        /// </summary>
        [Test]
        public void EmailAlreadyExists_ShouldReturnTrue_WhenEmailExists()
        {
            var email = "mateidebu@mail.ro";
            var users = new List<User>
            {
                 new User("Matei", "Debu", "MateiDebu", "0770234566", "mateidebu@mail.ro", "Parola!12"),
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            this.mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = this.userDataServices.EmailAlreadyExists(email);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Emails the already exists should return false when email does not exist.
        /// </summary>
        [Test]
        public void EmailAlreadyExists_ShouldReturnFalse_WhenEmailDoesNotExist()
        {
            var email = "NonExist";
            var users = new List<User>().AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            this.mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = this.userDataServices.EmailAlreadyExists(email);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Gets all users should return list of users.
        /// </summary>
        [Test]
        public void GetAllUsers_ShouldReturnListOfUsers()
        {
            var users = new List<User>
        {
            new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12"),
            new User("Vladut", "Andrei", "VladAndrei", "0770234567", "vlad.andrei@mail.ro", "Parola!12"),
        }.AsQueryable();

            var mockDbSet = this.CreateDbSetMock(users);

            this.mockContext.Setup(m => m.Users).Returns(mockDbSet.Object);

            var result = this.userDataServices.GetAllUsers();

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].FirstName, Is.EqualTo("Matei"));
            Assert.That(result[1].FirstName, Is.EqualTo("Vladut"));
        }

        /// <summary>
        /// Gets the user by identifier should return user when user exists.
        /// </summary>
        [Test]
        public void GetUserById_ShouldReturnUser_WhenUserExists()
        {
            var users = new List<User>
            {
                 new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12") { Id = 1 },
                 new User("Vladut", "Andrei", "VladAndrei", "0770234567", "vlad.andrei@mail.ro", "Parola!12") { Id = 2 },
            }.AsQueryable();

            var mockDbSet = this.CreateDbSetMock(users);

            this.mockContext.Setup(m => m.Users).Returns(mockDbSet.Object);

            var result = this.userDataServices.GetUserById(1);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.FirstName, Is.EqualTo("Matei"));
        }

        /// <summary>
        /// Gets the user by identifier should return null when user does not exist.
        /// </summary>
        [Test]
        public void GetUserById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            var users = new List<User>
            {
                new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12") { Id = 1 },
            }.AsQueryable();

            var mockDbSet = this.CreateDbSetMock(users);

            this.mockContext.Setup(m => m.Users).Returns(mockDbSet.Object);

            var result = this.userDataServices.GetUserById(99);

            Assert.IsNull(result);
        }

        /// <summary>
        /// Gets the user by email and password should return user when credentials match.
        /// </summary>
        [Test]
        public void GetUserByEmailAndPassword_ShouldReturnUser_WhenCredentialsMatch()
        {
            var users = new List<User>
            {
                new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12"),
                new User("Vladut", "Andrei", "VladAndrei", "0770234567", "vlad.andrei@mail.ro", "Parola!12"),
            }.AsQueryable();

            var mockDbSet = this.CreateDbSetMock(users);

            this.mockContext.Setup(m => m.Users).Returns(mockDbSet.Object);

            var result = this.userDataServices.GetUserByEmailAndPassword("matei.debu@mail.ro", "Parola!12");

            Assert.IsNotNull(result);
            Assert.That(result.FirstName, Is.EqualTo("Matei"));
        }

        /// <summary>
        /// Gets the user by email and password should return null when credentials do not match.
        /// </summary>
        [Test]
        public void GetUserByEmailAndPassword_ShouldReturnNull_WhenCredentialsDoNotMatch()
        {
            var users = new List<User>
            {
                new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12"),
            }.AsQueryable();

            var mockDbSet = this.CreateDbSetMock(users);

            this.mockContext.Setup(m => m.Users).Returns(mockDbSet.Object);

            var result = this.userDataServices.GetUserByEmailAndPassword("matei.debu@mail.ro", "WrongPassword");

            Assert.IsNull(result);
        }

        /// <summary>
        /// Creates the database set mock.
        /// </summary>
        /// <typeparam name="T">elemets.</typeparam>
        /// <param name="elements">The elements.</param>
        /// <returns>dbSetMock.</returns>
        private Mock<DbSet<T>> CreateDbSetMock<T>(IQueryable<T> elements)
            where T : class
        {
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elements.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elements.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elements.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elements.GetEnumerator());

            dbSetMock.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => elements.ToList().Add(s));
            dbSetMock.Setup(d => d.Remove(It.IsAny<T>())).Callback<T>((s) => elements.ToList().Remove(s));

            return dbSetMock;
        }
    }
}
