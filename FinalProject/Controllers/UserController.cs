using Common.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
//using Service.Interface;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceExtention<UserDto> service;
        public UserController(IServiceExtention<UserDto> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            return await service.getAllAsync();
        }
        //[HttpGet("user/{userName}")]
        //public async Task<UserDto> GetByUserName(string userName)
        //{
        //    return await service.GetUserByUserName(userName);
        //}
        [HttpPost("lecture/Login")]
        public async Task<IActionResult> GetByUserEmail([FromBody] UserDto user)
        {
            string res = await service.GetUserByUserEmail(user.Email, user.Password);
            if (res == "email")
                return Ok("worng");
            else
            if (res == "password")
                return Ok("worng");

            return Ok(res);

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            //return await service.getAsync(id);
            var u = await service.getAsync(id);
            u.Password = "****";
            return u;
        }
      //  [HttpGet("user/{userName}")]


        // POST api/<UserController>
        [HttpPost]
        public async Task Post([FromBody] UserDto UserDto)
        {
            await service.AddAsync(UserDto);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDto value)
        {
            await service.updateAsync(id, value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.deleteAsync(id);
        }


    }
}
