using SampleApplication2.Models;

namespace SampleApplication2.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; }
        public string? CurrentCategory { get; }

        public PieListViewModel(IEnumerable<Pie> pies, string? currentCategory) 
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }
    }
}
