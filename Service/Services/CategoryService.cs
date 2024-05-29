using AutoMapper;
using Common.Dtos;
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
    public class CategoryService:IService<CategoryDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper mapper;

        public CategoryService(IRepository<Category> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }
        public async Task<CategoryDto> AddAsync(CategoryDto entity)
        {
          return mapper.Map<CategoryDto>(  await _repository.addItemAsync(mapper.Map<Category>(entity)));
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<CategoryDto> getAsync(int id)
        {
            return mapper.Map<CategoryDto>(await _repository.getAsync(id));
        }

        public async Task<List<CategoryDto>> getAllAsync()
        {
            return mapper.Map<List<CategoryDto>>(await _repository.getAllAsync());
        }

        public async Task updateAsync(int id, CategoryDto entity)
        {
            await _repository.updateAsync(id, mapper.Map<Category>(entity));
        }
    }
}
