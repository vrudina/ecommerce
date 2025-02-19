using Castle.Components.DictionaryAdapter.Xml;
using Moq;
using shopping_app_auth.Model.Models;
using shopping_app_auth.Repository.Interfaces;
using shopping_app_auth.Services;

namespace tests.RoleTests
{
    public class Role_Negative
    {
        private readonly Mock<IRoleRepository> _mockRoleRepository;
        private readonly RoleService _roleService;

        public Role_Negative()
        {
            _mockRoleRepository = new Mock<IRoleRepository>();
            _roleService = new RoleService(_mockRoleRepository.Object);
        }

        [Fact]
        public async Task RoleShouldNotBeCreatedIfRoleNameIsBlank() {

            var role = new Role { RoleId = 1, RoleName = "" };
            _mockRoleRepository.Setup(repo => repo.CreateRole(role)).ReturnsAsync(role);

            var result = await _roleService.CreateRole(role);

            Assert.Null(result);
        }

        [Fact]
        public async Task RoleShouldNotBeDeletedIfRoleDoesNotExist()
        {
            var roleId = 11;
            _mockRoleRepository.Setup(repo => repo.DeleteRole(roleId)).ReturnsAsync(false);

            var result = await _roleService.DeleteRole(roleId);

            Assert.False(result);
        }

        [Fact]
        public async Task ShouldNotBeDeletedIfRoleIdIsZero()
        {
            var roleId = 0;
            _mockRoleRepository.Setup(repo => repo.DeleteRole(roleId)).ReturnsAsync(false);

            var result = await _roleService.DeleteRole(roleId);
            Assert.False(result);
        }

        [Fact]
        public async Task ShouldNotUpdateRoleIfRoleNameIsNull()
        {

            var existingRole = new Role { RoleId = 1, RoleName = "Super Admin" };
            var roleToBeUpdated = new Role { RoleId = 1, RoleName = "" };
            _mockRoleRepository.Setup(repo => repo.UpdateRole(roleToBeUpdated)).ReturnsAsync(false);
            _mockRoleRepository.Setup(repo => repo.CreateRole(existingRole)).ReturnsAsync(existingRole);


            var result = await _roleService.UpdateRole(roleToBeUpdated);

            Assert.False(result);
        }

        [Fact]
        public async Task ShouldNotReturnAnyRole()
        {

            _mockRoleRepository.Setup(role => role.GetAll()).ReturnsAsync((IEnumerable<Role>?)null);

            var result = await _roleService.GetAll();

            Assert.Null(result);
        }

        [Fact]
        public async Task ShouldNotReturnAnyRoleById()
        {
            var roleId = 1;
            _mockRoleRepository.Setup(role => role.GetRoleById(roleId)).ReturnsAsync((Role?)null);
            var result = await _roleService.GetRoleById(roleId);
            Assert.Null(result);
        }
    }
}
