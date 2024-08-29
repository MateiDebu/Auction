// <copyright file="ProductTestData.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

namespace TestDomainModel.TestData
{
    using System.Diagnostics.CodeAnalysis;
    using DomainModel.Enums;
    using DomainModel.Models;

    /// <summary>
    /// The ProductTestData.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class ProductTestData
    {
        /// <summary>
        /// The category test data.
        /// </summary>
        private CategoryTestData categoryTestData = new CategoryTestData();

        /// <summary>
        /// The user test data.
        /// </summary>
        private UserTestData userTestData = new UserTestData();

        /// <summary>
        /// The valid name.
        /// </summary>
        private string validName = "Aparat foto LEICA";

        /// <summary>
        /// The valid description.
        /// </summary>
        private string validDescription = "Are o focalizare foarte rapida.";

        /// <summary>
        /// The valid starting price.
        /// </summary>
        private decimal validStartingPrice = 100m;

        /// <summary>
        /// The valid currency.
        /// </summary>
        private ECurrency validCurrency = ECurrency.EUR;

        /// <summary>
        /// The valid start date.
        /// </summary>
        private DateTime validStartDate = DateTime.Today.AddDays(5);

        /// <summary>
        /// The valid end date.
        /// </summary>
        private DateTime validEndDate = DateTime.Today.AddDays(10);

        /// <summary>
        /// The long name.
        /// </summary>
        private string longName = new string('x', 251);

        /// <summary>
        /// The long description.
        /// </summary>
        private string longDescription = new string('x', 501);

        /// <summary>
        /// The negative starting price.
        /// </summary>
        private decimal negativeStartingPrice = -1m;

        /// <summary>
        /// The invalid end date.
        /// </summary>
        private DateTime invalidEndDate = DateTime.Today;

        /// <summary>
        /// Gets the valid product.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the empty product.
        /// </summary>
        /// <returns>product.</returns>
        public Product GetEmptyProduct()
        {
            return new Product();
        }

        /// <summary>
        /// Gets the name of the product with null.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the empty name of the product with.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with name too long.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with null description.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with empty description.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with description too long.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with null category.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the name of the product with null category.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the name of the product with empty category.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with category name too long.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with negative starting price.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with null seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the first name of the product with null seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the first name of the product with empty seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with seller first name too long.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the first name of the product with no uppercase letter in seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the first name of the product with no lowercase letter in seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the first name of the product with symbol in seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the first name of the product with number in seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the last name of the product with null seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the last name of the product with empty seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with seller last name too long.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the last name of the product with no uppercase letter in seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the last name of the product with no lowercase letter in seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the last name of the product with symbol in seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the last name of the product with number in seller.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the name of the product with null seller user.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the name of the product with empty seller user.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with seller user name too long.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with null seller phone number.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with empty seller phone number.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with seller phone number too long.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with invalid seller phone number.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with null seller email.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with empty seller email.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with seller email too long.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with invalid seller email.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with null seller password.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with empty seller password.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with seller password too short.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with seller password too long.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with no uppercase letter in seller password.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with no lowercase letter in seller password.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with no number in seller password.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with no symbol in seller password.
        /// </summary>
        /// <returns>product.</returns>
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

        /// <summary>
        /// Gets the product with end date before start date.
        /// </summary>
        /// <returns>product.</returns>
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
