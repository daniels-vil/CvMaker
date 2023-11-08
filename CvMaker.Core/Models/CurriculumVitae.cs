using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace CvMaker.Core.Models;

public class CurriculumVitae : Entity
{
    [MaxLength(50)]
    public string? FirstName { get; set; }
    [MaxLength(50)]
    public string? OtherName { get; set; }
    [MaxLength(50)]
    public string? LastName { get; set; }
    [MaxLength(12)]
    public string? PhoneNumber { get; set; }
    [MaxLength(50)]
    public string? Email { get; set; }

    public ICollection<LanguageKnowledge> Languages { get; set; } = new List<LanguageKnowledge>();

    public ICollection<Skills> Skills { get; set; } = new List<Skills>();

    public ICollection<Education> Educations { get; set; } = new List<Education>();

    public ICollection<Employment> Employments { get; set; } = new List<Employment>();

    public Address? Address { get; set; } = new Address();
}