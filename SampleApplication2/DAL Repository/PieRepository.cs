using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApplication2.Interface;
using SampleApplication2.Models;

namespace SampleApplication2.DAL_Repository
{
    public class PieRepository : IPieRepository
    {
        private readonly MyPieShopDbContext _myPieShopDbContext;
        public PieRepository(MyPieShopDbContext myPieShopDbContext) 
        {
            _myPieShopDbContext = myPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _myPieShopDbContext.Pies.Include(c=>c.Category);
            }
        } 

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _myPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _myPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _myPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
