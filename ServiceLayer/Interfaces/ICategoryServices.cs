// <copyright file="ICategoryServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace ServiceLayer.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The categories services.
    /// </summary>
    public interface ICategoryServices
    {
        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>bool.</returns>
        bool AddCategory(Category category);

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>A list of categoryes.</returns>
        IList<Category> GetAllCategories();

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a category.</returns>
        Category GetCategoryById(int id);

        /// <summary>
        /// Gets the name of the category by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>a category by name.</returns>
        Category GetCategoryByName(string name);

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>bool.</returns>
        bool UpdateCategory(Category category);

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>bool.</returns>
        bool DeleteCategory(Category category);
    }
}
