using Demo_App.Models;

namespace Demo_App.Implementation
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetOrdersAsync();
        public Task<Order> GetOrderByIdAsync(int id);
        public Task<Order> CreateOrderAsync(Order order);
        public Task<bool> UpdateOrderAsync(int id, Order order);
        public Task<bool> DeleteOrderAsync(int id);
    }
}
