using DomainModel.Models;
using System.Diagnostics.CodeAnalysis;

namespace TestDomainModel.TestData
{
    [ExcludeFromCodeCoverage]
    internal class CategoryTestData
    {
        private string validCategoryName = "Aparat foto";

        private string emptyCategoryName = string.Empty;

        private string tooLongCategoryName = new string('x', 101);

        private string validParentCategoryName = "Aparat foto";

        public Category GetValidCategory()
        {
            return new Category(this.validCategoryName, new Category(this.validParentCategoryName, null));
        }

        public Category GetEmptyCategory()
        {
            return new Category();
        }

        public Category GetCategoryWithNullName()
        {
            return new Category(null, new Category(this.validParentCategoryName, null));
        }

        public Category GetCategoryWithEmptyName()
        {
            return new Category(this.emptyCategoryName, new Category(this.validParentCategoryName, null));
        }

        public Category GetCategoryWithNameTooLong()
        {
            return new Category(this.tooLongCategoryName, new Category(this.validParentCategoryName, null));
        }

        public Category GetCategoryWithNullParent()
        {
            return new Category(this.validCategoryName, null);
        }
    }
}
