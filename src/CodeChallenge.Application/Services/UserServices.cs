using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Abstractions.Repositories;
using CodeChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserServices(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Guid> AddAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(Guid id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateAsync(id, user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UsersResultDto> GetAllAsync(UserPagedDto userPagedDto)
        {
            var userPaged = _mapper.Map<UserPaged>(userPagedDto);
            var (Itens, TotalCount) = await _userRepository.GetAllAsync(userPaged);
            return new UsersResultDto
            {
                Users = _mapper.Map<List<UserDto>>(Itens),
                PageNumber = userPagedDto.PageNumber,
                PageSize = userPagedDto.PageSize,
                TotalCount = TotalCount
            };
        }
    }
}
