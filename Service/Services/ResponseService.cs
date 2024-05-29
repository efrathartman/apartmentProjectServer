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
    public class ResponseService:IService<ResponseDto>
    {
        private readonly IRepository<Response> _repository;
        private readonly IMapper mapper;
        public ResponseService(IRepository<Response> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }

        public async Task<ResponseDto> AddAsync(ResponseDto entity)
        {
            return mapper.Map<ResponseDto>(await _repository.addItemAsync(mapper.Map<Response>(entity)));
        }

        public async Task deleteAsync(int id)
        {
            await _repository.deleteAsync(id);
        }

        public async Task<ResponseDto> getAsync(int id)
        {
            return mapper.Map<ResponseDto>(await _repository.getAsync(id));
        }

        public async Task<List<ResponseDto>> getAllAsync()
        {
            return mapper.Map<List<ResponseDto>>(await _repository.getAllAsync());
        }

        public async Task updateAsync(int id, ResponseDto entity)
        {
            await _repository.updateAsync(id, mapper.Map<Response>(entity));
        }
    }
}
