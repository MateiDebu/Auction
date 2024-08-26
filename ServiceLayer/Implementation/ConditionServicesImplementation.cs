using DataMapper.Interfaces;
using DomainModel.Models;
using log4net;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            if(condition == null)
            {
                this.logger.Warn("Attemped to add a null condition.");
                return false;
            }
            var context = new ValidationContext(condition, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            if(!Validator.TryValidateObject(condition, context, results, true))
            {
                this.logger.Warn("Attemped to add an invalid condition. " + String.Join(' ', results));
                return false;
            }

            if(this.conditionDataServices.GetConditionByName(condition.Name) != null)
            {
                this.logger.Warn("Attemped to add an already existing condition.");
                return false;
            }

            return this.conditionDataServices.AddCondition(condition);
        }

        public bool DeleteCondition(Condition condition)
        {
            if(condition == null)
            {
                this.logger.Warn("Attemped to delete a null condition.");
                return false;
            }

            if(this.conditionDataServices.GetConditionById(condition.Id) == null)
            {
                this.logger.Warn("Attemped to delete a nonexisting condition.");
            }

            return this.conditionDataServices.DeleteCondition(condition);
        }

        public IList<Condition> GetAllConditions()
        {
            return this.conditionDataServices.GetAllConditions();
        }

        public Condition GetConditionById(int id)
        {
            return this.conditionDataServices.GetConditionById(id);
        }

        public Condition GetConditionByName(string name)
        {
            return this.conditionDataServices.GetConditionByName(name);
        }

        public bool UpdateCondition(Condition condition)
        {
            if(condition == null)
            {
                this.logger.Warn("Attempted to update a null condition.");
                return false;
            }
            var context = new ValidationContext(condition, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            if(!Validator.TryValidateObject(condition, context, results, true))
            {
                this.logger.Warn("Attempted to update an invalid condition. " + String.Join(' ', results));
                return false;
            }

            if(conditionDataServices.GetConditionById(condition.Id) == null)
            {
                this.logger.Warn("Attemped to update a nonexisting condition.");
                return false;
            }

            if(condition.Name != this.conditionDataServices.GetConditionById(condition.Id).Name && this.conditionDataServices.GetConditionByName(condition.Name) != null)
            {
                this.logger.Warn("Attemped to update a condition by changing the name to an existing condtion name.");
                return false;
            }

            return this.conditionDataServices.UpdateCondition(condition);
        }
    }
}
