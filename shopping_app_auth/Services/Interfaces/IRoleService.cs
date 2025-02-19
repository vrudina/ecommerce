using shopping_app_auth.Model.Models;

namespace shopping_app_auth.Services.Interfaces
{
    public interface IRoleService
    {
        Task<Role> CreateRole(Role role);
        Task<bool> DeleteRole(int roleId);
        Task<bool> UpdateRole(Role role);
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetRoleById(int roleId);

    }
}
