using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.Data.Entities;
using Shop.ViewModels.Comom;
using Shop.ViewModels.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.User
{
    public class UserService : IUserService
    {
        public UserManager<AppUser> _userManager;
        public SignInManager<AppUser> _signInManager;
        public RoleManager<AppRole> _roleManager;
        public IConfiguration _config;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = configuration;
        }
        public async Task<Result<string>> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return new Result<string>("User không tồn tại", false, "");
            var res = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, request.RemeberMe, false);
            if (!res.Succeeded) return new Result<string>("Đăng nhập thất bại", false, "");
            var roles = await _userManager.GetRolesAsync(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = _config["Tokens:Issuer"];

            var claims = new List<Claim> {
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
                };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));


            var token = new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
                );

            return new Result<string>("", true, new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<Result<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.UserName.Contains(request.keyword) || x.PhoneNumber.Contains(request.keyword));

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .Select(x => new UserViewModel()
                            {
                                Id = x.Id,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                UserName = x.UserName,
                                Password = x.PasswordHash,
                                Email = x.Email,
                                PhoneNumber = x.PhoneNumber
                            }).ToListAsync();

            var pageResult = new PageResult<UserViewModel>(data, totalRow);
            return new Result<PageResult<UserViewModel>>("", true, pageResult);
        }
        public async Task<Result<bool>> Register(RegisterRequest request)
        {
            if(await _userManager.FindByEmailAsync(request.Email) != null)
                return new Result<bool>("Email đã tồn tại", false, false);
            if (await _userManager.FindByEmailAsync(request.UserName) != null)
                return new Result<bool>("Tên tài khoản đã tồn tại", false, false);
            var user = new AppUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                Dob = request.Dob,
                PhoneNumber = request.PhoneNumber,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            var res = await _userManager.CreateAsync(user, request.Password);
            var assignRole = await AssignRoleToUser(user.Id, "member");
            if (res.Succeeded && assignRole.ResultObj)
                return new Result<bool>("", true, true);
            return new Result<bool>("Lỗi đăng ký", false, false);
        }

        public async Task<Result<bool>> Delete(Guid id)
        {
            var query = await _userManager.FindByIdAsync(id.ToString());
            if (query == null)
                return new Result<bool>("User không tồn tại", false, false);
            var res = await _userManager.DeleteAsync(query);
            if (res.Succeeded)
                return new Result<bool>("", true, true);
            return new Result<bool>("Xóa thất bại", false, false); ;
        }

        public async Task<Result<bool>> Update(Guid id, UserUpdateRequest request)
        {
            var query = await _userManager.FindByIdAsync(id.ToString());
            if (query.Email != request.Email)
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
                    return new Result<bool>("Email đã tồn tại", false, false);
            }
            query.FirstName = request.FirstName;
            query.LastName = request.LastName;
            query.Dob = request.Dob;
            query.Email = request.Email;
            query.PhoneNumber = request.PhoneNumber;
            query.UserName = request.UserName;
            query.PasswordHash = request.Password;
            var res = await _userManager.UpdateAsync(query);
            if (res.Succeeded)
                return new Result<bool>("", true, true);
            return new Result<bool>("Cập nhật thất bại", false, false);
        }

        public async Task<Result<PageResult<UserRoleViewModel>>> GetUserRolePaging(GetUserRolePaginRequest request)
        {
            var query = _userManager.Users;
            if (request.keyword != null)
                query = query.Where(x => x.UserName == request.keyword);
            var total = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                            .Take(request.PageSize).ToList();
            var list = new List<UserRoleViewModel>();
            foreach (var i in data)
            {
                var roles = await _userManager.GetRolesAsync(i);
                list.Add(new UserRoleViewModel() { UserName = i.UserName, Roles = roles.ToList() });
            }
            var res = new PageResult<UserRoleViewModel>(list, total);
            return new Result<PageResult<UserRoleViewModel>>("", true, res);
        }

        public async Task<Result<bool>> CreateRole(RoleRequest request)
        {
            var query = await _roleManager.FindByNameAsync(request.Name);
            if (query != null)
                return new Result<bool>("Role đã tồn tại", false, false);
            var role = new AppRole()
            {
                Name = request.Name,
                Description = request.Description
            };
            var res = await _roleManager.CreateAsync(role);
            if (res.Succeeded)
                return new Result<bool>("", true, true);
            return new Result<bool>("Tạo role thất bại", false, false);
        }

        public async Task<Result<bool>> AssignRoleToUser(Guid id, string role)
        {
            var query = await _roleManager.FindByNameAsync(role);
            if (query == null) return new Result<bool>("Lỗi role", false, false);
            var user = await _userManager.FindByIdAsync(id.ToString());
            var oldRoleNames = await _userManager.GetRolesAsync(user);
            if (oldRoleNames.Contains(role))
                return new Result<bool>("Trùng role", false, false);
            var res = await _userManager.AddToRoleAsync(user, role);
            if (res.Succeeded)
                return new Result<bool>("", true, true);
            return new Result<bool>("Thêm role thất bại", false, false);
        }
    }
}
