// <copyright file="DeleteRatingTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestServiceLayer.RatingServiceTests
{
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DomainModel.Enums;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;
    using ServiceLayer.Implementation;

    /// <summary>
    /// Test class for <see cref="RatingServicesImplementation.DeleteRating(Rating)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class DeleteRatingTests
    {
        /// <summary>
        /// Deletes the null rating.
        /// </summary>
        [Test]
        public void DELETE_NullRating()
        {
            Rating? rating = null;
            var ratingServiceMock = new Mock<IRatingDataServices>();
            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.That(ratingServices.DeleteRating(rating!), Is.False);
        }

        /// <summary>
        /// Deletes the non existing rating.
        /// </summary>
        [Test]
        public void DELETE_NonExistingRating()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    DateTime.Today,
                    DateTime.Today.AddDays(1)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                8);
            Rating? nullRating = null;
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetRatingById(rating.Id)).Returns(nullRating!);

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);
            Assert.That(ratingServices.DeleteRating(rating), Is.False);
        }

        /// <summary>
        /// Deletes the valid rating.
        /// </summary>
        [Test]
        public void DELETE_ValidRating()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    DateTime.Today,
                    DateTime.Today.AddDays(1)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                8);
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetRatingById(rating.Id)).Returns(rating);
            ratingServiceMock.Setup(x => x.DeleteRating(rating)).Returns(true);

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);
            Assert.That(ratingServices.DeleteRating(rating), Is.True);
        }
    }
}
