using SampleApplication2.Interface;
using SampleApplication2.Models;

namespace SampleApplication2.DAL_Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyPieShopDbContext _myPieShopDbContext;
        public CategoryRepository(MyPieShopDbContext myPieShopDbContext) 
        {
            _myPieShopDbContext= myPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _myPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
