using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class ProductServicesImplementation : IProductServices
    {
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));
        private IProductDataServices productDataServices;
        private IUserScoreAndLimitsDataServices userScoreAndLimitsDataServices;

        public ProductServicesImplementation(IProductDataServices productDataServices, IUserScoreAndLimitsDataServices userScoreAndLimitsDataServices)
        {
            this.productDataServices = productDataServices;
            this.userScoreAndLimitsDataServices = userScoreAndLimitsDataServices;
        }

        public bool AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsTooSimilarToOtherProductDescriptions(string newProductDescription)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
