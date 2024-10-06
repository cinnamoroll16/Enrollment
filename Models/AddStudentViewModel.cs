namespace EnrollmentSystem.Web.Models
{
    public class AddStudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentLastName { get; set; } = string.Empty;
        public string StudentFirstName { get; set; } = string.Empty;
        public string StudentMiddleName { get; set; } = string.Empty;
        public string StudentCourse { get; set; } = string.Empty;
        public int StudentYear { get; set; }
        public string StudentRemarks { get; set; } = string.Empty;
        public string StudentStatus { get; set; } = string.Empty;
    }
}
