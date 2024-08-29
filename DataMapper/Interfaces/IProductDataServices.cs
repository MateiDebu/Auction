// <copyright file="IProductDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The product data services.
    /// </summary>
    public interface IProductDataServices
    {
        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>bool.</returns>
        bool AddProduct(Product product);

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>a list of products.</returns>
        IList<Product> GetAllProducts();

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>product.</returns>
        Product GetProductById(int id);

        /// <summary>
        /// Gets the no of active and future auctions by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>int.</returns>
        int GetNoOfActiveAndFutureAuctionsByUserId(int id);

        /// <summary>
        /// Gets the no of active auctions of user in interval.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newStart">The new start.</param>
        /// <param name="newEnd">The new end.</param>
        /// <returns>int.</returns>
        int GetNoOfActiveAuctionsOfUserInInterval(int id, DateTime newStart, DateTime newEnd);

        /// <summary>
        /// Gets the no of active auction of user in category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="category">The category.</param>
        /// <param name="newStart">The new start.</param>
        /// <param name="newEnd">The new end.</param>
        /// <returns>int.</returns>
        int GetNoOfActiveAuctionOfUserInCategory(int id, Category category, DateTime newStart, DateTime newEnd);

        /// <summary>
        /// Gets all product descriptions.
        /// </summary>
        /// <returns>a list.</returns>
        List<string> GetAllProductDescriptions();

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>bool.</returns>
        bool UpdateProduct(Product product);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>bool.</returns>
        bool DeleteProduct(Product product);
    }
}
