using AutoMapper;
using Common.Dtos;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService:IService<OrderDto>
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper mapper;

        public OrderService(IRepository<Order> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }
        public async Task<OrderDto> AddAsync(OrderDto entity)
        {
            return mapper.Map<OrderDto>(await _repository.addItemAsync(mapper.Map<Order>(entity)));
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<OrderDto> getAsync(int id)
        {
            return mapper.Map<OrderDto>(await _repository.getAsync(id));
        }

        public async Task<List<OrderDto>> getAllAsync()
        {
            return mapper.Map<List<OrderDto>>(await _repository.getAllAsync());
        }

        public async Task updateAsync(int id, OrderDto entity)
        {
            await _repository.updateAsync(id, mapper.Map<Order>(entity));
        }
    }
}
