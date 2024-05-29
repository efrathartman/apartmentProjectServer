using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly IContext context;
        public CategoryRepository(IContext context)
        {
            this.context = context;
        }
        public async Task<Category> addItemAsync(Category item)

        {
            try
            {
                Category c = item;
                await context.Categories.AddAsync(c);
                await context.save();
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception("error");
            }

        }
        public async Task deleteAsync(int id)
        {
            context.Categories.Remove(await getAsync(id));
            await context.save();
        }
        public async Task<List<Category>> getAllAsync()
        {
            return await context.Categories.ToListAsync();
        }
        public async Task<Category> getAsync(int id)
        {

            return await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task updateAsync(int id, Category item)
        {
            Category c = await getAsync(id);
            c.Description = item.Description;
           // c.UrlImage = item.UrlImage;
            await context.save();

        }
    }
}
