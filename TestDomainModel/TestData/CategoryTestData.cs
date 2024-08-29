// <copyright file="CategoryTestData.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestDomainModel.TestData
{
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Models;

    /// <summary>
    /// The CategoryTestData class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class CategoryTestData
    {
        /// <summary>
        /// The valid category name.
        /// </summary>
        private string validCategoryName = "Aparat foto";

        /// <summary>
        /// The empty category name.
        /// </summary>
        private string emptyCategoryName = string.Empty;

        /// <summary>
        /// The too long category name.
        /// </summary>
        private string tooLongCategoryName = new string('x', 101);

        /// <summary>
        /// The valid parent category name.
        /// </summary>
        private string validParentCategoryName = "Aparat foto";

        /// <summary>
        /// Gets the valid category.
        /// </summary>
        /// <returns>category.</returns>
        public Category GetValidCategory()
        {
            return new Category(this.validCategoryName, new Category(this.validParentCategoryName, null));
        }

        /// <summary>
        /// Gets the empty category.
        /// </summary>
        /// <returns>category.</returns>
        public Category GetEmptyCategory()
        {
            return new Category();
        }

        /// <summary>
        /// Gets the name of the category with null.
        /// </summary>
        /// <returns>category.</returns>
        public Category GetCategoryWithNullName()
        {
            return new Category(null, new Category(this.validParentCategoryName, null));
        }

        /// <summary>
        /// Gets the empty name of the category with.
        /// </summary>
        /// <returns>category.</returns>
        public Category GetCategoryWithEmptyName()
        {
            return new Category(this.emptyCategoryName, new Category(this.validParentCategoryName, null));
        }

        /// <summary>
        /// Gets the category with name too long.
        /// </summary>
        /// <returns>category.</returns>
        public Category GetCategoryWithNameTooLong()
        {
            return new Category(this.tooLongCategoryName, new Category(this.validParentCategoryName, null));
        }

        /// <summary>
        /// Gets the category with null parent.
        /// </summary>
        /// <returns>category.</returns>
        public Category GetCategoryWithNullParent()
        {
            return new Category(this.validCategoryName, null);
        }
    }
}
