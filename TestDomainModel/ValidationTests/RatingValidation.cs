using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using DomainModel.Enums;
using DomainModel.Models;
using NUnit.Framework;
using TestDomainModel.TestData;

namespace ModelValidationTests
{
    /// <summary>
    ///     Test class for <see cref="Rating"/> validation.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class RatingValidation
    {
        private Rating rating;
        private List<ValidationResult> results = new List<ValidationResult>();

        /// <summary>Determines whether the given rating is valid or not.</summary>
        /// <param name="rating">The rating.</param>
        /// <returns><b>true</b> if the given rating is valid; otherwise, <b>false</b>.</returns>
        public bool IsValidRating(Rating rating)
        {
            var context = new ValidationContext(rating, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool validationResult = Validator.TryValidateObject(rating, context, results, true);
            this.results.AddRange(results);
            return validationResult;
        }

        /// <summary>Creates a valid <see cref="Rating"/> object to be used for testing.</summary>
        [SetUp]
        public void SetUp()
        {
            this.rating = new Rating(
                new Product(
                    "Aparat foto LEICA",
                    "focalizeaza repede",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            this.results = new List<ValidationResult>();
        }

        /// <summary>Test for valid rating.</summary>
        [Test]
        public void ValidRating()
        {
            Assert.IsTrue(this.IsValidRating(this.rating));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>Test for invalid rating (rating with no data).</summary>
        [Test]
        public void InvalidRating_EmptyRating()
        {
            Rating rating = new Rating();

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(3));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithNullProduct));
            Assert.That(this.results[1].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithNullRatingUser));
            Assert.That(this.results[2].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithNullRatedUser));
        
        }

        /// <summary>Test for invalid rating (rating with null product).</summary>
        [Test]
        public void InvalidRating_NullProduct()
        {
            Rating rating = new Rating(
                null,
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithNullProduct));
        }

        /// <summary>Test for invalid rating (rating with null product name).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_Name_Null()
        {
            Rating rating = new Rating(
                new Product(
                    null,
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with empty product name).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_Name_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    string.Empty,
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product name too long).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_Name_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    new string('x', 251),
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with null product description).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_Description_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    null,
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with empty product description).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_Description_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    string.Empty,
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product description too long).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_Description_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    new string('x', 501),
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with null product category).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_Category_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    null,
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with null product category name).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidCategory_Name_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with empty product category name).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidCategory_Name_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(string.Empty, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product category name too long).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidCategory_Name_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(new string('x', 101), null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with negative product starting price).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_StartingPrice_Negative()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    -1,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with null product seller).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_NullSeller()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    null,
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with null product seller first name).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_FirstName_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User(null, "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with empty product seller first name).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_FirstName_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User(string.Empty, "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller first name too long).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_FirstName_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User('X' + new string('x', 16), "Matei", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller first name that doesn't start with an uppercase letter).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_FirstName_NoUpperCaseLetter()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User(new string('x', 10), "Matei", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller first name that only has uppercase letters).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_FirstName_NoLowerCaseLetters()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User(new string('X', 10), "Matei", "DDMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller first name that contains symbols).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_FirstName_ContainsSymbol()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Mate!i", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller first name that contains numbers).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_FirstName_ContainsNumber()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei1", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with null product seller last name).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_LastName_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", null, "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with empty product seller last name).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_LastName_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", string.Empty, "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller last name too long).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_LastName_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", 'X' + new string('x', 16), "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller last name that doesn't start with an uppercase letter).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_LastName_NoUpperCaseLetter()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", new string('x', 10), "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller last name that contains symbols).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_LastName_ContainsSymbol()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Deb!", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with null product seller username).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_UserName_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", null, "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with empty product seller username).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_UserName_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", string.Empty, "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller username too long).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_UserName_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", new string('x', 31), "0123456789", "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for valid rating (rating with null product seller phone number).</summary>
        [Test]
        public void ValidRating_InvalidProduct_InvalidSeller_PhoneNumber_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", null, "mateidebu@yahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsTrue(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>Test for invalid rating (rating with null product seller email address).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Email_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                     new User("Matei", "Debu", "DebuMatei20", "0123456789", null, "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with empty product seller email address).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Email_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", string.Empty, "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller email address too long).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Email_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", new string('x', 30) + '@' + new string('x', 30), "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with invalid product seller email address).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Email_Invalid()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateiyahoo.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with null product seller password).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Password_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", null),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with empty product seller password).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Password_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", string.Empty),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller password too short).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Password_TooShort()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "A#a1"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller password too long).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Password_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "A#a1" + new string('x', 20)),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller password that doesn't contain uppercase letters).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Password_MissingUpperCaseLetter()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "p@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller password that doesn't contain lowercase letters).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Password_MissingLowerCaseLetter()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@SSWORD123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller password that doesn't contain numbers).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Password_MissingNumber()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "P@ssword"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product seller password that doesn't contain symbols).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_InvalidSeller_Password_MissingSymbol()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with product auction end date before auction start date).</summary>
        [Test]
        public void InvalidRating_InvalidProduct_EndDate_BeforeStartDate()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category(null, null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password1!23"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today),
                new User("Andrei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidProduct));
        }

        /// <summary>Test for invalid rating (rating with null rating user).</summary>
        [Test]
        public void InvalidRating_NullRatingUser()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                    null,
                    new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword!123"),
                    7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithNullRatingUser));
        }

        /// <summary>Test for invalid rating (rating with null rating user first name).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_FirstName_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User(null, "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with empty rating user first name).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_FirstName_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User(string.Empty, "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with rating user first name too long).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_FirstName_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User('A' + new string('a', 16), "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with rating user first name that doesn't start with an uppercase letter).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_FirstName_NoUpperCaseLetter()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User(new string('x', 10), "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with rating user first name that only has uppercase letters).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_FirstName_NoLowerCaseLetters()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User(new string('A', 10), "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with rating user first name that contains symbols).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_FirstName_ContainsSymbol()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("A!drei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with rating user first name that contains numbers).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_FirstName_ContainsNumber()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Ad1rei", "Vladut", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with null rating user last name).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_LastName_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Passwor!d123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", null, "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DDMatei20", "0123456789", " mateidebu@yahoo.com", "P@ssword!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with empty rating user last name).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_LastName_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", string.Empty, "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with rating user last name too long).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_LastName_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Passwor!d123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", 'X' + new string('x', 16), "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password1!23"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with rating user last name that doesn't start with an uppercase letter).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_LastName_NoUpperCaseLetters()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password1!23"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", new string('x', 10), "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password1!23"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with rating user last name that only has uppercase letters).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_LastName_NoLowerCaseLetters()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Passwor!d123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", new string('X', 10), "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with rating user last name that contains symbols).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_LastName_ContainsSymbol()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "@Vlad", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with rating user last name that contains numbers).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_LastName_ContainsNumber()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "4Vlad", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with null rating user username).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_UserName_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", null, null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for valid rating (rating with null rating user phone number).</summary>
        [Test]
        public void ValidRating_ValidRatingUser_PhoneNumber_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                   new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr", null, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                7);

            Assert.IsTrue(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(0));
        }

        /// <summary>Test for invalid rating (rating with empty rating user phone number).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_PhoneNumber_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr", string.Empty, "vlad.andrei@gmail.com", "P@rola123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with null rating user email address).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_Email_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr", null, null, "P@rola123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        /// <summary>Test for invalid rating (rating with null rating user password).</summary>
        [Test]
        public void InvalidRating_InvalidRatingUser_Password_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr", null, "vladAndrei@gmail.com", null),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatingUser));
        }

        [Test]
        public void InvalidRating_RatedUser_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password!123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                 new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                 null,
                 7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithNullRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_FirstName_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User(null, "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_FirstName_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User(String.Empty, "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_FirstName_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User('X' + new string('s', 20), "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_FirstName_NoUpperCaseLetter()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("aaaaaa", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_FirstName_NoLowerCaseLetter()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("AAAAAA", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_FirstName_ContainsSymbol()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Mateia!", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_FirstName_ContainsNumber()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei1", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_LastName_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", null, "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }
        [Test]
        public void InvalidRating_InvalidRatedUser_LastName_Empty()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", String.Empty, "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_LastName_NoUpperCaseLetter()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", "ddddddde", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_LastName_NoLowerCaseLetter()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", "MMATEI", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_LastName_ContainsSymbol()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", "Debu!", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_LastName_ContainsNumber()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", "Debu2", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_LastName_TooLong()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", 'A'+new string('a', 20), "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_UserName_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", "Debu", null, "0123456789", "mateidebu@yahoo.com", "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        [Test]
        public void InvalidRating_InvalidRatedUser_Email_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", null, "Parola!123"),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        /// <summary>Test for invalid rating (rating with null rated user password).</summary>
        [Test]
        public void InvalidRating_InvalidRatedUser_Password_Null()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Adrian", "Matei", "AdiMatei20", "0123456789", "adrian.matei@FakeEmail.com", "P@ssword123"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", null),
                7);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidRatedUser));
        }

        /// <summary>Test for invalid rating (rating with grade less than 1).</summary>
        [Test]
        public void InvalidRating_Grade_LessThan0()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password123!"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                 new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                 new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password123!"),
                -1);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidGrade));
        }

        /// <summary>Test for invalid rating (rating with grade more than 10).</summary>
        [Test]
        public void InvalidRating_Grade_MoreThan10()
        {
            Rating rating = new Rating(
                new Product(
                    "Aparat foto CANNON",
                    "face poze",
                    new Category("Aparat foto", null),
                    100,
                    ECurrency.EUR,
                    new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password123!"),
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(10)),
                new User("Andrei", "Vlad", "VldAndr3", null, "vladandrei@gmail.com", "Parola!123"),
                new User("Matei", "Debu", "DebuMatei20", "0123456789", "mateidebu@yahoo.com", "Password123!"),
                11);

            Assert.IsFalse(this.IsValidRating(rating));
            Assert.That(this.results.Count, Is.EqualTo(1));
            Assert.That(this.results[0].ErrorMessage, Is.EqualTo(LogTestData.LogRatingWithInvalidGrade));
        }
    }
}
