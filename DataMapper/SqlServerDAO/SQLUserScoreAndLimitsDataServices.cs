using DataMapper.Interfaces;
using DomainModel.Models;
using System.Diagnostics.CodeAnalysis;

namespace DataMapper.SqlServerDAO
{
    [ExcludeFromCodeCoverage]
    public class SQLUserScoreAndLimitsDataServices : IUserScoreAndLimitsDataServices
    {
        public int GetConditionalValueByName(string name)
        {
            Condition condition = null;
            using(AuctionContext context = new AuctionContext())
            {
                condition = context.Conditions.Where((condition) => condition.Name == name).FirstOrDefault();
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
            int s;
            double userScore, a, b, c, d, fx;

            userScore = GetUserScoreByUserId(id);
            s = GetConditionalValueByName("s");
            a = (double)Math.Floor((decimal)s / 2);
            b = s;
            c = 1;
            d = GetConditionalValueByName ("T");
            decimal threshold = s;
            if((decimal) userScore < Math.Floor(threshold))
            {
                return 0;
            }
            else
            {
                fx = c + ((d - c) / (b - a) * (userScore - a));
                return (int)Math.Round(fx);
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
                s = 5;
            }

            if(grades.Count > 0)
            {
                return grades.Average();
            }
            else
            {
                return s;
            }
        }
    }
}
