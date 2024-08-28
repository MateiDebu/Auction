// <copyright file="SQLUserScoreAndLimitsDataServices.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using DataMapper.Interfaces;
using DomainModel.Models;
using System.Diagnostics.CodeAnalysis;

namespace DataMapper.SqlServerDAO
{
    [ExcludeFromCodeCoverage]
    public class SQLUserScoreAndLimitsDataServices : IUserScoreAndLimitsDataServices
    {
        private const double MinScore = 0;
        private const double MaxScore = 10;
        private const int InitialScore = 5;
        private const double IncrementScore = 0.1;
        public int GetConditionalValueByName(string name)
        {
            Condition condition = null;
            using(AuctionContext context = new AuctionContext())
            {
                condition = context.Conditions.Where(condition => condition.Name == name).FirstOrDefault();
            }

            if(condition != null)
            {
                return condition.Value;
            }else
            {
                return -1;
            }
        }

        public double GetUserLimitsByUserId(int id)
        {
            double userScore = GetUserScoreByUserId(id);
            int s = GetConditionalValueByName("S");
            double a = Math.Floor(s / 2.0);
;           double b = s;
            double c = 1;
            double d = GetConditionalValueByName ("T");

            if (userScore < s)
            {
                return 0;
            }else
            {
                double fx = c + ((d - c) / (b - a) * (userScore - a));
                return Math.Round(fx);
            }
        }

        public double GetUserScoreByUserId(int id)
        {
            int n = 5, s = 10;
            List<int> grades = new List<int>();
            using(AuctionContext context = new AuctionContext())
            {
                n = GetConditionalValueByName("N");
                s = GetConditionalValueByName("S");
                grades = context.Ratings.Where((rating) => rating.RatedUser.Id == id).OrderByDescending((rating) => rating.DateAndTime).Select((rating) => rating.Grade).Take(n).ToList();
            }

            if(n == -1)
            {
                n = 5;
            }

            if(s == -1)
            {
                s = InitialScore;
            }

            double averageScore = grades.Any() ? grades.Average() : InitialScore;
            return Math.Clamp(averageScore, MinScore, MaxScore);
        }

       
        
    }
}
