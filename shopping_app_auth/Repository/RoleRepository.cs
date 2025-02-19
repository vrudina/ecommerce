using Microsoft.EntityFrameworkCore;
using shopping_app_auth.Model;
using shopping_app_auth.Model.Models;
using shopping_app_auth.Repository.Interfaces;

namespace shopping_app_auth.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AuthDbContext _authDbContext;

        public RoleRepository(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public async Task<Role> CreateRole(Role role)
        {
            _authDbContext.Roles.Add(role);
            await _authDbContext.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteRole(int roleId)
        {
            var role = _authDbContext.Roles.Find(roleId);
            if (role == null) return false;

            _authDbContext.Roles.Remove(role);
            await _authDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _authDbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int roleId)
        {
            var role = await _authDbContext.Roles.FindAsync(roleId);
            if (role == null) throw new KeyNotFoundException($"Role with ID {roleId} not found.");

            return role;
        }

        public async Task<bool> UpdateRole(Role role)
        {
           var roleToBeUpdated = await _authDbContext.Roles.FindAsync(role.RoleId);
            if (roleToBeUpdated == null) return false;

            roleToBeUpdated.RoleName = role.RoleName;
            await _authDbContext.SaveChangesAsync();
            return true;
        }
    }
}