// <copyright file="SQLCategoryDataServices.cs" company="Transilvania University of Brasov">
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
    /// The category data services.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.ICategoryDataServices" />
    [ExcludeFromCodeCoverage]
    public class SQLCategoryDataServices : ICategoryDataServices
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(Environment.MachineName);

        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>bool.</returns>
        public bool AddCategory(Category category)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Categories != null && category.ParentCategory != null)
                    {
                        context.Categories.Attach(category.ParentCategory);
                        context.Categories.Add(category);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The categories is null.");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while adding new category: " + exception.Message.ToString());
                    return false;
                }

                Logger.Info("Category added successfully!");
                return true;
            }
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>bool.</returns>
        public bool DeleteCategory(Category category)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Categories != null)
                    {
                        context.Categories.Attach(category);
                        context.Categories.Remove(category);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The categories is null.");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while deleting category: " + exception.Message.ToString());
                    return false;
                }
            }

            Logger.Info("Category deleted successfully!");
            return true;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>A list with all categories.</returns>
        public IList<Category> GetAllCategories()
        {
            IList<Category> categories = new List<Category>();

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Categories != null)
                {
                    categories = context.Categories.Include("ParentCategory").OrderBy((category) => category.Id).ToList();
                }
                else
                {
                    throw new InvalidOperationException("The categories is null.");
                }
            }

            return categories;
        }

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A category.</returns>
        public Category GetCategoryById(int id)
        {
            Category? category = null;
            using (AuctionContext context = new AuctionContext())
            {
                if (context.Categories != null)
                {
                    category = context.Categories.Include("ParentCategory").Where((category) => category.Id == id).FirstOrDefault();
                }
                else
                {
                    throw new InvalidOperationException("The categories is null.");
                }
            }

            return category!;
        }

        /// <summary>
        /// Gets the name of the category by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>a category.</returns>
        public Category GetCategoryByName(string name)
        {
            Category? category = null;
            using (AuctionContext context = new AuctionContext())
            {
                if (context.Categories != null)
                {
                    category = context.Categories.Include("ParentCategory").Where((category) => category.Name == name).FirstOrDefault();
                }
                else
                {
                    throw new InvalidOperationException("The categories is null.");
                }
            }

            return category!;
        }

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>bool.</returns>
        public bool UpdateCategory(Category category)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Categories != null)
                    {
                        context.Categories.Attach(category);
                        context.Entry(category).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The categories is null.");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while updating a category: " + exception.Message.ToString());
                    return false;
                }
            }

            Logger.Info("Category updated successfully!");
            return true;
        }
    }
}
