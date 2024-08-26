using DataMapper.Interfaces;
using DomainModel.Models;
using Moq;
using NUnit.Framework;
using ServiceLayer.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace TestServiceLayer.CategoryServiceTests
{
    /// <summary>
    /// Test class for <see cref="CategoryServicesImplementation.UpdateCategory(Category)"/> method.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class UpdateCategoryTests
    {
        /// <summary>
        /// Updates the null category.
        /// </summary>
        [Test]
        public void UPDATE_NullCategory()
        {
            Category category = null;

            var serviceMock = new Mock<ICategoryDataServices>();
            var categoryDataServices = new CategoryServicesImplementation(serviceMock.Object);  

            Assert.That(categoryDataServices.UpdateCategory(category), Is.False);
        }

        /// <summary>
        /// Updates the invalid category name null.
        /// </summary>
        [Test]
        public void UPDATE_InvalidCategory_Name_Null()
        {
            Category category = new Category(null, new Category("TV, Audio-Video & Foto", null));

            var serviceMock = new Mock<ICategoryDataServices>();

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.IsFalse(categoryServices.UpdateCategory(category));
        }

        /// <summary>
        /// Updates the invalid category name empty.
        /// </summary>
        [Test]
        public void UPDATE_InvalidCategory_Name_Empty()
        {
            Category category = new Category(string.Empty, new Category("TV, Audio-Video & Foto", null));

            var serviceMock = new Mock<ICategoryDataServices>();

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.UpdateCategory(category), Is.False);
        }

        /// <summary>
        /// Updates the invalid category name too long.
        /// </summary>
        [Test]
        public void UPDATE_InvalidCategory_Name_TooLong()
        {
            Category category = new Category(new string('a', 101), new Category("TV, Audio-Video & Foto", null));

            var serviceMock = new Mock<ICategoryDataServices>();

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.UpdateCategory(category), Is.False);
        }

        /// <summary>
        /// Updates the valid category parent category null.
        /// </summary>
        [Test]
        public void UPDATE_ValidCategory_ParentCategory_Null()
        {
            Category category = new Category("Aparat foto", null);
            Category nullCategory = null;

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryById(category.Id)).Returns(category);
            serviceMock.Setup(x => x.GetCategoryByName(category.Name)).Returns(nullCategory);
            serviceMock.Setup(x => x.UpdateCategory(category)).Returns(true);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.UpdateCategory(category), Is.True);
        }

        /// <summary>
        /// Updates the non existing category.
        /// </summary>
        [Test]
        public void UPDATE_NonExistingCategory()
        {
            Category category = new Category("Aparat foto", new Category("TV, Audio-Video & Foto", null));
            Category nullCategory = null;

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryById(category.Id)).Returns(nullCategory);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.UpdateCategory(category), Is.False);
        }

        /// <summary>
        /// Updates the name of the valid category change name existing category.
        /// </summary>
        [Test]
        public void UPDATE_ValidCategory_ChangeName_ExistingCategoryName()
        {
            Category category = new Category("Aparat foto", new Category("TV, Audio-Video & Foto", null));
            Category category2 = new Category("Aparate foto", new Category("TV, Audio-Video & Foto", null));

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryById(category2.Id)).Returns(category);
            serviceMock.Setup(x => x.GetCategoryByName(category2.Name)).Returns(category2);
            
            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.UpdateCategory(category2), Is.False);
        }

        /// <summary>
        /// Updates the name of the valid category change.
        /// </summary>
        [Test]
        public void UPDATE_ValidCategory_ChangeName()
        {
            Category category = new Category("Aparat foto", new Category("TV, Audio-Video & Foto", null));
            Category category2 = new Category("Aparate foto", new Category("TV, Audio-Video & Foto", null));
            Category nullCategory = null;

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryById(category2.Id)).Returns(category);
            serviceMock.Setup(x => x.GetCategoryByName(category2.Name)).Returns(nullCategory);
            serviceMock.Setup(x => x.UpdateCategory(category2)).Returns(true);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.That(categoryServices.UpdateCategory(category2), Is.True);
        }

        /// <summary>
        /// Updates the valid category.
        /// </summary>
        [Test]
        public void UPDATE_ValidCategory()
        {
            Category category = new Category("Aparat foto", new Category("Telefon, Electronice mici", null));
            Category nullCategory = null;

            var serviceMock = new Mock<ICategoryDataServices>();
            serviceMock.Setup(x => x.GetCategoryById(category.Id)).Returns(category);
            serviceMock.Setup(x => x.GetCategoryByName(category.Name)).Returns(nullCategory);
            serviceMock.Setup(x => x.UpdateCategory(category)).Returns(true);

            var categoryServices = new CategoryServicesImplementation(serviceMock.Object);

            Assert.IsTrue(categoryServices.UpdateCategory(category));
        }
    }
}
