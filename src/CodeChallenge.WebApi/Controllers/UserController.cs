using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CodeChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<UsersResult> Get([FromQuery] UserPaged userPagedDto)
        {
            userPagedDto.Normalize();
            return await _userServices.GetAllAsync(userPagedDto);
        }

        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            return await _userServices.GetAsync(id);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] User userDto)
        {
            var guid = await _userServices.AddAsync(userDto);
            return guid.ToString();
        }

        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] User userDto)
        {
            await _userServices.UpdateAsync(id, userDto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _userServices.DeleteAsync(id);
        }
    }
}
