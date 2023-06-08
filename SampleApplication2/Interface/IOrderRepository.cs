using SampleApplication2.Models;

namespace SampleApplication2.Interface
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
