// <copyright file="ProductServicesImplementation.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace ServiceLayer.Implementation
{
    using System.ComponentModel.DataAnnotations;
    using DataMapper.Interfaces;
    using DomainModel.Models;
    using log4net;
    using ServiceLayer.Interfaces;

    /// <summary>
    /// The product services.
    /// </summary>
    /// <seealso cref="ServiceLayer.Interfaces.IProductServices" />
    public class ProductServicesImplementation : IProductServices
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));

        /// <summary>
        /// The product data services.
        /// </summary>
        private IProductDataServices productDataServices;

        /// <summary>
        /// The user score and limits data services.
        /// </summary>
        private IUserScoreAndLimitsDataServices userScoreAndLimitsDataServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductServicesImplementation"/> class.
        /// </summary>
        /// <param name="productDataServices">The product data services.</param>
        /// <param name="userScoreAndLimitsDataServices">The user score and limits data services.</param>
        public ProductServicesImplementation(IProductDataServices productDataServices, IUserScoreAndLimitsDataServices userScoreAndLimitsDataServices)
        {
            this.productDataServices = productDataServices;
            this.userScoreAndLimitsDataServices = userScoreAndLimitsDataServices;
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>bool.</returns>
        public bool AddProduct(Product product)
        {
            if (product == null)
            {
                this.logger.Warn("Attempted to add a null product.");
                return false;
            }

            var context = new ValidationContext(product, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(product, context, results, true))
            {
                this.logger.Warn("Attempted to add an invalid product. " + string.Join(' ', results));
                return false;
            }

            if (this.productDataServices.GetNoOfActiveAndFutureAuctionsByUserId(product.Seller.Id) >= this.userScoreAndLimitsDataServices.GetUserLimitsByUserId(product.Seller.Id))
            {
                this.logger.Warn("Attempted to create too many auctions.");
                return false;
            }

            if (this.productDataServices.GetNoOfActiveAuctionsOfUserInInterval(product.Seller.Id, product.StartDate, product.TerminationDate)
                >= this.userScoreAndLimitsDataServices.GetConditionalValueByName("K"))
            {
                this.logger.Warn("Attempted to create too many active auctions at the same time.");
                return false;
            }

            if (this.productDataServices.GetNoOfActiveAuctionOfUserInCategory(product.Seller.Id, product.Category, product.StartDate, product.TerminationDate)
                >= this.userScoreAndLimitsDataServices.GetConditionalValueByName("M"))
            {
                this.logger.Warn("Attempted to create too many active auctions at the same time in the same category.");
                return false;
            }

            if (this.IsTooSimilarToOtherProductDescriptions(product.Description))
            {
                this.logger.Warn("Attempted to create a product with a description too similar to existing product descriptions.");
                return false;
            }

            return this.productDataServices.AddProduct(product);
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>bool.</returns>
        public bool DeleteProduct(Product product)
        {
            if (product == null)
            {
                this.logger.Warn("Attempted to delete a null product.");
                return false;
            }

            if (this.productDataServices.GetProductById(product.Id) == null)
            {
                this.logger.Warn("Attempted to delete a nonexisting product.");
                return false;
            }

            return this.productDataServices.DeleteProduct(product);
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>a list of products.</returns>
        public IList<Product> GetAllProducts()
        {
            return this.productDataServices.GetAllProducts();
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a product by id.</returns>
        public Product GetProductById(int id)
        {
            return this.productDataServices.GetProductById(id);
        }

        /// <summary>
        /// Determines whether [is too similar to other product descriptions] [the specified new product description].
        /// </summary>
        /// <param name="newProductDescription">The new product description.</param>
        /// <returns>
        ///   <c>true</c> if [is too similar to other product descriptions] [the specified new product description]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTooSimilarToOtherProductDescriptions(string newProductDescription)
        {
            List<string> productDescriptions = this.productDataServices.GetAllProductDescriptions();
            int l = this.userScoreAndLimitsDataServices.GetConditionalValueByName("L");

            foreach (string productDescription in productDescriptions)
            {
                int n = newProductDescription.Length;
                int m = productDescription.Length;
                int[,] d = new int[n + 1, m + 1];

                for (int i = 0; i <= n; d[i, 0] = i++)
                {
                }

                for (int j = 0; j <= m; d[0, j] = j++)
                {
                }

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        int cost = (productDescription[j - 1] == newProductDescription[i - 1]) ? 0 : 1;
                        d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                    }
                }

                if (d[n, m] < l)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>bool.</returns>
        public bool UpdateProduct(Product product)
        {
            if (product == null)
            {
                this.logger.Warn("Attempted to update a null product.");
                return false;
            }

            var context = new ValidationContext(product, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(product, context, results, true))
            {
                this.logger.Warn("Attempted to update an invalid product. " + string.Join(' ', results));
                return false;
            }

            if (this.productDataServices.GetProductById(product.Id) == null)
            {
                this.logger.Warn("Attempted to update a nonexisting product.");
                return false;
            }

            if (this.IsTooSimilarToOtherProductDescriptions(product.Description))
            {
                this.logger.Warn("Attempted to update a product with a description too similar to existing product descriptions.");
                return false;
            }

            return this.productDataServices.UpdateProduct(product);
        }
    }
}
