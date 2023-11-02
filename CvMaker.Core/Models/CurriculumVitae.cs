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
}