using DataMapper.Interfaces;
using DomainModel.Enums;
using DomainModel.Models;
using log4net;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServiceLayer.RatingServiceTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class GetRatingTests
    {
        [Test]
        public void GET_AllRatings()
        {
            List<Rating> ratings = GetSampleRatings();
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(r => r.GetAllRatings()).Returns(ratigns);

            var ratingServices = new RatingServicesImplementation(ratingServiceMock.Object);
            var expected = ratings;
            var actual = ratingServices.GetAllRatings();

            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for(int i = 0; i< expected.Count; i++)
            {
                Assert.That(actual[i].Id, Is.EqualTo(expected[i].Id));
                Assert.That(actual[i].DateAndTime, Is.EqualTo(expected[i].DateAndTime));

                Assert.That(actual[i].Product.Id, Is.EqualTo(expected[i].Product.Id));
                Assert.That(actual[i].Product.Name, Is.EqualTo(expected[i].Product.Name));
                Assert.That(actual[i].Product.Description, Is.EqualTo(expected[i].Product.Description));
                Assert.That(actual[i].Product.Category.Id, Is.EqualTo(expected[i].Product.Category.Id));
                Assert.That(actual[i].Product.Category.Name, Is.EqualTo(expected[i].Product.Category.Name));
                Assert.That(actual[i].Product.Category.ParentCategory, Is.EqualTo(expected[i].Product.Category.ParentCategory));
                Assert.That(actual[i].Product.StartingPrice, Is.EqualTo(expected[i].Product.StartingPrice));
                Assert.That(actual[i].Product.Currency, Is.EqualTo(expected[i].Product.Currency));
                Assert.That(actual[i].Product.CreationDate, Is.EqualTo(expected[i].Product.CreationDate));
                Assert.That(actual[i].Product.StartDate, Is.EqualTo(expected[i].Product.StartDate));
                Assert.That(actual[i].Product.EndDate, Is.EqualTo(expected[i].Product.EndDate));
                Assert.That(actual[i].Product.TerminationDate, Is.EqualTo(expected[i].Product.TerminationDate));

                Assert.That(actual[i].RatingUser.Id, Is.EqualTo(expected[i].RatingUser.Id));
                Assert.That(actual[i].RatingUser.FirstName, Is.EqualTo(expected[i].RatingUser.FirstName));
                Assert.That(actual[i].RatingUser.LastName, Is.EqualTo(expected[i].RatingUser.LastName));
                Assert.That(actual[i].RatingUser.UserName, Is.EqualTo(expected[i].RatingUser.UserName));
                Assert.That(actual[i].RatingUser.PhoneNumber, Is.EqualTo(expected[i].RatingUser.PhoneNumber));
                Assert.That(actual[i].RatingUser.Email, Is.EqualTo(expected[i].RatingUser.Email));
                Assert.That(actual[i].RatingUser.Password, Is.EqualTo(expected[i].RatingUser.Password));
                Assert.That(actual[i].RatingUser.AccountType, Is.EqualTo(expected[i].RatingUser.AccountType));

                Assert.That(actual[i].RatedUser.Id, Is.EqualTo(expected[i].RatedUser.Id));
                Assert.That(actual[i].RatedUser.FirstName, Is.EqualTo(expected[i].RatedUser.FirstName));
                Assert.That(actual[i].RatedUser.LastName, Is.EqualTo(expected[i].RatedUser.LastName));
                Assert.That(actual[i].RatedUser.UserName, Is.EqualTo(expected[i].RatedUser.UserName));
                Assert.That(actual[i].RatedUser.PhoneNumber, Is.EqualTo(expected[i].RatedUser.PhoneNumber));
                Assert.That(actual[i].RatedUser.Email, Is.EqualTo(expected[i].RatedUser.Email));
                Assert.That(actual[i].RatedUser.Password, Is.EqualTo(expected[i].RatedUser.Password));
                Assert.That(actual[i].RatedUser.AccountType, Is.EqualTo(expected[i].RatedUser.AccountType));

                Assert.That(actual[i].Grade, Is.EqualTo(expected[i].Grade));
            }
        }

        [Test]
        public void GET_AllRatings_NotFound()
        {
            List<Rating> emptyRatingList = new List<Rating>();
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x => x.GetAllRatings()).Returns(emptyRatingList);
            
            var bidServices = new RatingServicesImplementation(ratingServiceMock.Object);

            Assert.IsEmpty(bidServices.GetAllRatings());
        }

        [Test]
        public void GET_RatingById()
        {
            Rating rating = GetSampleRating();
            var ratingServiceMock = new Mock<IRatingDataServices>();
            ratingServiceMock.Setup(x=>x.GetRatingById(rating.Id)).Returns(rating);
            
        }

        private static Rating GetSampleRating()
        {
            return new Rating(
                new Product("Aparat foto CANNON", "face poze", new Category("Aparat foto", null), 100, ECurrency.EUR,
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                DateTime.Today,
                DateTime.Today.AddDays(1)),
                new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                8);
        }

        private static List<Rating> GetSampleRatings()
        {
            return new List<Rating>
            {
                new Rating(
                    new Product("Aparat foto CANNON", "face poze", new Category("Aparat foto", null), 100, ECurrency.EUR,
                    new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                    DateTime.Today,
                    DateTime.Today.AddDays(1)),
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                    8),
                new Rating(
                    new Product("Aparat foto CANNON", "face poze", new Category("Aparat foto", null), 100, ECurrency.EUR,
                    new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                    DateTime.Today,
                    DateTime.Today.AddDays(1)),
                    new User("Vladut", "Andrei", "VladAndrei", "0321123455", "vladandrei@gmail.ro", "Parola12!"),
                    new User("Matei", "Debu", "MateiDebu", "0770564321", "mateidebu@yahoo.com", "Parola12!"),
                    10),
            };
        }
    }
}
