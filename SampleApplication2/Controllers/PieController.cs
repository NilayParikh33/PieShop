using Microsoft.AspNetCore.Mvc;
using SampleApplication2.Interface;
using SampleApplication2.Models;
using SampleApplication2.ViewModels;

namespace SampleApplication2.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese Cakes";
            PieListViewModel pieListViewModel = new PieListViewModel(_pieRepository.AllPies, "All pies");
            return View(pieListViewModel);
        }

        //This method will show List of Pies in PieList Page.
        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PieListViewModel(pies, currentCategory));
        }

        //This method will give Perticular Pie based on PieId.
        public IActionResult Details(int id) 
        {
            var pie = _pieRepository.GetPieById(id);
            if(pie == null)
                return NotFound();
            return View(pie); 
        }

        //This method will give Search Result for Pie.
        public IActionResult Search() 
        {
            return View();
        }
    }
}
