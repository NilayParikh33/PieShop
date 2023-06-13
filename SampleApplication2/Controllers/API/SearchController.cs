using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApplication2.Interface;
using SampleApplication2.Models;

namespace SampleApplication2.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;

        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        //This method will give AllPies List.
        [HttpGet]
        public IActionResult GetAll()
        {
            var allPies = _pieRepository.AllPies;
            return Ok(allPies);
        }

        //This method will give Pie based on their PieId.
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            if(!_pieRepository.AllPies.Any(p => p.PieId == id))
                return NotFound();
            return Ok(_pieRepository.AllPies.Where(p => p.PieId == id));
        }

        //This will give Pies data in JSON Format based on searched Pie.
        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<Pie> pies = new List<Pie>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                pies = _pieRepository.SearchPies(searchQuery);
            }
            return new JsonResult(pies);
        }
    }
}
