using AutoMapper;
using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Domain.Abstractions.Repositories;
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

        public async Task<UsersResultDto> GetUsersAsync(UserPagedDto userPagedDto)
        {
            var (Itens, TotalCount) = await _userRepository.GetAllAsync(userPagedDto);
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
