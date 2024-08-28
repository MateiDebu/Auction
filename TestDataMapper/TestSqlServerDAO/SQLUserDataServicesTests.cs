using DataMapper;
using DataMapper.SqlServerDAO;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace TestDataMapper.TestSqlServerDAO
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class SQLUserDataServicesTests
    {
        private Mock<AuctionContext> _mockContext;
        private Mock<DbSet<User>> _mockDbSet;
        private SQLUserDataServices _userDataServices;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<AuctionContext>();
            _mockDbSet = new Mock<DbSet<User>>();

            _mockContext.Setup(m => m.Users).Returns(_mockDbSet.Object);

            _userDataServices = new SQLUserDataServices(_mockContext.Object);
        }

        [Test]
        public void AddUser_ShouldAddUserToContextAndSaveChanges()
        {
            var user = new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12");

            _mockDbSet.Setup(m => m.Add(It.IsAny<User>())).Returns((User u) => u);

            var result = _userDataServices.AddUser(user);

            _mockDbSet.Verify(m=>m.Add(It.Is<User>(u => u == user)), Times.Once());
            _mockContext.Verify(m=>m.SaveChanges(), Times.Once());

            Assert.IsTrue(result);
        }

        [Test]
        public void AddUser_ShouldReturnFalse_WhenAddFails()
        {
            var user = new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12");

            _mockDbSet.Setup(m => m.Add(It.IsAny<User>())).Returns((User u) => u);
            _mockContext.Setup(m => m.SaveChanges()).Throws(new Exception());

            var result = _userDataServices.AddUser(user);

            _mockDbSet.Verify(m => m.Add(It.Is<User>(u => u == user)), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteUser_ShouldRemoveUserFromContextAndSaveChanges()
        {
            var user = new User("Matei", "Debu", "MateiDebu", "0770234566", "matei.debu@mail.ro", "Parola!12");

            _mockDbSet.Setup(m => m.Attach(It.IsAny<User>())).Returns((User u) => u);
            _mockDbSet.Setup(m => m.Remove(It.IsAny<User>())).Returns((User u) => u);
            _mockContext.Setup(m => m.SaveChanges()).Returns(1);

            var result = _userDataServices.DeleteUser(user);

            _mockDbSet.Verify(m => m.Attach(It.Is<User>(u => u == user)), Times.Once());
            _mockDbSet.Verify(m => m.Remove(It.Is<User>(u => u == user)), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());

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

            _mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = _userDataServices.UsernameAlreadyExists(username);

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

            _mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = _userDataServices.UsernameAlreadyExists(username);

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

            _mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = _userDataServices.EmailAlreadyExists(email);

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

            _mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var result = _userDataServices.EmailAlreadyExists(email);

            Assert.IsFalse(result);
        }
    }
}
