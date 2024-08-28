// <copyright file="DeleteConditionTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using DataMapper.Interfaces;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace TestServiceLayer.ConditionServiceTests
{
    /// <summary>
    /// Test class for <see cref="ConditionServicesImplementation.DeleteCondition(Condition)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class DeleteConditionTests
    {
        /// <summary>
        /// Deletes the null condition.
        /// </summary>
        [Test]
        public void DELETE_NullCondition()
        {
            Condition condition = null;

            var serviceMock = new Mock<IConditionDataServices>();
            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.DeleteCondition(condition), Is.False);
        }

        /// <summary>
        /// Deletes the no n existing condition.
        /// </summary>
        [Test]
        public void DELETE_NoNExistingCondition()
        {
            Condition condition = new Condition("X", "x", 42);
            Condition nullCondition = null;

            var serviceMock = new Mock<IConditionDataServices>();
            serviceMock.Setup(x => x.GetConditionById(condition.Id)).Returns(nullCondition);

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.DeleteCondition(condition), Is.False);
        }

        /// <summary>
        /// Deletes the valid condition.
        /// </summary>
        [Test]
        public void DELETE_ValidCondition()
        {
            Condition condition = new Condition("X", "x", 42);

            var serviceMock = new Mock<IConditionDataServices>();
            serviceMock.Setup(x => x.GetConditionById(condition.Id)).Returns(condition);
            serviceMock.Setup(x => x.DeleteCondition(condition)).Returns(true);

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.DeleteCondition(condition), Is.True);
        }
    }
}
