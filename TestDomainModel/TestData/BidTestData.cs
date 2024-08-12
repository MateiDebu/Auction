using DomainModel.Enums;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomainModel.TestData
{
    [ExcludeFromCodeCoverage]
    internal class BidTestData
    {
        private ProductTestData productTestData = new ProductTestData();
        private UserTestData userTestData = new UserTestData();
        private decimal validAmount = 1000m;
        private ECurrency validCurrency = ECurrency.EUR;

        
    }
}
