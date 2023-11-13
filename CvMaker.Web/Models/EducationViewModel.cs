using CvMaker.Core.Enums;
namespace CvMaker.Web.Models
{
    public class EducationViewModel
    {
        public int Id { get; set; }
        public string? NameOfSchool { get; set; }
        public string? Faculty { get; set; }
        public string? StudyProgram { get; set; }
        public string? EducationalLevel { get; set; }
        public EducationStatusEnum? Status { get; set; }
        public DateTime? StudyStartDate { get; set; }
        public DateTime? StudyEndDate { get; set; }
        public int CurriculumVitaeId { get; set; }
    }
}