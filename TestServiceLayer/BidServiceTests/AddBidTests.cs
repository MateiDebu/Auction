// <copyright file="AddBidTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using DataMapper.Interfaces;
using DomainModel.Enums;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace TestServiceLayer.BidServiceTests
{
    /// <summary>
    /// Test class for <see cref="BidServicesImplementation.AddBid(Bid)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class AddBidTests
    {
        /// <summary>
        /// Adds the null bid.
        /// </summary>
        [Test]
        public void ADD_NullBid()
        {
            Bid bid = null;
            var bidServiceMock = new Mock<IBidDataServices>();
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(bidServices.AddBid(bid), Is.False);
        }

        /// <summary>
        /// Adds the invalid bid invalid product null product.
        /// </summary>
        [Test]
        public void ADD_InvalidBid_InvalidProduct_NullProduct()
        {
            Bid bid = new Bid(
                null,
                new User("Matei", "Debu", "MateiDebu", "0770231566", "mateide@yahoo.com", "Parola!12"),
                100,
                ECurrency.EUR);

            var bidServiceMock = new Mock<IBidDataServices>();
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(bidServices.AddBid(bid), Is.False);
        }

        /// <summary>
        /// Adds the invalid bid invalid product name null.
        /// </summary>
        [Test]
        public void ADD_InvalidBid_InvalidProduct_Name_Null()
        {
            Bid bid = new Bid(
                new Product(
                    null,
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Vladut", "Andrei", "AndreiVlad", "0899122487", "vladand@hotmail.com", "P@rola123"),
                    DateTime.Today.AddDays(-5),
                    DateTime.Today.AddDays(5)),
                new User("Matei", "Debu", "MateiDebu", "0770231566", "mateide@yahoo.com", "Parola!12"),
                1000,
                ECurrency.EUR);

            var bidServiceMock = new Mock<IBidDataServices>();
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.IsFalse(bidServices.AddBid(bid));
        }

        /// <summary>
        /// Adds the invalid bid invalid product name empty.
        /// </summary>
        [Test]
        public void ADD_InvalidBid_InvalidProduct_Name_Empty()
        {
            Bid bid = new Bid(
                new Product(
                    String.Empty,
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Vladut", "Andrei", "AndreiVlad", "0899122487", "vladand@hotmail.com", "P@rola123"),
                    DateTime.Today.AddDays(-5),
                    DateTime.Today.AddDays(5)),
                new User("Matei", "Debu", "MateiDebu", "0770231566", "mateide@yahoo.com", "Parola!12"),
                1000,
                ECurrency.EUR);

            var bidServiceMock = new Mock<IBidDataServices>();
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.IsFalse(bidServices.AddBid(bid));
        }

        /// <summary>
        /// Adds the invalid bid null buyer.
        /// </summary>
        [Test]
        public void ADD_InvalidBid_NullBuyer()
        {

            Bid bid = new Bid(
                new Product(
                    "Aparat foto Leica",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Vladut", "Andrei", "AndreiVlad", "0899122487", "vladand@hotmail.com", "P@rola123"),
                    DateTime.Today.AddDays(-5),
                    DateTime.Today.AddDays(5)),
                null,
                1000,
                ECurrency.EUR);

            var bidServiceMock = new Mock<IBidDataServices>();
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.IsFalse(bidServices.AddBid(bid));
        }

        /// <summary>
        /// Adds the invalid bid invalid buyer account type unknown.
        /// </summary>
        [Test]
        public void ADD_InvalidBid_InvalidBuyer_AccountType_Unknown()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto Leica",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Vladut", "Andrei", "AndreiVlad", "0899122487", "vladand@hotmail.com", "P@rola123"),
                    DateTime.Today.AddDays(-5),
                    DateTime.Today.AddDays(5)),
                new User("Matei", "Debu", "MateiDebu", "0770231566", "mateide@yahoo.com", "Parola!12"),
                1000,
                ECurrency.EUR);

            bid.Buyer.AccountType = EAccountType.Unknown;

            var bidServiceMock = new Mock<IBidDataServices>();
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.IsFalse(bidServices.AddBid(bid));
        }

        /// <summary>
        /// Adds the invalid bid amount negative.
        /// </summary>
        [Test]
        public void ADD_InvalidBid_Amount_Negative()
        {
            Bid bid = new Bid(
                new Product(
                    "Aparat foto Leica",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Vladut", "Andrei", "AndreiVlad", "0899122487", "vladand@hotmail.com", "P@rola123"),
                    DateTime.Today.AddDays(-5),
                    DateTime.Today.AddDays(5)),
                new User("Matei", "Debu", "MateiDebu", "0770231566", "mateide@yahoo.com", "Parola!12"),
                -1,
                ECurrency.EUR);

            var bidServiceMock = new Mock<IBidDataServices>();
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.IsFalse(bidServices.AddBid(bid));
        }

        //[Test]
        //public void ADD_ValidBid_TooManyBids()
        //{
        //    Bid bid = new Bid(
        //       new Product(
        //           "Aparat foto Leica",
        //           "face poze",
        //           new Category("Aparat foto", null),
        //           100,
        //           ECurrency.EUR,
        //           new User("Vladut", "Andrei", "AndreiVlad", "0899122487", "vladand@hotmail.com", "P@rola123"),
        //           DateTime.Today.AddDays(-5),
        //           DateTime.Today.AddDays(5)),
        //      new User("Matei", "Debu", "MateiDebu", "0770231566", "mateide@yahoo.com", "Parola!12"),
        //       1000,
        //       ECurrency.EUR);

        //    var bidServiceMock = new Mock<IBidDataServices>();
        //    bidServiceMock.Setup(x => x.GetNoOfActiveBidsByUserId(bid.Buyer.Id)).Returns(11);
        //    var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();
        //    userScoreAndLimitsServiceMock.Setup(x => x.GetUserLimitsByUserId(bid.Buyer.Id)).Returns(11);

        //    var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

        //    Assert.That(bidServices.AddBid(bid), Is.False);
        //}

        /// <summary>
        /// Adds the valid bid auction hasnt started.
        /// </summary>
        [Test]
        public void ADD_ValidBid_AuctionHasntStarted()
        {
            Bid bid = new Bid(
               new Product(
                   "Aparat foto Leica",
                   "face poze",
                   new Category("Aparat foto", null),
                   100,
                   ECurrency.EUR,
                   new User("Vladut", "Andrei", "AndreiVlad", "0899122487", "vladand@hotmail.com", "P@rola123"),
                   DateTime.Today.AddDays(5),
                   DateTime.Today.AddDays(10)),
              new User("Matei", "Debu", "MateiDebu", "0770231566", "mateide@yahoo.com", "Parola!12"),
               100,
               ECurrency.EUR);

            var bidServiceMock = new Mock<IBidDataServices>();
            bidServiceMock.Setup(x => x.GetNoOfActiveBidsByUserId(bid.Buyer.Id)).Returns(5);
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();
            userScoreAndLimitsServiceMock.Setup(x => x.GetUserLimitsByUserId(bid.Buyer.Id)).Returns(10);

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.IsFalse(bidServices.AddBid(bid));
        }
    }
}
