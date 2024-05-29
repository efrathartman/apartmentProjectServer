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
    public class ApartmentRepository: IRepository<Apartment>
    {
        private readonly IContext context;
        public ApartmentRepository(IContext context)
        {
            this.context = context;
        }
        public async Task<Apartment> addItemAsync(Apartment item)
        {
            Apartment a = item;
            await context.Apartments.AddAsync(a);
              await context.save();
            return a;
        }

        public async Task deleteAsync(int id)
        {
             context.Apartments.Remove(await getAsync(id));
            await context.save();
        }
        public async Task< List<Apartment>> getAllAsync()
        {
            return await context.Apartments.Include(a=>a.ResponseOfUsers).ThenInclude(y=>y.User).Include(x=>x.User).ToListAsync();
        }

        public async Task<Apartment> getAsync(int id)
        {

            return await context.Apartments.Include(a=>a.ResponseOfUsers).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task updateAsync(int id, Apartment item)
        {
            Apartment a = await getAsync(id);
            a.City = item.City; 
            a.Area = item.Area;
            a.NumOfBeds = item.NumOfBeds;
            a.NumOfRooms = item.NumOfRooms; 
            a.Price = item.Price;
            a.Description = item.Description;
            a.UserId = item.UserId;
            a.UrlImages = item.UrlImages;
            a.Name = item.Name;

            await context.save();
        }
        

    }
}
