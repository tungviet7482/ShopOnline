using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.User;
using Shop.ViewModels.User;
using System;
using System.Threading.Tasks;

namespace EShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await _userService.Authenticate(request);

            if (res.Status)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await _userService.Register(request);
            if (res.Status)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetUserPaging ([FromQuery]GetUserPagingRequest request)
        {
            var res = await _userService.GetUserPaging(request);
            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var res = await _userService.Delete(id);
            if (res.Status)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserUpdateRequest request)
        {
            var res = await _userService.Update(id, request);
            if (res.Status)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpGet("user-role-paging")]
        public async Task<IActionResult> GetUserRolePaging([FromQuery]GetUserRolePaginRequest request)
        {
            var res = await _userService.GetUserRolePaging(request);
            return Ok(res);
        }

        [HttpPost("create-role")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRole([FromBody]RoleRequest request)
        {
            var res = await _userService.CreateRole(request);
            if (res.Status)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpPost("add-role")]
        [AllowAnonymous]
        public async Task<IActionResult> AddRole(Guid id,string role)
        {
            var res = await _userService.AssignRoleToUser(id, role);
            if (res.Status)
                return Ok(res);
            return BadRequest(res);
        }
    }
}
