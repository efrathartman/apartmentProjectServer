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
    public class UserRepository: IRepository<User>
    {
        private readonly IContext context;
        public UserRepository(IContext context)
        {
            this.context = context;
        }
        public async Task<User> addItemAsync(User item)
        {
            User u = item;
            await context.Users.AddAsync(u);
            await context.save();
            return u;
        }

        public async Task deleteAsync(int id)
        {
            context.Users.Remove(await getAsync(id));
            await context.save();
        }
        public async Task<List<User>> getAllAsync()
        {
            var list =  context.Users.Count();

            return await context.Users.ToListAsync();
                }
        public async Task<User> getAsync(int id)
        {

            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task updateAsync(int id, User item)
        {
            User u = await getAsync(id);
            u.Name = item.Name;
            u.Email = item.Email;
            u.Password = item.Password;
            u.Phone = item.Phone;
            await context.save();
        }
    }
}
