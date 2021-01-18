using CodeChallenge.Application.DataTransferObjects;
using CodeChallenge.Application.Services;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<UsersResultDto> Get(UserPagedDto userPagedDto)
        {
            userPagedDto.Normalize();
            return await _userServices.GetUsersAsync(userPagedDto);
        }
    }
}
