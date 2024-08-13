using DomainModel.Models;

namespace DataMapper.Interfaces
{
    /// <summary>
    /// The condition data services.
    /// </summary>
    public interface IConditionDataServices
    {
        /// <summary>
        /// Adds the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        bool AddCondition(Condition condition);
        /// <summary>
        /// Gets all conditions.
        /// </summary>
        /// <returns></returns>
        IList<Condition> GetAllConditions();
        /// <summary>
        /// Gets the condition by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Condition GetConditionById(int id);
        /// <summary>
        /// Gets the name of the condition by.
        /// </summary>
        /// <param name="conditionName">Name of the condition.</param>
        /// <returns></returns>
        Condition GetConditionByName(string conditionName);
        /// <summary>
        /// Gets the k.
        /// </summary>
        /// <returns></returns>
        int GetK();
        /// <summary>
        /// Gets the m.
        /// </summary>
        /// <returns></returns>
        int GetM();
        /// <summary>
        /// Gets the s.
        /// </summary>
        /// <returns></returns>
        int GetS();
        /// <summary>
        /// Gets the n.
        /// </summary>
        /// <returns></returns>
        int GetN();
        /// <summary>
        /// Gets the t.
        /// </summary>
        /// <returns></returns>
        int GetT();
        /// <summary>
        /// Updates the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        bool UpdateCondition(Condition condition);
        /// <summary>
        /// Deletes the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        bool DeleteCondition(Condition condition);  
    }
}
