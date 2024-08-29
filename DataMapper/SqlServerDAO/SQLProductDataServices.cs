// <copyright file="SQLProductDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.SqlServerDAO
{
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DomainModel.Models;
    using log4net;

    /// <summary>
    /// The product data services.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.IProductDataServices" />
    [ExcludeFromCodeCoverage]
    public class SQLProductDataServices : IProductDataServices
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(Environment.MachineName);

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>bool.</returns>
        public bool AddProduct(Product product)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    product.TerminationDate = product.EndDate;
                    if (context.Categories != null && context.Users != null && context.Products != null)
                    {
                        context.Categories.Attach(product.Category);
                        context.Users.Attach(product.Seller);
                        context.Products.Add(product);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The categories, users or products are null");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while adding new product: " + exception.Message.ToString());
                    return false;
                }
            }

            Logger.Info("Product added successfully!");
            return true;
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>bool.</returns>
        public bool DeleteProduct(Product product)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Products != null)
                    {
                        context.Products.Attach(product);
                        context.Products.Remove(product);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The products is null.");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while deleting product: " + exception.Message.ToString());
                    return false;
                }
            }

            Logger.Info("Product deleted successfully!");
            return true;
        }

        /// <summary>
        /// Gets all product descriptions.
        /// </summary>
        /// <returns>A list with description of the products.</returns>
        public List<string> GetAllProductDescriptions()
        {
            List<string> productDescriptions = new List<string>();

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Products != null)
                {
                    productDescriptions = context.Products.Select((product) => product.Description).ToList();
                }
                else
                {
                    throw new InvalidOperationException("The products is null.");
                }
            }

            return productDescriptions;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>a list of products.</returns>
        public IList<Product> GetAllProducts()
        {
            IList<Product> products = new List<Product>();

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Products != null)
                {
                    products = context.Products.Include("Category").OrderBy((product) => product.Id).ToList();
                }
                else
                {
                    throw new InvalidOperationException("The Products is null.");
                }
            }

            return products;
        }

        /// <summary>
        /// Gets the no of active and future auctions by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>int.</returns>
        public int GetNoOfActiveAndFutureAuctionsByUserId(int id)
        {
            int noOfActiveAndFutureAuctions;

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Products != null)
                {
                    noOfActiveAndFutureAuctions = context.Products.Include("Seller").Where((product) => product.Seller.Id == id && product.TerminationDate > DateTime.Now).Count();
                }
                else
                {
                    throw new InvalidOperationException("The Products is null.");
                }
            }

            return noOfActiveAndFutureAuctions;
        }

        /// <summary>
        /// Gets the no of active auction of user in category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="category">The category.</param>
        /// <param name="newStart">The new start.</param>
        /// <param name="newEnd">The new end.</param>
        /// <returns>int.</returns>
        public int GetNoOfActiveAuctionOfUserInCategory(int id, Category category, DateTime newStart, DateTime newEnd)
        {
            int noOfActiveAuctionsInIntervalInCategory;

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Products != null)
                {
                    noOfActiveAuctionsInIntervalInCategory = context.Products.Include("Category").Where((product) => product.Category.Id == category.Id).Count();
                }
                else
                {
                    throw new InvalidOperationException("The Products is null.");
                }
            }

            return noOfActiveAuctionsInIntervalInCategory;
        }

        /// <summary>
        /// Gets the no of active auctions of user in interval.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newStart">The new start.</param>
        /// <param name="newEnd">The new end.</param>
        /// <returns>int.</returns>
        public int GetNoOfActiveAuctionsOfUserInInterval(int id, DateTime newStart, DateTime newEnd)
        {
            int noOfActiveAuctionsInInterval;

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Products != null)
                {
                    noOfActiveAuctionsInInterval = context.Products.Where((product) => product.Seller.Id == id && newStart <= product.TerminationDate && product.StartDate <= newEnd).Count();
                }
                else
                {
                    throw new InvalidOperationException("The Products is null.");
                }
            }

            return noOfActiveAuctionsInInterval;
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a product.</returns>
        public Product GetProductById(int id)
        {
            Product? product = null;
            using (AuctionContext context = new AuctionContext())
            {
                if (context.Products != null)
                {
                    product = context.Products.Include("Category").Include("Seller").Where((product) => product.Id == id).FirstOrDefault();
                }
                else
                {
                    throw new InvalidOperationException("The Products is null");
                }
            }

            return product!;
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>bool.</returns>
        public bool UpdateProduct(Product product)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Products != null)
                    {
                        context.Products.Attach(product);
                        context.Entry(product).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The Products is null.");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Warn("Error while updating product: " + exception.Message.ToString());
                    return false;
                }
            }

            Logger.Info("Product updated successfully!");
            return true;
        }
    }
}
