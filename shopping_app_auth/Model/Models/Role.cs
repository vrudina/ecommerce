using System.ComponentModel.DataAnnotations;

namespace shopping_app_auth.Model.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
