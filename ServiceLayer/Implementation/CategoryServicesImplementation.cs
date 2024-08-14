using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Implementation
{
    public class CategoryServicesImplementation : ICategoryServices
    {
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));
        private ICategoryDataServices categoryDataServices;

        public CategoryServicesImplementation(ICategoryDataServices categoryDataServices)
        {
            this.categoryDataServices = categoryDataServices;
        }

        public bool AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
