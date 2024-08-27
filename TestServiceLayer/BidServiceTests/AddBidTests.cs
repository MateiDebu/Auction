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

namespace TestServiceLayer.BidServiceTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class AddBidTests
    {
        [Test]
        public void ADD_NullBid()
        {
            Bid bid = null;
            var bidServiceMock = new Mock<IBidDataServices>();
            var userScoreAndLimitsServiceMock = new Mock<IUserScoreAndLimitsDataServices>();

            var bidServices = new BidServicesImplementation(bidServiceMock.Object, userScoreAndLimitsServiceMock.Object);

            Assert.That(bidServices.AddBid(bid), Is.False);
        }
    }
}
