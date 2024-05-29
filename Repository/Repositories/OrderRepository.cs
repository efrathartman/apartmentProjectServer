using Common.Dtos;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OrderRepository: IRepository<Order>

    {
        private readonly IContext context;
        public OrderRepository(IContext context)
        {
            this.context = context;
        }
        public async Task<Order> addItemAsync(Order item)
        {
            Order o = item;
            await context.Orders.AddAsync(o);
            await context.save();
            return o;
        }

        public async Task deleteAsync(int id)
        {
            context.Orders.Remove(await getAsync(id));
            await context.save();
        }
        public async Task<List<Order>> getAllAsync()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<Order> getAsync(int id)
        {

            return await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task updateAsync(int id, Order item)
        {
            Order o = await getAsync(id);
            o.ToDate=item.ToDate;
            o.FromDate=item.FromDate;

            await context.save();
        }
    }
}
