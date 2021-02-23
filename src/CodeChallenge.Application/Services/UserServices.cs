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

        public Task<Guid> AddAsync(User user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            return _userRepository.AddAsync(userModel);
        }

        public Task UpdateAsync(Guid id, User user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            return _userRepository.UpdateAsync(id, userModel);
        }

        public Task DeleteAsync(Guid id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public async Task<User?> GetAsync(Guid id)
        {
            var userModel = await _userRepository.GetAsync(id);
            return _mapper.Map<User?>(userModel);
        }

        public async Task<UsersResult> GetAllAsync(UserPaged userPaged)
        {
            var userPagedModel = _mapper.Map<UserPagedModel>(userPaged);
            var (Itens, TotalCount) = await _userRepository.GetAllAsync(userPagedModel);
            return new UsersResult
            {
                Users = _mapper.Map<List<User>>(Itens),
                PageNumber = userPaged.PageNumber,
                PageSize = userPaged.PageSize,
                TotalCount = TotalCount
            };
        }
    }
}
