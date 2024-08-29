// <copyright file="SQLUserScoreAndLimitsDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace DataMapper.SqlServerDAO
{
    using System.Diagnostics.CodeAnalysis;
    using DataMapper.Interfaces;
    using DomainModel.Models;

    /// <summary>
    /// The SQLUserScoreAndLimitsDataServices class.
    /// </summary>
    /// <seealso cref="DataMapper.Interfaces.IUserScoreAndLimitsDataServices" />
    [ExcludeFromCodeCoverage]
    public class SQLUserScoreAndLimitsDataServices : IUserScoreAndLimitsDataServices
    {
        /// <summary>
        /// The minimum score.
        /// </summary>
        private const double MinScore = 0;

        /// <summary>
        /// The maximum score.
        /// </summary>
        private const double MaxScore = 10;

        /// <summary>
        /// The initial score.
        /// </summary>
        private const int InitialScore = 5;

        /// <summary>
        /// The increment score.
        /// </summary>
        private const double IncrementScore = 0.1;

        /// <summary>
        /// Gets the name of the conditional value by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>a value.</returns>
        public int GetConditionalValueByName(string name)
        {
            Condition? condition = null;
            using (AuctionContext context = new AuctionContext())
            {
                if (context.Conditions != null)
                {
                    condition = context.Conditions.Where(condition => condition.Name == name).FirstOrDefault();
                }
            }

            if (condition != null)
            {
                return condition.Value;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Gets the user limits by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a limit.</returns>
        public double GetUserLimitsByUserId(int id)
        {
            double userScore = this.GetUserScoreByUserId(id);
            int s = this.GetConditionalValueByName("S");
            double a = Math.Floor(s / 2.0);

            double b = s;
            double c = 1;
            double d = this.GetConditionalValueByName("T");

            if (userScore < s)
            {
                return 0;
            }
            else
            {
                double fx = c + ((d - c) / (b - a) * (userScore - a));
                return Math.Round(fx);
            }
        }

        /// <summary>
        /// Gets the user score by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a score.</returns>
        public double GetUserScoreByUserId(int id)
        {
            int n = 5, s = 10;
            List<int> grades = new List<int>();
            using (AuctionContext context = new AuctionContext())
            {
                n = this.GetConditionalValueByName("N");
                s = this.GetConditionalValueByName("S");
                if (context.Ratings != null)
                {
                    grades = context.Ratings.Where((rating) => rating.RatedUser.Id == id).OrderByDescending((rating) => rating.DateAndTime).Select((rating) => rating.Grade).Take(n).ToList();
                }
            }

            if (n == -1)
            {
                n = 5;
            }

            if (s == -1)
            {
                s = InitialScore;
            }

            double averageScore = grades.Any() ? grades.Average() : InitialScore;
            return Math.Clamp(averageScore, MinScore, MaxScore);
        }
    }
}
