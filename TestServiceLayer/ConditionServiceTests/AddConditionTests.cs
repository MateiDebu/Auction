// <copyright file="AddConditionTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestServiceLayer.ConditionServiceTests
{
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;
    using ServiceLayer.Implementation;

    /// <summary>
    /// Test class for <see cref="ConditionServicesImplementation.AddCondition(Condition)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class AddConditionTests
    {
        /// <summary>
        /// Adds the null condition.
        /// </summary>
        [Test]
        public void ADD_NullCondition()
        {
            Condition? nullCondition = null;
            var conditionServiceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            Assert.That(conditionServices.AddCondition(nullCondition!), Is.False);
        }

        /// <summary>
        /// Adds the invalid condition name null.
        /// </summary>
        [Test]
        public void ADD_InvalidCondition_Name_Null()
        {
            Condition condition = new Condition(null!, "description", 10);
            var conditionServiceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            Assert.That(conditionServices.AddCondition(condition), Is.False);
        }

        /// <summary>
        /// Adds the invalid condition name too long.
        /// </summary>
        [Test]
        public void ADD_InvalidCondition_Name_TooLong()
        {
            Condition condition = new Condition(new string('x', 16), "description", 10);

            var conditionServiceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            Assert.IsFalse(conditionServices.AddCondition(condition));
        }

        /// <summary>
        /// Adds the invalid condition description null.
        /// </summary>
        [Test]
        public void ADD_InvalidCondition_Description_Null()
        {
            Condition condition = new Condition("X", null!, 10);

            var conditionServiceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            Assert.IsFalse(conditionServices.AddCondition(condition));
        }

        /// <summary>
        /// Adds the invalid condition description empty.
        /// </summary>
        [Test]
        public void ADD_InvalidCondition_Description_Empty()
        {
            Condition condition = new Condition("X", string.Empty, 10);

            var conditionServiceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            Assert.IsFalse(conditionServices.AddCondition(condition));
        }

        /// <summary>
        /// Adds the invalid condition description too long.
        /// </summary>
        [Test]
        public void ADD_InvalidCondition_Description_TooLong()
        {
            Condition condition = new Condition("X", new string('x', 101), 10);

            var conditionServiceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            Assert.IsFalse(conditionServices.AddCondition(condition));
        }

        /// <summary>
        /// Adds the valid condition existing condition.
        /// </summary>
        [Test]
        public void ADD_ValidCondition_ExistingCondition()
        {
            Condition condition = new Condition("X", "x", 42);

            var conditionServiceMock = new Mock<IConditionDataServices>();
            conditionServiceMock.Setup(x => x.GetConditionByName(condition.Name)).Returns(condition);

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            Assert.IsFalse(conditionServices.AddCondition(condition));
        }

        /// <summary>
        /// Adds the valid condition.
        /// </summary>
        [Test]
        public void ADD_ValidCondition()
        {
            Condition condition = new Condition("X", "x", 42);
            Condition? nullCondition = null;

            var conditionServiceMock = new Mock<IConditionDataServices>();
            conditionServiceMock.Setup(x => x.GetConditionByName(condition.Name)).Returns(nullCondition!);
            conditionServiceMock.Setup(x => x.AddCondition(condition)).Returns(true);

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            Assert.IsTrue(conditionServices.AddCondition(condition));
        }
    }
}
