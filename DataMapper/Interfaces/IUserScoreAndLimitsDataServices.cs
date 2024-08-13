namespace DataMapper.Interfaces
{
    /// <summary>
    /// The user score and limits data services.
    /// </summary>
    public interface IUserScoreAndLimitsDataServices
    {
        /// <summary>
        /// Gets the user score by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        double GetUserScoreByUserId(int id);
        /// <summary>
        /// Gets the user limits by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        double GetUserLimitsByUserId(int id);
        /// <summary>
        /// Gets the name of the conditional value by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        int GetConditionalValueByName(string name);
    }
}
