using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Web.Models.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } 
        public required int UserId { get; set; }

        [MaxLength(25)]
        public required string UserName { get; set; } = string.Empty;
        public required string UserPassword { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
    }
}
