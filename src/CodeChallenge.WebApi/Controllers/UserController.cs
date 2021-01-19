﻿using CodeChallenge.Application.DataTransferObjects;
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
        public async Task<UsersResultDto> Get([FromQuery] UserPagedDto userPagedDto)
        {
            userPagedDto.Normalize();
            return await _userServices.GetAllAsync(userPagedDto);
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(Guid id)
        {
            return await _userServices.GetAsync(id);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] UserDto userDto)
        {
            var guid = await _userServices.AddAsync(userDto);
            return guid.ToString();
        }

        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] UserDto userDto)
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
