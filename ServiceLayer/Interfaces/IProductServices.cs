// <copyright file="IProductServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace ServiceLayer.Interfaces
{
    using DomainModel.Models;

    /// <summary>
    /// The product services.
    /// </summary>
    public interface IProductServices
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
        /// Determines whether [is too similar to other product descriptions] [the specified new product description].
        /// </summary>
        /// <param name="newProductDescription">The new product description.</param>
        /// <returns>
        ///   <c>true</c> if [is too similar to other product descriptions] [the specified new product description]; otherwise, <c>false</c>.
        /// </returns>
        bool IsTooSimilarToOtherProductDescriptions(string newProductDescription);

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
