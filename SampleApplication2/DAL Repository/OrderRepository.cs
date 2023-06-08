using SampleApplication2.Interface;
using SampleApplication2.Models;

namespace SampleApplication2.DAL_Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyPieShopDbContext _myPieShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(MyPieShopDbContext myPieShopDbContext, IShoppingCart shoppingCart)
        {
            _myPieShopDbContext = myPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _myPieShopDbContext.Orders.Add(order);

            _myPieShopDbContext.SaveChanges();
        }
    }
}
