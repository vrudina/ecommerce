using System.ComponentModel.DataAnnotations;

namespace shopping_app_auth.Model.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
    }
}
