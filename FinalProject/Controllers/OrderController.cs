using Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IService<OrderDto> service;
        public OrderController(IService<OrderDto> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<OrderDto>> Get()
        {
            return await service.getAllAsync();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            return await service.getAsync(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task Post([FromBody] OrderDto OrderDto)
        {
            await service.AddAsync(OrderDto);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] OrderDto value)
        {
            await service.updateAsync(id, value);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.deleteAsync(id);
        }

    }
}
