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
            int numberOfRatings = 0;
            double scoreByRatingUsers = 0;
            double s = InitialScore;
            using (AuctionContext context = new AuctionContext())
            {
                if (context.Ratings != null)
                {
                    numberOfRatings = context.Ratings.Where(user => user.RatedUser.Id == id).Count();
                    scoreByRatingUsers = context.Ratings.Where(user => user.RatedUser.Id == id).Select(rating => rating.Grade).Sum();
                }
                else
                {
                    throw new InvalidOperationException("The Ratings is null.");
                }

                if (numberOfRatings == 0)
                {
                    return s;
                }
                else
                {
                    double incrementTotal = numberOfRatings * IncrementScore;

                    s += incrementTotal + scoreByRatingUsers;

                    if (s >= 0 && s <= 10)
                    {
                        return s;
                    }
                    else
                    {
                        return InitialScore;
                    }
                }
            }
        }
    }
}
