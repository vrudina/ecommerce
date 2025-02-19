using Moq;
using shopping_app_auth.Repository.Interfaces;
using shopping_app_auth.Services;
using shopping_app_auth.Model.Models;
using System.Data;


namespace tests.RoleTests
{
    public class Role_Positive
    {

        private readonly Mock<IRoleRepository> _mockRoleRepository;
        private readonly RoleService _roleService;

        public Role_Positive()
        {
            _mockRoleRepository = new Mock<IRoleRepository>();
            _roleService = new RoleService(_mockRoleRepository.Object);
        }

        [Fact]
        public async Task CreateRole()
        {
            //Arrange
            var role = new Role { RoleId = 1, RoleName = "Super User" };
            _mockRoleRepository.Setup(repo => repo.CreateRole(role)).ReturnsAsync(role);

            //Act
            var result = await _roleService.CreateRole(role);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(role.RoleId, result.RoleId);
            Assert.Equal(role.RoleName, result.RoleName);
        }

        [Fact]
        public async Task DeleteRole() { 
        
            var roleId = 1;
            _mockRoleRepository.Setup(repo => repo.DeleteRole(roleId)).ReturnsAsync(true); 

            var result = await _roleService.DeleteRole(roleId);

            Assert.True(result);
            _mockRoleRepository.Verify(role => role.DeleteRole(roleId), Times.Once);
        }

        [Fact]
        public async Task UpdateRole() {

            var roleToBeUpdated = new Role { RoleId = 1, RoleName = "Full Admin" };
            _mockRoleRepository.Setup(role => role.UpdateRole(roleToBeUpdated)).ReturnsAsync(true);

            var result = await _roleService.UpdateRole(roleToBeUpdated);

            Assert.True(result);
            _mockRoleRepository.Verify(role => role.UpdateRole(roleToBeUpdated), Times.Once);
        }

        [Fact]
        public async Task GetAll() {
            var roles = new List<Role>
            {
                new Role { RoleId = 1, RoleName = "Super Admin" },
                new Role { RoleId = 2, RoleName = "Employee" }
            };
            _mockRoleRepository.Setup(role => role.GetAll()).ReturnsAsync(roles);

            var result = await _roleService.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(roles, result);
        }

        [Fact]
        public async Task GetRoleById() {
            var role = new Role { RoleId = 1, RoleName = "Super Admin" };
            _mockRoleRepository.Setup(role => role.GetRoleById(1)).ReturnsAsync(role);

            var result = await _roleService.GetRoleById(1);

            Assert.NotNull(result);
            Assert.Equal(role.RoleId, result.RoleId);
            Assert.Equal(role.RoleName, result.RoleName);
        }
    }
}