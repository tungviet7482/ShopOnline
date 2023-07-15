using Shop.ViewModels.Comom;
using Shop.ViewModels.User;
using System;
using System.Threading.Tasks;

namespace Shop.Services.User
{
    public interface IUserService
    {
        Task<Result<string>> Authenticate(LoginRequest request);
        Task<Result<bool>> Register(RegisterRequest request);

        Task<Result<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request);
        Task<Result<bool>> Delete(Guid id);
        Task<Result<bool>> Update(Guid id, UserUpdateRequest request);
        Task<Result<bool>> CreateRole(RoleRequest request);
        Task<Result<bool>> AssignRoleToUser(Guid id, string role);
        Task<Result<PageResult<UserRoleViewModel>>> GetUserRolePaging(GetUserRolePaginRequest request);
    }
}
