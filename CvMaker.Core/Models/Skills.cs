using System.ComponentModel.DataAnnotations;

namespace CvMaker.Core.Models
{
    public class Skills : Entity
    {
        [MaxLength (40)]
        public string? SkillName { get; set; }
        [MaxLength(400)]
        public string? SkillDescription { get; set;}
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
}