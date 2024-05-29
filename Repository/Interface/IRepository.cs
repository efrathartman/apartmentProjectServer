using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository <T> where T : class
    {
        public Task<T> addItemAsync(T item);
        public Task updateAsync(int id, T item);
        public Task  deleteAsync(int  id);
        public Task< T> getAsync(int id);
        public Task< List<T>> getAllAsync();
    }
}
