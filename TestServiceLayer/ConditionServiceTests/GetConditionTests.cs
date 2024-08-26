using DataMapper.Interfaces;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace TestServiceLayer.ConditionServiceTests
{
    /// <summary>
    /// Test class for
    /// <see cref="ConditionServicesImplementation.GetAllConditions()"/>
    /// <see cref="ConditionServicesImplementation.GetConditionById(int)"/> and 
    /// <see cref="ConditionServicesImplementation.GetConditionByName(string)"/> methods.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class GetConditionTests
    {
        /// <summary>
        /// Gets all conditions.
        /// </summary>
        [Test]
        public void GET_AllConditions()
        {
            List<Condition> conditions = GetSampleConditions();

            var conditionServiceMock = new Mock<IConditionDataServices>();
            conditionServiceMock.Setup(x => x.GetAllConditions()).Returns(conditions);
            
            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            var expected = conditions;
            var actual = conditionServices.GetAllConditions();

            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i].Id, Is.EqualTo(expected[i].Id));
                Assert.That(actual[i].Name, Is.EqualTo(expected[i].Name));
                Assert.That(actual[i].Description, Is.EqualTo(expected[i].Description));
                Assert.That(actual[i].Value, Is.EqualTo(expected[i].Value));
            }
        }

        /// <summary>
        /// Gets all condition none found.
        /// </summary>
        [Test]
        public void GET_AllCondition_NoneFound()
        {
            List<Condition> emptyConditionList = new List<Condition>();
            var conditionServiceMock = new Mock<IConditionDataServices>();
            conditionServiceMock.Setup(x=>x.GetAllConditions()).Returns(emptyConditionList);

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);
            Assert.IsEmpty(conditionServices.GetAllConditions());
        }

        /// <summary>
        /// Gets the condition by identifier.
        /// </summary>
        [Test]
        public void GET_ConditionById()
        {
            Condition condition = GetSampleCondition();

            var conditionServiceMock = new Mock<IConditionDataServices>();
            conditionServiceMock.Setup(x => x.GetConditionById(condition.Id)).Returns(condition);

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            var expected = condition;
            var actual = conditionServices.GetConditionById(condition.Id);

            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.Description, Is.EqualTo(expected.Description));
            Assert.That(actual.Value, Is.EqualTo(expected.Value));
        }

        /// <summary>
        /// Gets the condition by identifier not found.
        /// </summary>
        [Test]
        public void GET_ConditionById_NotFound()
        {
            Condition condition = GetSampleCondition();
            Condition nullCondition = null;

            var conditionServiceMock = new Mock<IConditionDataServices>();
            conditionServiceMock.Setup(x => x.GetConditionById(condition.Id)).Returns(nullCondition);
          
            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            Assert.That(conditionServices.GetConditionById(condition.Id), Is.Null);
        }

        /// <summary>
        /// Gets the name of the condition by.
        /// </summary>
        [Test]
        public void GET_ConditionByName()
        {
            Condition condition = GetSampleCondition();

            var conditionServiceMock = new Mock<IConditionDataServices>();
            conditionServiceMock.Setup(x => x.GetConditionByName(condition.Name)).Returns(condition);

            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            var expected = condition;
            var actual = conditionServices.GetConditionByName(condition.Name);

            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.Description, Is.EqualTo(expected.Description));
            Assert.That(actual.Value, Is.EqualTo(expected.Value));
        }

        /// <summary>
        /// Gets the condition by name not found.
        /// </summary>
        [Test]
        public void GET_ConditionByName_NotFound()
        {
            Condition condition = GetSampleCondition();
            Condition nullCondition = null;

            var conditionServiceMock = new Mock<IConditionDataServices>();
            conditionServiceMock.Setup(x => x.GetConditionByName(condition.Name)).Returns(nullCondition);
            
            var conditionServices = new ConditionServicesImplementation(conditionServiceMock.Object);

            Assert.That(conditionServices.GetConditionByName(condition.Name), Is.Null);
        }

        /// <summary>
        /// Gets the sample condition.
        /// </summary>
        /// <returns></returns>
        private static Condition GetSampleCondition()
        {
            return new Condition("X", "x", 42);
        }

        /// <summary>
        /// Gets the sample conditions.
        /// </summary>
        /// <returns></returns>
        private static List<Condition> GetSampleConditions()
        {
            return new List<Condition>
            {
                new Condition("A", "aaa", 1),
                new Condition("B", "bbb", 2),
                new Condition("C", "ccc", 3),
            };
        }
    }
}
