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
    public class ApartmentService:IService<ApartmentDto>
    {
        private readonly IRepository<Apartment> _repository;
        private readonly IMapper mapper;
        public ApartmentService(IRepository<Apartment> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }
        public async Task<ApartmentDto> AddAsync(ApartmentDto entity)
        {
         return mapper.Map<ApartmentDto>( await _repository.addItemAsync(mapper.Map<Apartment>(entity)));
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<ApartmentDto> getAsync(int id)
        {
            return mapper.Map<ApartmentDto>(await _repository.getAsync(id));
        }

        public async Task<List<ApartmentDto>> getAllAsync()
        {
            return mapper.Map<List<ApartmentDto>>(await _repository.getAllAsync());
        }

        public async Task updateAsync(int id, ApartmentDto entity)
        {
            await _repository.updateAsync(id, mapper.Map<Apartment>(entity));
        }
    }
}
