// <copyright file="SQLCategoryDataServicesTests.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestDataMapper.TestSqlServerDAO
{
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Cryptography.X509Certificates;
    using DataMapper;
    using DataMapper.SqlServerDAO;
    using DomainModel.Models;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// The SQLCategoryDataServicesTests class.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class SQLCategoryDataServicesTests
    {
        /// <summary>
        /// The mock context.
        /// </summary>
        private Mock<AuctionContext> mockContext;

        /// <summary>
        /// The mock database set.
        /// </summary>
        private Mock<DbSet<Category>> mockDbSet;

        /// <summary>
        /// The category data services.
        /// </summary>
        private SQLCategoryDataServices categoryDataServices;

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.mockContext = new Mock<AuctionContext>();
            this.mockDbSet = new Mock<DbSet<Category>>();

            this.mockContext.Setup(m => m.Categories).Returns(this.mockDbSet.Object);

            this.categoryDataServices = new SQLCategoryDataServices(this.mockContext.Object);
        }

        /// <summary>
        /// Adds the category should add category to context and save changes.
        /// </summary>
        [Test]
        public void AddCategory_ShouldAddCategoryToContextAndSaveChanges()
        {
            Category category = new Category("Aparat foto", new Category("Telefon, Electronice mici", null));

            this.mockDbSet.Setup(m => m.Add(It.IsAny<Category>())).Returns((Category c) => c);

            var result = this.categoryDataServices.AddCategory(category);

            this.mockDbSet.Verify(m => m.Add(It.Is<Category>(c => c == category)), Times.Once());
            this.mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Adds the user should return false when add fails.
        /// </summary>
        [Test]
        public void AddUser_ShouldReturnFalse_WhenAddFails()
        {
            Category category = new Category("Aparat foto", new Category("Telefon, Electronice mici", null));

            this.mockDbSet.Setup(m => m.Add(It.IsAny<Category>())).Returns((Category c) => c);
            this.mockContext.Setup(m => m.SaveChanges()).Throws(new Exception());

            var result = this.categoryDataServices.AddCategory(category);

            this.mockDbSet.Verify(m => m.Add(It.Is<Category>(c => c == category)), Times.Once());
            this.mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Deletes the user should remove user from context and save changes.
        /// </summary>
        [Test]
        public void DeleteUser_ShouldRemoveUserFromContextAndSaveChanges()
        {
            Category category = new Category("Aparat foto", new Category("Telefon, Electronice mici", null));

            this.mockDbSet.Setup(m => m.Attach(It.IsAny<Category>())).Returns((Category c) => c);
            this.mockDbSet.Setup(m => m.Remove(It.IsAny<Category>())).Returns((Category c) => c);
            this.mockContext.Setup(m => m.SaveChanges()).Returns(1);

            var result = this.categoryDataServices.DeleteCategory(category);

            this.mockDbSet.Verify(m => m.Attach(It.Is<Category>(c => c == category)), Times.Once());
            this.mockDbSet.Verify(m => m.Remove(It.Is<Category>(c => c == category)), Times.Once());
            this.mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Gets the category by identifier should return correct category.
        /// </summary>
        [Test]
        public void GetCategoryById_ShouldReturnCorrectCategory()
        {
            int categoryId = 1;
            var categoriesList = new List<Category>
            {
                new Category("Aparat foto", new Category("Telefon, Electronice mici", null)) { Id = categoryId },
                new Category("Laptop", null) { Id = 2 },
            }.AsQueryable();

            var mockSet = this.CreateMockDbSet(categoriesList);

            this.mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            var result = this.categoryDataServices.GetCategoryById(categoryId);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(categoryId));
        }

        /// <summary>
        /// Getcategories the by identifier should return null when category does not exist.
        /// </summary>
        [Test]
        public void GetcategoryById_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            int categoryId = 1;
            var categoriesList = new List<Category>
            {
                new Category("Aparat foto", new Category("Telefon, Electronice mici", null)) { Id = categoryId },
                new Category("Laptop", null) { Id = 2 },
            }.AsQueryable();

            var mockSet = this.CreateMockDbSet(categoriesList);

            this.mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            var result = this.categoryDataServices.GetCategoryById(99);

            Assert.IsNull(result);
        }

        /// <summary>
        /// Gets all categories should return correct categories.
        /// </summary>
        [Test]
        public void GetAllCategories_ShouldReturnCorrectCategories()
        {
            var categoriesList = new List<Category>
            {
                new Category("Aparat foto", new Category("Telefon, Electronice mici", null)) { Id = 1 },
                new Category("Laptop", null) { Id = 2 },
            }.AsQueryable();

            var mockSet = this.CreateMockDbSet(categoriesList);

            this.mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            var result = this.categoryDataServices.GetAllCategories();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Name, Is.EqualTo("Aparat foto"));
            Assert.That(result[1].Name, Is.EqualTo("Laptop"));
        }

        /// <summary>
        /// Gets the category by name return the category.
        /// </summary>
        [Test]
        public void GetCategoryByName_ReturnTheCategory()
        {
            string name = "Electronice";
            var categoriesList = new List<Category>
            {
                new Category("Electronice", new Category("Telefon, Electronice mici", null)) { Id = 1 },
                new Category("Laptop", null) { Id = 2 },
            }.AsQueryable();

            var mockSet = this.CreateMockDbSet(categoriesList);

            this.mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            var result = this.categoryDataServices.GetCategoryByName(name);

            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(name));
        }

        /// <summary>
        /// Gets the category by name return null.
        /// </summary>
        [Test]
        public void GetCategoryByName_ReturnNull()
        {
            string name = "NotExist";
            var categoriesList = new List<Category>
            {
                new Category("Aparat foto", new Category("Telefon, Electronice mici", null)) { Id = 1 },
                new Category("Laptop", null) { Id = 2 },
            }.AsQueryable();

            var mockSet = this.CreateMockDbSet(categoriesList);

            this.mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            var result = this.categoryDataServices.GetCategoryByName(name);

            Assert.IsNull(result);
        }

        /// <summary>
        /// Creates the mock database set.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The mockSet.</returns>
        private Mock<DbSet<Category>> CreateMockDbSet(IQueryable<Category> data)
        {
            var mockSet = new Mock<DbSet<Category>>();

            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(m => m.Include(It.IsAny<string>())).Returns(mockSet.Object);

            return mockSet;
        }
    }
}
