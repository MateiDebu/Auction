// <copyright file="DeleteCategoryTests.cs" company="Transilvania University of Brasov">
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
    /// Test class for <see cref="CategoryServicesImplementation.DeleteCategory(Category)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class DeleteCategoryTests
    {
        /// <summary>
        /// Deletes the null category.
        /// </summary>
        [Test]
        public void DELETE_NullCategory()
        {
            Category? category = null;

            var serviceMock = new Mock<ICategoryDataServices>();

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.DeleteCategory(category!), Is.False);
        }

        /// <summary>
        /// Deletes the no n existing category.
        /// </summary>
        [Test]
        public void DELETE_NoNExistingCategory()
        {
            Category category = new Category("Aparat foto", new Category("Telefon, Electronice mici", null));
            Category? nullCategory = null;

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryById(category.Id)).Returns(nullCategory!);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.DeleteCategory(category), Is.False);
        }

        /// <summary>
        /// Deletes the valid category.
        /// </summary>
        [Test]
        public void DELETE_ValidCategory()
        {
            Category category = new Category("Aparat foto", new Category("Telefon, Electronice mici", null));

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryById(category.Id)).Returns(category);
            serviceMock.Setup(x => x.DeleteCategory(category)).Returns(true);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.DeleteCategory(category), Is.True);
        }
    }
}
