// <copyright file="ProductValidation.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

using DomainModel.Models;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TestDomainModel.TestData;

namespace TestDomainModel.ValidationTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class ProductValidation
    {
        private ProductTestData productTestData;
        private List<ValidationResult> results = new List<ValidationResult>();

        /// <summary>Determines whether the given product is valid or not.</summary>
        /// <param name="product">The product.</param>
        /// <returns><b>true</b> if the given product is valid; otherwise, <b>false</b>.</returns>
        private bool IsValidProduct(Product product)
        {
            var context = new ValidationContext(product, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool validationResult = Validator.TryValidateObject(product, context, results, true);
            this.results.AddRange(results);
            return validationResult;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.productTestData = new ProductTestData();
        }

        [TearDown]
        public void TearDown()
        {
            this.results = new List<ValidationResult>();
        }

        /// <summary>Test for valid product.</summary>
        [Test]
        public void ValidProduct()
        {
            Assert.IsTrue(this.IsValidProduct(this.productTestData.GetValidProduct()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>Test for invalid product (product with no data).</summary>
        [Test]
        public void InvalidProduct_EmptyProduct()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetEmptyProduct()));
            Assert.That(this.results.Count, Is.EqualTo(5));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNullName));
            Assert.That(this.results[1].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNullDescription));
            Assert.That(this.results[2].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNullCategory));
            Assert.That(this.results[3].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNullSeller));
            Assert.That(this.results[4].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithEndDateBeforeStartDate));
        }

        /// <summary>Test for invalid product (product with null name).</summary>
        [Test]
        public void InvalidProduct_Name_Null()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNullName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNullName));
        }

        /// <summary>Test for invalid product (product with empty name).</summary>
        [Test]
        public void InvalidProduct_Name_Empty()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithEmptyName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNullName));
        }

        /// <summary>Test for invalid product (product with name too long).</summary>
        [Test]
        public void InvalidProduct_Name_TooLong()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNameTooLong));
        }

        /// <summary>Test for invalid product (product with null description).</summary>
        [Test]
        public void InvalidProduct_Description_Null()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNullDescription()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNullDescription));
        }

        /// <summary>Test for invalid product (product with empty description).</summary>
        [Test]
        public void InvalidProduct_Description_Empty()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithEmptyDescription()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNullDescription));
        }

        /// <summary>Test for invalid product (product with description too long).</summary>
        [Test]
        public void InvalidProduct_Description_TooLong()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithDescriptionTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithDescriptionTooLong));
        }

        /// <summary>Test for invalid product (product with null category).</summary>
        [Test]
        public void InvalidProduct_Category_Null()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNullCategory()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNullCategory));
        }

        /// <summary>Test for invalid product (product with null category name).</summary>
        [Test]
        public void InvalidProduct_InvalidCategory_Name_Null()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNullCategoryName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidCategory));
        }

        /// <summary>Test for invalid product (product with empty category name).</summary>
        [Test]
        public void InvalidProduct_InvalidCategory_Name_Empty()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithEmptyCategoryName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidCategory));
        }

        /// <summary>Test for invalid product (product with category name too long).</summary>
        [Test]
        public void InvalidProduct_InvalidCategory_Name_TooLong()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithCategoryNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidCategory));
        }

        /// <summary>Test for invalid product (product with negative starting price).</summary>
        [Test]
        public void InvalidProduct_StartingPrice_Negative()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNegativeStartingPrice()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNegativeStartingPrice));
        }

        /// <summary>Test for invalid product (product with null seller).</summary>
        [Test]
        public void InvalidProduct_NullSeller()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNullSeller()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithNullSeller));
        }

        /// <summary>Test for invalid product (product with null seller first name).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_FirstName_Null()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNullSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with empty seller first name).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_FirstName_Empty()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithEmptySellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller first name too long).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_FirstName_TooLong()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithSellerFirstNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller first name that doesn't start with an uppercase letter).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_FirstName_NoUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNoUppercaseLetterInSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller first name that only has uppercase letters).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_FirstName_NoLowerCaseLetters()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNoLowercaseLetterInSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller first name that contains symbols).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_FirstName_ContainsSymbol()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithSymbolInSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller first name that contains numbers).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_FirstName_ContainsNumber()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNumberInSellerFirstName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with null seller last name).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_LastName_Null()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNullSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with empty seller last name).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_LastName_Empty()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithEmptySellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller last name too long).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_LastName_TooLong()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithSellerLastNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller last name that doesn't start with an uppercase letter).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_LastName_NoUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNoUppercaseLetterInSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller last name that only has uppercase letters).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_LastName_NoLowerCaseLetters()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNoLowercaseLetterInSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller last name that contains symbols).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_LastName_ContainsSymbol()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithSymbolInSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller last name that contains numbers).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_LastName_ContainsNumber()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNumberInSellerLastName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with null seller username).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_UserName_Null()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNullSellerUserName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with empty seller username).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_UserName_Empty()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithEmptySellerUserName()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller username too long).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_UserName_TooLong()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithSellerUserNameTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for valid product (product with null seller phone number).</summary>
        [Test]
        public void ValidProduct_ValidSeller_PhoneNumber_Null()
        {
            Assert.IsTrue(this.IsValidProduct(this.productTestData.GetProductWithNullSellerPhoneNumber()));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>Test for invalid product (product with empty seller phone number).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_PhoneNumber_Empty()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithEmptySellerPhoneNumber()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller phone number too long).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_PhoneNumber_TooLong()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithSellerPhoneNumberTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with invalid seller phone number).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_PhoneNumber_Invalid()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithInvalidSellerPhoneNumber()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with null seller email address).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Email_Null()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNullSellerEmail()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with empty seller email address).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Email_Empty()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithEmptySellerEmail()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller email address too long).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Email_TooLong()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithSellerEmailTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with invalid seller email address).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Email_Invalid()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithInvalidSellerEmail()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with null seller password).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Password_Null()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNullSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with empty seller password).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Password_Empty()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithEmptySellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller password too short).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Password_TooShort()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithSellerPasswordTooShort()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller password too long).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Password_TooLong()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithSellerPasswordTooLong()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller password that doesn't contain uppercase letters).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Password_MissingUpperCaseLetter()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNoUppercaseLetterInSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller password that doesn't contain lowercase letters).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Password_MissingLowerCaseLetter()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNoLowercaseLetterInSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller password that doesn't contain numbers).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Password_MissingNumber()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNoNumberInSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with seller password that doesn't contain symbols).</summary>
        [Test]
        public void InvalidProduct_InvalidSeller_Password_MissingSymbol()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithNoSymbolInSellerPassword()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithInvalidSeller));
        }

        /// <summary>Test for invalid product (product with auction end date before auction start date).</summary>
        [Test]
        public void InvalidProduct_EndDate_BeforeStartDate()
        {
            Assert.IsFalse(this.IsValidProduct(this.productTestData.GetProductWithEndDateBeforeStartDate()));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogProductWithEndDateBeforeStartDate));
        }
    }
}
