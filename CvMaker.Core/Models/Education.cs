using System.ComponentModel.DataAnnotations;

namespace CvMaker.Core.Models;

public class Education : Entity
{
    [MaxLength(50)]
    public string? NameOfSchool {get; set; }
    [MaxLength(50)]
    public string? Faculty { get; set; }
    [MaxLength(50)]
    public string? StudyProgram { get; set; }
    [MaxLength(50)]
    public string? EducationalLevel { get; set; }
    [MaxLength(50)]
    public string? Status { get; set; }
    [MaxLength(50)]
    public DateTime? StudyStartDate { get; set; }
    public DateTime? StudyEndDate { get; set; }
    public int CurriculumVitaeId { get; set; }
    public CurriculumVitae CurriculumVitae { get; set; }

}