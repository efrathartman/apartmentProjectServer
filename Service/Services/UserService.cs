using AutoMapper;
using Common.Dtos;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;
//using Service.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IServiceExtention<UserDto>

    {
        private readonly IRepository<User> _repository;
        private readonly IMapper mapper;
        public UserService(IRepository<User> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }
        public async Task<UserDto> AddAsync(UserDto entity)
        {
            return mapper.Map<UserDto>(await _repository.addItemAsync(mapper.Map<User>(entity)));
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<UserDto> getAsync(int id)
        {
            return mapper.Map<UserDto>(await _repository.getAsync(id));
        }

        public async Task<List<UserDto>> getAllAsync()
        {
            var x=await _repository.getAllAsync();
            return mapper.Map<List<UserDto>>(await _repository.getAllAsync());
        }

        public async Task updateAsync(int id, UserDto entity)
        {
            await _repository.updateAsync(id, mapper.Map<User>(entity));
        }
        public async Task<string> GetUserByUserEmail(string userEmail, string password)
        {
            var lst = await this._repository.getAllAsync();
            foreach (var item in lst)
            {
                if (item.Email == userEmail)
                {
                    if (item.Password == password)
                        return item.Id.ToString();
                    else
                        return "password";
                }
            }
            return "email";

        }

    }

}
