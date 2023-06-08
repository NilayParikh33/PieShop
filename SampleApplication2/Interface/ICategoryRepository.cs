using SampleApplication2.Models;

namespace SampleApplication2.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
