using DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomainModel.TestData
{
    [ExcludeFromCodeCoverage]
    internal class ProductTestData
    {
        private CategoryTestData categoryTestData = new CategoryTestData();
        private UserTestData userTestData = new UserTestData();
        private string validName = "Aparat foto Leica";
        private string validDescription = "are un zoom foarte bun";
        private decimal validStartingPrice = 100m;
        private ECurrency validCurrency = ECurrency.EUR;
        private DateTime validStartDate = DateTime.Today.AddDays(5);
        private DateTime validEndDate = DateTime.Today.AddDays(10);
        private string longName = new string('a', 251);
        private string longDescription = new string('a', 501);
        private decimal negativeStartingPrice = -1m;
        private DateTime invalidEndDate = DateTime.Today;
    }
}
