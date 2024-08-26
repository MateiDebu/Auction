using DataMapper.Interfaces;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace TestServiceLayer.ConditionServiceTests
{
    /// <summary>
    /// Test class for <see cref="ConditionServicesImplementation.UpdateCondition(Condition)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class UpdateConditionTests
    {
        /// <summary>
        /// Updates the null condition.
        /// </summary>
        [Test]
        public void UPDATE_NullCondition()
        {
            Condition condition = null;
            var serviceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.UpdateCondition(condition), Is.False);
        }

        /// <summary>
        /// Updates the invalid condition name null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidCondition_Name_Null()
        {
            Condition condition = new Condition(null, "description", 10);
            var serviceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.UpdateCondition(condition), Is.False);
        }

        /// <summary>
        /// Updates the invalid condition name empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidCondition_Name_Empty()
        {
            Condition condition = new Condition(String.Empty, "description", 10);
            var serviceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.UpdateCondition(condition), Is.False);
        }

        /// <summary>
        /// Updates the invalid condition name too long.
        /// </summary>
        [Test]
        public void UPDATE_InvalidCondition_Name_TooLong()
        {
            Condition condition = new Condition(new String('a', 16), "description", 10);
            var serviceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.UpdateCondition(condition), Is.False);
        }

        /// <summary>
        /// Updates the invalid condition description null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidCondition_Description_Null()
        {
            Condition condition = new Condition("X", null, 10);
            var serviceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.UpdateCondition(condition), Is.False);
        }

        /// <summary>
        /// Updates the invalid condition description empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidCondition_Description_Empty()
        {
            Condition condition = new Condition("X", String.Empty, 10);
            var serviceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.UpdateCondition(condition), Is.False);
        }

        /// <summary>
        /// Updates the invalid condition description too long.
        /// </summary>
        [Test]
        public void UPDATE_InvalidCondition_Description_TooLong()
        {
            Condition condition = new Condition("X", new String('s', 101), 10);
            var serviceMock = new Mock<IConditionDataServices>();

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.UpdateCondition(condition), Is.False);
        }

        /// <summary>
        /// Updates the non existing condition.
        /// </summary>
        [Test]
        public void UPDATE_NonExistingCondition()
        {
            Condition condition = new Condition("X", "x", 42);
            Condition nullCondition = null;

            var serviceMock = new Mock<IConditionDataServices>();
            serviceMock.Setup(x => x.GetConditionById(condition.Id)).Returns(nullCondition);

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);
            Assert.That(conditionServices.UpdateCondition(condition), Is.False);
        }

        /// <summary>
        /// Updates the name of the valid condition change name existing condition.
        /// </summary>
        [Test]
        public void UPDATE_ValidCondition_ChangeName_ExistingConditionName()
        {
            Condition condition = new Condition("X", "x", 42);
            Condition condition2 = new Condition("Y", "x", 42);

            var serviceMock = new Mock<IConditionDataServices>();
            serviceMock.Setup(x => x.GetConditionById(condition2.Id)).Returns(condition);
            serviceMock.Setup(x=>x.GetConditionByName(condition2.Name)).Returns(condition2);

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.UpdateCondition(condition2), Is.False);
        }

        /// <summary>
        /// Updates the name of the valid condition change.
        /// </summary>
        [Test]
        public void UPDATE_ValidCondition_ChangeName()
        {
            Condition condition = new Condition("X", "x", 42);
            Condition condition2 = new Condition("Y", "x", 42);
            Condition nullCondition = null;

            var serviceMock = new Mock<IConditionDataServices>();
            serviceMock.Setup(x => x.GetConditionById(condition.Id)).Returns(condition);
            serviceMock.Setup(x => x.GetConditionByName(condition2.Name)).Returns(nullCondition);
            serviceMock.Setup(x => x.UpdateCondition(condition2)).Returns(true);

            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.UpdateCondition(condition2), Is.True);
        }

        /// <summary>
        /// Updates the valid condition.
        /// </summary>
        [Test]
        public void UPDATE_ValidCondition()
        {
            Condition condition = new Condition("X", "x", 42);

            var serviceMock = new Mock<IConditionDataServices>();
            serviceMock.Setup(x => x.GetConditionById(condition.Id)).Returns(condition);
            serviceMock.Setup(x => x.UpdateCondition(condition)).Returns(true);
           
            var conditionServices = new ConditionServicesImplementation(serviceMock.Object);

            Assert.That(conditionServices.UpdateCondition(condition), Is.True);
        }
    }
}
