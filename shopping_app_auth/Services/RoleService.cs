using shopping_app_auth.Model.Models;
using shopping_app_auth.Repository.Interfaces;
using shopping_app_auth.Services.Interfaces;

namespace shopping_app_auth.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> CreateRole(Role role)
        {
            if(string.IsNullOrEmpty(role.RoleName))
                return await Task.FromResult<Role>(null);

            return await _roleRepository.CreateRole(role);
        }

        public async Task<bool> DeleteRole(int roleId)
        {
            return await _roleRepository.DeleteRole(roleId);
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _roleRepository.GetAll(); 
        }

        public async Task<Role> GetRoleById(int roleId)
        {
            return await _roleRepository.GetRoleById(roleId);
        }

        public async Task<bool> UpdateRole(Role role)
        {
            if (string.IsNullOrEmpty(role.RoleName))
                return await Task.FromResult<bool>(false);

            return await _roleRepository.UpdateRole(role);
        }
    }
}
