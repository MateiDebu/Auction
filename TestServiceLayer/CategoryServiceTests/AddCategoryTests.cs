using DataMapper.Interfaces;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace TestServiceLayer.CategoryServiceTests
{
    /// <summary>
    /// The class for <see cref="CategoryServicesImplementation.AddCategory(Category)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class AddCategoryTests
    {
        /// <summary>
        /// Adds the null category.
        /// </summary>
        [Test]
        public void ADD_NullCategory()
        {
            Category category = null;
            var serviceMock = new Mock<ICategoryDataServices>();

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.AddCategory(category), Is.False);
        }

        /// <summary>
        /// Adds the invalid category name null.
        /// </summary>
        [Test]
        public void ADD_InvalidCategory_Name_Null()
        {
            Category category = new Category(null, new Category("Telefon, Electronice mici", null));

            var serviceMock = new Mock<ICategoryDataServices>();

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.AddCategory(category), Is.False);
        }

        /// <summary>
        /// Adds the invalid category name empty.
        /// </summary>
        [Test]
        public void ADD_InvalidCategory_Name_Empty()
        {
            Category category = new Category(String.Empty, new Category("Telefon, Electronice mici", null));

            var serviceMock = new Mock<ICategoryDataServices>();

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.AddCategory(category), Is.False);
        }

        /// <summary>
        /// Adds the invalid category name too long.
        /// </summary>
        [Test]
        public void ADD_InvalidCategory_Name_TooLong()
        {
            Category category = new Category(new String('a', 101), new Category("Telefon, Electronice mici", null));

            var serviceMock = new Mock<ICategoryDataServices>();

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.AddCategory(category), Is.False);
        }

        /// <summary>
        /// Adds the valid category parent category null.
        /// </summary>
        [Test]
        public void ADD_ValidCategory_ParentCategory_Null()
        {
            Category category = new Category("Aparat foto", null);

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.AddCategory(category)).Returns(true);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.AddCategory(category));
        }

        /// <summary>
        /// Adds the valid category existingcategory.
        /// </summary>
        [Test]
        public void ADD_ValidCategory_Existingcategory()
        {
            Category category = new Category("Aparat foto", null);

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryByName(category.Name)).Returns(category);
           

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.AddCategory(category), Is.False);
            
        }

        /// <summary>
        /// Adds the valid category.
        /// </summary>
        [Test]
        public void ADD_ValidCategory()
        {
            Category category = new Category("Aparat foto", null);
            Category nullCategory = null;

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryByName(category.Name)).Returns(nullCategory);
            serviceMock.Setup(x => x.AddCategory(category)).Returns(true);
           
            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.AddCategory(category), Is.True);
        }
    }
}
