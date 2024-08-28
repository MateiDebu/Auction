// <copyright file="ICategoryDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using DomainModel.Models;

namespace DataMapper.Interfaces
{
    /// <summary>
    /// The category data services.
    /// </summary>
    public interface ICategoryDataServices
    {
        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        bool AddCategory(Category category);
        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        IList<Category> GetAllCategories();
        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Category GetCategoryById(int id);
        /// <summary>
        /// Gets the name of the category by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Category GetCategoryByName(string name);
        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        bool UpdateCategory(Category category);
        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        bool DeleteCategory(Category category);
    }
}
