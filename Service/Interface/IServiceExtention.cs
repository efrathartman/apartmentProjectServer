using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dtos;

namespace Service.Interfaces
{
    public interface IServiceExtention<T>:IService<T>
    {
        public Task<string> GetUserByUserEmail(string userName, string password);
    }
}
