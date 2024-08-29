// <copyright file="SQLRatingDataServicesTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestDataMapper.TestSqlServerDAO
{
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using DataMapper;
    using DataMapper.SqlServerDAO;
    using DomainModel.Enums;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// The SQLRatingDataServicesTests.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class SQLRatingDataServicesTests
    {
        /// <summary>
        /// The mock context.
        /// </summary>
        private Mock<AuctionContext> mockContext;

        /// <summary>
        /// The mock database set.
        /// </summary>
        private Mock<DbSet<Rating>> mockDbSet;

        /// <summary>
        /// The rating data services.
        /// </summary>
        private SQLRatingDataServices ratingDataServices;

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.mockContext = new Mock<AuctionContext>();
            this.mockDbSet = new Mock<DbSet<Rating>>();

            this.mockContext.Setup(m => m.Ratings).Returns(this.mockDbSet.Object);

            this.ratingDataServices = new SQLRatingDataServices(this.mockContext.Object);
        }

        /// <summary>
        /// Adds the rating should add user to context and save changes.
        /// </summary>
        [Test]
        public void AddRating_ShouldAddUserToContextAndSaveChanges()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    DateTime.Today.AddDays(-10),
                    DateTime.Today.AddDays(-5)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                5);

            this.mockDbSet.Setup(m => m.Add(It.IsAny<Rating>())).Returns((Rating r) => r);

            var result = this.ratingDataServices.AddRating(rating);

            this.mockDbSet.Verify(m => m.Add(It.Is<Rating>(r => r == rating)), Times.Once());
            this.mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Deletes the rating should remove user from context and save changes.
        /// </summary>
        [Test]
        public void DeleteRating_ShouldRemoveUserFromContextAndSaveChanges()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    DateTime.Today.AddDays(-10),
                    DateTime.Today.AddDays(-5)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                5);

            this.mockDbSet.Setup(m => m.Attach(It.IsAny<Rating>())).Returns((Rating u) => u);
            this.mockDbSet.Setup(m => m.Remove(It.IsAny<Rating>())).Returns((Rating u) => u);
            this.mockContext.Setup(m => m.SaveChanges()).Returns(1);

            var result = this.ratingDataServices.DeleteRating(rating);

            this.mockDbSet.Verify(m => m.Attach(It.Is<Rating>(u => u == rating)), Times.Once());
            this.mockDbSet.Verify(m => m.Remove(It.Is<Rating>(u => u == rating)), Times.Once());
            this.mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsTrue(result);
        }
    }
}
