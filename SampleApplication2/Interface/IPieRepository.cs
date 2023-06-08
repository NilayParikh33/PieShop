using SampleApplication2.Models;

namespace SampleApplication2.Interface
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);
        IEnumerable<Pie> SearchPies(string searchQuery);
    }
}
