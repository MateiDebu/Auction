// <copyright file="CategoryValidation.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestDomainModel.ValidationTests
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Models;
    using NUnit.Framework;
    using TestDomainModel.TestData;

    /// <summary>Test class for <see cref="Category" /> validation.</summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class CategoryValidation
    {
        /// <summary>
        /// The category test data.
        /// </summary>
        private CategoryTestData categoryTestData;

        /// <summary>
        /// The results.
        /// </summary>
        private List<ValidationResult> results = new List<ValidationResult>();

        /// <summary>
        /// Determines whether the given category is valid or not.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>
        ///   <b>true</b> if the given category is valid; otherwise, <b>false</b>.
        /// </returns>
        public bool IsValidCategory(Category category)
        {
            var context = new ValidationContext(category, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool validationResult = Validator.TryValidateObject(category, context, results, true);
            this.results.AddRange(results);
            return validationResult;
        }

        /// <summary>
        /// Called when [time set up].
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.categoryTestData = new CategoryTestData();
        }

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.results = new List<ValidationResult>();
        }

        /// <summary>
        /// Valids the category.
        /// </summary>
        [Test]
        public void ValidCategory()
        {
            Assert.IsTrue(this.IsValidCategory(this.categoryTestData.GetValidCategory()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// Invalids the category empty category.
        /// </summary>
        [Test]
        public void InvalidCategory_EmptyCategory()
        {
            Assert.IsFalse(this.IsValidCategory(this.categoryTestData.GetEmptyCategory()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogCategoryWithNullName));
        }

        /// <summary>
        /// Invalids the category name null.
        /// </summary>
        [Test]

        public void InvalidCategory_Name_Null()
        {
            Assert.IsFalse(this.IsValidCategory(this.categoryTestData.GetCategoryWithNullName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogCategoryWithNullName));
        }

        /// <summary>
        /// Invalids the category name empty.
        /// </summary>
        [Test]
        public void InvalidCategory_Name_Empty()
        {
            Assert.IsFalse(this.IsValidCategory(this.categoryTestData.GetCategoryWithEmptyName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogCategoryWithNullName));
        }

        /// <summary>
        /// Invalids the category name too long.
        /// </summary>
        [Test]
        public void InvalidCategory_Name_TooLong()
        {
            Assert.IsFalse(this.IsValidCategory(this.categoryTestData.GetCategoryWithNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogCategoryWithNameTooLong));
        }

        /// <summary>
        /// Valids the category parent category null.
        /// </summary>
        [Test]
        public void ValidCategory_ParentCategory_Null()
        {
            Assert.IsTrue(this.IsValidCategory(this.categoryTestData.GetCategoryWithNullParent()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }
    }
}
