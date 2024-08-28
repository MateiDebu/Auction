namespace TestDataMapper.TestSqlServerDAO
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics.CodeAnalysis;
    using DataMapper;
    using DataMapper.SqlServerDAO;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class SQLUserDataServicesTests
    {
        private Mock<AuctionContext> mockContext;
        private Mock<DbSet<User>> mockDbSet;
        private SQLUserDataServices userDataServices;

        [SetUp]
        public void SetUp()
        {
            this.mockContext = new Mock<AuctionContext>();
            this.mockDbSet = new Mock<DbSet<User>>();

            this.mockContext.Setup(m => m.Users).Returns(this.mockDbSet.Object);

            this.userDataServices = new SQLUserDataServices(this.mockContext.Object);
        }

        [Test]
        public void AddUser_ShouldAddUserToContextAndSaveChanges()
        {
            var user = new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12");

            mockDbSet.Setup(m => m.Add(It.IsAny<User>())).Returns((User u) => u);

            var result = userDataServices.AddUser(user);

            mockDbSet.Verify(m=>m.Add(It.Is<User>(u => u == user)), Times.Once());
            mockContext.Verify(m=>m.SaveChanges(), Times.Once());

            Assert.IsTrue(result);
        }

        [Test]
        public void AddUser_ShouldReturnFalse_WhenAddFails()
        {
            var user = new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12");

            mockDbSet.Setup(m => m.Add(It.IsAny<User>())).Returns((User u) => u);
            mockContext.Setup(m => m.SaveChanges()).Throws(new Exception());

            var result = userDataServices.AddUser(user);

            mockDbSet.Verify(m => m.Add(It.Is<User>(u => u == user)), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsFalse(result);
        }
        


        [Test]
        public void DeleteUser_ShouldRemoveUserFromContextAndSaveChanges()
        {
            var user = new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12");

            mockDbSet.Setup(m => m.Attach(It.IsAny<User>())).Returns((User u) => u);
            mockDbSet.Setup(m => m.Remove(It.IsAny<User>())).Returns((User u) => u);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            var result = userDataServices.DeleteUser(user);

            mockDbSet.Verify(m => m.Attach(It.Is<User>(u => u == user)), Times.Once());
            mockDbSet.Verify(m => m.Remove(It.Is<User>(u => u == user)), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsTrue(result);
        }

        [Test]
        public void UsernameAlreadyExists_ShouldReturnTrue_WhenUsernameExists()
        {
            var username = "MateiDebu";
            var users = new List<User>
            {
                 new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12")
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = userDataServices.UsernameAlreadyExists(username);

            Assert.IsTrue(result);
        }

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

            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = userDataServices.UsernameAlreadyExists(username);

            Assert.IsFalse(result);
        }

        [Test]
        public void EmailAlreadyExists_ShouldReturnTrue_WhenEmailExists()
        {
            var email = "mateidebu@mail.ro";
            var users = new List<User>
            {
                 new User("Matei", "Debu", "MateiDebu", "0770234566", "mateidebu@mail.ro", "Parola!12")
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = userDataServices.EmailAlreadyExists(email);

            Assert.IsTrue(result);
        }

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
