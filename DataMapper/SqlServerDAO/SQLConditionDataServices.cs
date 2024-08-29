// <copyright file="SQLConditionDataServices.cs" company="Transilvania University of Brasov">
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
    /// The condition data services.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.IConditionDataServices" />
    [ExcludeFromCodeCoverage]
    public class SQLConditionDataServices : IConditionDataServices
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(Environment.MachineName);

        /// <inheritdoc/>
        public bool AddCondition(Condition condition)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Conditions != null)
                    {
                        context.Conditions.Add(condition);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The conditions are null.");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while adding new condition: " + exception.Message.ToString());
                    return false;
                }
            }

            Logger.Info("Condition added successfully!");
            return true;
        }

        /// <inheritdoc/>
        public IList<Condition> GetAllConditions()
        {
            IList<Condition> conditions = new List<Condition>();

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Conditions != null)
                {
                    conditions = context.Conditions.OrderBy((condition) => condition.Id).ToList();
                }
                else
                {
                    throw new InvalidOperationException("The Conditions are null.");
                }
            }

            return conditions;
        }

        /// <inheritdoc/>
        public Condition GetConditionById(int id)
        {
            Condition? condition = null;

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Conditions != null)
                {
                    condition = context.Conditions.Where((condition) => condition.Id == id).FirstOrDefault();
                }
                else
                {
                    throw new InvalidOperationException("The Conditions are null");
                }
            }

            return condition!;
        }

        /// <inheritdoc/>
        public Condition GetConditionByName(string name)
        {
            Condition? condition = null;

            using (AuctionContext context = new AuctionContext())
            {
                if (context.Conditions != null)
                {
                    condition = context.Conditions.Where((condition) => condition.Name == name).FirstOrDefault();
                }
                else
                {
                    throw new InvalidOperationException("The conditions are null");
                }
            }

            return condition!;
        }

        /// <inheritdoc/>
        public int GetK()
        {
            Condition condition = this.GetConditionByName("K");

            if (condition != null)
            {
                return condition.Value;
            }
            else
            {
                return 10;
            }
        }

        /// <inheritdoc/>
        public int GetM()
        {
            Condition condition = this.GetConditionByName("M");

            if (condition != null)
            {
                return condition.Value;
            }
            else
            {
                return 5;
            }
        }

        /// <inheritdoc/>
        public int GetS()
        {
            Condition condition = this.GetConditionByName("S");

            if (condition != null)
            {
                return condition.Value;
            }
            else
            {
                return 5;
            }
        }

        /// <inheritdoc/>
        public int GetN()
        {
            Condition condition = this.GetConditionByName("N");

            if (condition != null)
            {
                return condition.Value;
            }
            else
            {
                return 5;
            }
        }

        /// <inheritdoc/>
        public int GetT()
        {
            Condition condition = this.GetConditionByName("T");

            if (condition != null)
            {
                return condition.Value;
            }
            else
            {
                return 20;
            }
        }

        /// <inheritdoc/>
        public bool UpdateCondition(Condition condition)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Conditions != null)
                    {
                        context.Conditions.Attach(condition);
                        context.Entry(condition).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The Conditions are null");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while updating condition: " + exception.Message.ToString());
                    return false;
                }
            }

            Logger.Info("Condition updated successfully!");
            return true;
        }

        /// <inheritdoc/>
        public bool DeleteCondition(Condition condition)
        {
            using (AuctionContext context = new AuctionContext())
            {
                try
                {
                    if (context.Conditions != null)
                    {
                        context.Conditions.Attach(condition);
                        context.Conditions.Remove(condition);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("The Conditions are null");
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error("Error while deleting condition: " + exception.Message.ToString());
                    return false;
                }
            }

            Logger.Info("Condition deleted successfully!");
            return true;
        }
    }
}
