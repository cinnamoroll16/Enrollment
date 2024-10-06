namespace EnrollmentSystem.Web.Models
{
    public class AddUserViewModel
    {
        public required int UserID { get; set; }
        public required string UserName { get; set; } = string.Empty;
        public required string UserPassword { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
    }
}
