// <copyright file="GetCategoryTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestServiceLayer.CategoryServiceTests
{
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;
    using ServiceLayer.Implementation;

    /// <summary>
    /// Test class for GetCategoryTests.
    /// <see cref="CategoryServicesImplementation.GetAllCategories()"/>
    /// <see cref="CategoryServicesImplementation.GetCategoryById(int)"/> and
    /// <see cref="CategoryServicesImplementation.GetCategoryByName(string)"/> methods.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class GetCategoryTests
    {
        /// <summary>
        /// Gets all categories.
        /// </summary>
        [Test]
        public void GET_AllCategories()
        {
            List<Category> categories = GetSampleCategories();

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetAllCategories()).Returns(categories);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            var expected = categories;
            var actual = categoryServices.GetAllCategories();
            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i].Id, Is.EqualTo(expected[i].Id));
                Assert.That(actual[i].Name, Is.EqualTo(expected[i].Name));
                Assert.That(actual[i].ParentCategory, Is.EqualTo(expected[i].ParentCategory));
            }
        }

        /// <summary>
        /// Gets all categories none found.
        /// </summary>
        [Test]
        public void GET_AllCategories_NoneFound()
        {
            List<Category> emptyCategoryList = new List<Category>();

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetAllCategories()).Returns(emptyCategoryList);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.IsEmpty(categoryServices.GetAllCategories());
        }

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        [Test]
        public void GET_CategoryById()
        {
            Category category = GetSampleCategory();

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryById(category.Id)).Returns(category);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            var expected = category;
            var actual = categoryServices.GetCategoryById(category.Id);

            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.ParentCategory, Is.EqualTo(expected.ParentCategory));
        }

        /// <summary>
        /// Gets the category by identifier not found.
        /// </summary>
        [Test]
        public void GET_CategoryById_NotFound()
        {
            Category category = GetSampleCategory();
            Category? nullCategory = null;

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryById(category.Id)).Returns(nullCategory!);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            var expected = nullCategory;
            var actual = categoryServices.GetCategoryById(category.Id);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Gets the name of the category by.
        /// </summary>
        [Test]
        public void GET_CategoryByName()
        {
            Category category = GetSampleCategory();

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryByName(category.Name)).Returns(category);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            var expected = category;
            var actual = categoryServices.GetCategoryByName(category.Name);

            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.ParentCategory, Is.EqualTo(expected.ParentCategory));
        }

        /// <summary>
        /// Gets the category by name not found.
        /// </summary>
        [Test]
        public void GET_CategoryByName_NotFound()
        {
            Category category = GetSampleCategory();
            Category? nullCategory = null;

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryByName(category.Name)).Returns(nullCategory!);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            var expected = nullCategory;
            var actual = categoryServices.GetCategoryByName(category.Name);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Gets the sample category.
        /// </summary>
        /// <returns>a category.</returns>
        private static Category GetSampleCategory()
        {
            return new Category("Aparat foto", null);
        }

        /// <summary>
        /// Gets the sample categories.
        /// </summary>
        /// <returns>a list of category.</returns>
        private static List<Category> GetSampleCategories()
        {
            return new List<Category>
            {
                new Category("Aparat foto", null),
                new Category("Telefon", null),
            };
        }
    }
}
