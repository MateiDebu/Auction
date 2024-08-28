// <copyright file="SQLCategoryDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace DataMapper.SqlServerDAO
{
    /// <summary>
    /// The category data services.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.ICategoryDataServices" />
    [ExcludeFromCodeCoverage]
    public class SQLCategoryDataServices : ICategoryDataServices
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(Environment.MachineName);
        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public bool AddCategory(Category category)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if(category.ParentCategory != null)
                    {
                        context.Categories.Attach(category.ParentCategory);
                    }
                    context.Categories.Add(category);
                    context.SaveChanges();
                }catch(Exception exception)
                {
                    Logger.Error("Error while adding new category: " + exception.Message.ToString() + " " + exception.InnerException.ToString());
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
        /// <returns></returns>
        public bool DeleteCategory(Category category)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    context.Categories.Attach(category);
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }catch(Exception exception)
                {
                    Logger.Error("Error while deleting category: " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                    return false;
                }
            }
            Logger.Info("Category deleted successfully!");
            return true;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetAllCategories()
        {
            IList<Category> categories = new List<Category>();

            using(AuctionContext context = new AuctionContext())
            {
                categories = context.Categories.Include("ParentCategory").OrderBy((category) => category.Id).ToList();
            }
            return categories;
        }

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Category GetCategoryById(int id)
        {
            Category category = null;
            using (AuctionContext context = new AuctionContext())
            {
                category = context.Categories.Include("ParentCategory").Where((category) => category.Id == id).FirstOrDefault();
            }
            return category;
        }

        /// <summary>
        /// Gets the name of the category by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Category GetCategoryByName(string name)
        {
            Category category = null;
            using(AuctionContext context = new AuctionContext())
            {
                category = context.Categories.Include("ParentCategory").Where((category) => category.Name == name).FirstOrDefault();
            }
            return category;
        }

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public bool UpdateCategory(Category category)
        {
            using(AuctionContext context = new AuctionContext())
            {
                try
                {
                    context.Categories.Attach(category);
                    context.Entry(category).State = EntityState.Modified;
                    context.SaveChanges();
                }catch(Exception exception)
                {
                    Logger.Error("Error while updating a category: " + exception.Message.ToString() + " " + exception.InnerException.ToString());
                    return false;
                }
            }

            Logger.Info("Category updated successfully!");
            return true;
        }
    }
}
