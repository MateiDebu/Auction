// <copyright file="DAOFactoryMethod.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace DataMapper
{
    [ExcludeFromCodeCoverage]
    public static class DAOFactoryMethod
    {
        static DAOFactoryMethod()
        {
            string currentDataProvider = ConfigurationManager.AppSettings["dataProvider"];
            CurrentDAOFactory = string.IsNullOrWhiteSpace(currentDataProvider)
                ? null
                : currentDataProvider.ToLower(culture: CultureInfo.CurrentCulture).Trim() switch 
                { 
                    "sqlserver" => new SQLServerDAOFactory(),
                    _ => new SQLServerDAOFactory(),
                };
        }

        public static IDAOFactory CurrentDAOFactory { get; private set; }
    }
}
