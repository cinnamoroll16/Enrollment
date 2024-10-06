using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Web.Models.Entities
{
    public class Subject
    {
        [Key]public Guid Id { get; set; }
        public required string SubjectCode { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public required char Units { get; set; }
        public required int Offering {  get; set; }
        public required string Category { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public required string CourseCode { get; set; } = string.Empty;
        public required string Curriculum {  get; set; } = string.Empty;
    }
}
