// <copyright file="ProductTestData.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using DomainModel.Enums;
using DomainModel.Models;
using System.Diagnostics.CodeAnalysis;

namespace TestDomainModel.TestData
{
    [ExcludeFromCodeCoverage]
    internal class ProductTestData
    {
        private CategoryTestData categoryTestData = new CategoryTestData();
        private UserTestData userTestData = new UserTestData();
        private string validName = "Aparat foto LEICA";
        private string validDescription = "Are o focalizare foarte rapida.";
        private decimal validStartingPrice = 100m;
        private ECurrency validCurrency = ECurrency.EUR;
        private DateTime validStartDate = DateTime.Today.AddDays(5);
        private DateTime validEndDate = DateTime.Today.AddDays(10);
        private string longName = new string('x', 251);
        private string longDescription = new string('x', 501);
        private decimal negativeStartingPrice = -1m;
        private DateTime invalidEndDate = DateTime.Today;

        public Product GetValidProduct()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetEmptyProduct()
        {
            return new Product();
        }

        public Product GetProductWithNullName()
        {
            return new Product(
                null,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithEmptyName()
        {
            return new Product(
                string.Empty,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNameTooLong()
        {
            return new Product(
                this.longName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNullDescription()
        {
            return new Product(
                this.validName,
                null,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithEmptyDescription()
        {
            return new Product(
                this.validName,
                string.Empty,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithDescriptionTooLong()
        {
            return new Product(
                this.validName,
                this.longDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNullCategory()
        {
            return new Product(
                this.validName,
                this.validDescription,
                null,
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNullCategoryName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetCategoryWithNullName(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithEmptyCategoryName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetCategoryWithEmptyName(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithCategoryNameTooLong()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetCategoryWithNameTooLong(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNegativeStartingPrice()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.negativeStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNullSeller()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                null,
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNullSellerFirstName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNullFirstName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithEmptySellerFirstName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithEmptyFirstName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithSellerFirstNameTooLong()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithFirstNameTooLong(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNoUppercaseLetterInSellerFirstName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNoUppercaseLetterInFirstName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNoLowercaseLetterInSellerFirstName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNoLowercaseLetterInFirstName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithSymbolInSellerFirstName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithSymbolInFirstName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNumberInSellerFirstName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNumberInFirstName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNullSellerLastName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNullLastName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithEmptySellerLastName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithEmptyLastName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithSellerLastNameTooLong()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithLastNameTooLong(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNoUppercaseLetterInSellerLastName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNoUppercaseLetterInLastName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNoLowercaseLetterInSellerLastName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNoLowercaseLetterInLastName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithSymbolInSellerLastName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithSymbolInLastName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNumberInSellerLastName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNumberInLastName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNullSellerUserName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNullUserName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithEmptySellerUserName()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithEmptyUserName(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithSellerUserNameTooLong()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithUserNameTooLong(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNullSellerPhoneNumber()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNullPhoneNumber(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithEmptySellerPhoneNumber()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithEmptyPhoneNumber(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithSellerPhoneNumberTooLong()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithPhoneNumberTooLong(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithInvalidSellerPhoneNumber()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithInvalidPhoneNumber(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNullSellerEmail()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNullEmail(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithEmptySellerEmail()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithEmptyEmail(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithSellerEmailTooLong()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithEmailTooLong(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithInvalidSellerEmail()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithInvalidEmail(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNullSellerPassword()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNullPassword(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithEmptySellerPassword()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithEmptyPassword(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithSellerPasswordTooShort()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithPasswordTooShort(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithSellerPasswordTooLong()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithPasswordTooLong(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNoUppercaseLetterInSellerPassword()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNoUppercaseLetterInPassword(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNoLowercaseLetterInSellerPassword()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNoLowercaseLetterInPassword(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNoNumberInSellerPassword()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNoNumberInPassword(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithNoSymbolInSellerPassword()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetUserWithNoSymbolInPassword(),
                this.validStartDate,
                this.validEndDate);
        }

        public Product GetProductWithEndDateBeforeStartDate()
        {
            return new Product(
                this.validName,
                this.validDescription,
                this.categoryTestData.GetValidCategory(),
                this.validStartingPrice,
                this.validCurrency,
                this.userTestData.GetValidUser(),
                this.validStartDate,
                this.invalidEndDate);
        }
    }
}
