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
     public class ResponseRepository:IRepository<Response>
    {
        private readonly IContext context;
        public ResponseRepository(IContext context)
        {
            this.context = context;
        }
        public async Task<Response> addItemAsync(Response item)
        {
            Response r = item;
            await context.Responses.AddAsync(r);
            await context.save();
            return r;
        }

        public async Task deleteAsync(int id)
        {
            context.Responses.Remove(await getAsync(id));
            await context.save();
        }
        public async Task<List<Response>> getAllAsync()
        {
            return await context.Responses.ToListAsync();
        }

        public async Task<Response> getAsync(int id)
        {

            return await context.Responses.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task updateAsync(int id, Response item)
        {
            Response r = await getAsync(id);
            r.Description = item.Description;
            await context.save();
        }
    }
}
