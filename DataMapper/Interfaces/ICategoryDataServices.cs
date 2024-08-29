// <copyright file="ICategoryDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The category data services.
    /// </summary>
    public interface ICategoryDataServices
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
        /// <returns>a list with all categorys.</returns>
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
        /// <returns>a category.</returns>
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
