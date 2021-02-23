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
        public Task<UsersResult> Get([FromQuery] UserPaged userPagedDto)
        {
            userPagedDto.Normalize();
            return _userServices.GetAllAsync(userPagedDto);
        }

        [HttpGet("{id}")]
        public Task<User?> Get(Guid id)
        {
            return _userServices.GetAsync(id);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] User userDto)
        {
            var guid = await _userServices.AddAsync(userDto);
            return guid.ToString();
        }

        [HttpPut("{id}")]
        public Task Put(Guid id, [FromBody] User userDto)
        {
            return _userServices.UpdateAsync(id, userDto);
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            return _userServices.DeleteAsync(id);
        }
    }
}
