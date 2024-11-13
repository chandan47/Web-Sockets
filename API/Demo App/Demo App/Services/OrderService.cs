using Demo_App.Database;
using Demo_App.Implementation;
using Demo_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_App.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;
        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _dataContext.Order.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _dataContext.Order.FindAsync(id);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _dataContext.Order.Add(order);
            await _dataContext.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateOrderAsync(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return false;
            }

            _dataContext.Entry(order).State = EntityState.Modified;

            try
            {
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _dataContext.Order.FindAsync(id);
            if (order == null)
            {
                return false;
            }

            _dataContext.Order.Remove(order);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        private async Task<bool> OrderExistsAsync(int id)
        {
            return await _dataContext.Order.AnyAsync(e => e.OrderId == id);
        }
    }
}
