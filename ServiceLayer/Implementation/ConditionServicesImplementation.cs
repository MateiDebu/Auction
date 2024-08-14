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
    public class ConditionServicesImplementation : IConditionServices
    {
        private ILog logger = LogManager.GetLogger(typeof(UserServicesImplementation));
        private IConditionDataServices conditionDataServices;

        public ConditionServicesImplementation(IConditionDataServices conditionDataServices)
        {
            this.conditionDataServices = conditionDataServices;
        }

        public bool AddCondition(Condition condition)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCondition(Condition condition)
        {
            throw new NotImplementedException();
        }

        public IList<Condition> GetAllConditions()
        {
            throw new NotImplementedException();
        }

        public Condition GetConditionById(int id)
        {
            throw new NotImplementedException();
        }

        public Condition GetConditionByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCondition(Condition condition)
        {
            throw new NotImplementedException();
        }
    }
}
