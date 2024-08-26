using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using ServiceLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Implementation
{
    /// <summary>
    /// The category services.
    /// </summary>
    /// <seealso cref="ServiceLayer.Interfaces.ICategoryServices" />
    public class CategoryServicesImplementation : ICategoryServices
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));
        /// <summary>
        /// The category data services
        /// </summary>
        private ICategoryDataServices categoryDataServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryServicesImplementation"/> class.
        /// </summary>
        /// <param name="categoryDataServices">The category data services.</param>
        public CategoryServicesImplementation(ICategoryDataServices categoryDataServices)
        {
            this.categoryDataServices = categoryDataServices;
        }

        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool AddCategory(Category category)
        {
            if (category == null)
            {
                this.logger.Warn("Attempted to add a null category.");
                return false;
            }

            var context = new ValidationContext(category, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if(!Validator.TryValidateObject(category, context, results, true))
            {
                this.logger.Warn("Attemted to add an invalid category + " + String.Join(' ', results));
                return false;
            }

            if(this.categoryDataServices.GetCategoryByName(category.Name) != null)
            {
                this.logger.Warn("Attempted to add an already existing category.");
                return false;
            }

            return this.categoryDataServices.AddCategory(category);
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public bool DeleteCategory(Category category)
        {
            if(category == null)
            {
                this.logger.Warn("Attemped to delete a null category.");
                return false;
            }

            if(this.categoryDataServices.GetCategoryById(category.Id) == null)
            {
                this.logger.Warn("Attempted to delete a nonexisting category.");
                return false;
            }
            return this.categoryDataServices.DeleteCategory(category);
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetAllCategories()
        {
            return this.categoryDataServices.GetAllCategories();
        }

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Category GetCategoryById(int id)
        {
            return this.categoryDataServices.GetCategoryById(id);
        }

        /// <summary>
        /// Gets the name of the category by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Category GetCategoryByName(string name)
        {
            return this.categoryDataServices.GetCategoryByName(name);
        }

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public bool UpdateCategory(Category category)
        {
            if(category == null)
            {
                this.logger.Warn("Attempted to update a null category.");
                return false;
            }

            var context = new ValidationContext(category, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            if(!Validator.TryValidateObject(category, context, results, true))
            {
                this.logger.Warn("Attempted to update an invalid category. " + String.Join(' ', results));
                return false;
            }

            if(this.categoryDataServices.GetCategoryById(category.Id) == null)
            {
                this.logger.Warn("Attempted to update a nonexisting category.");
                return false;
            }

            if(category.Name != this.categoryDataServices.GetCategoryById(category.Id).Name && this.categoryDataServices.GetCategoryByName(category.Name) != null)
            {
                this.logger.Warn("Attempted to update a category by changing the name to an existing category name.");
                return false;
            }

            return this.categoryDataServices.UpdateCategory(category);
        }
    }
}
