using SampleApplication2.Models;

namespace SampleApplication2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek) 
        {
            PiesOfTheWeek= piesOfTheWeek;
        }  
    }
}
