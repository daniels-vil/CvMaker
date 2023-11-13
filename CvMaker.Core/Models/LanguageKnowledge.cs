using System.ComponentModel.DataAnnotations;
using CvMaker.Core.Enums;

namespace CvMaker.Core.Models
{
    public class LanguageKnowledge : Entity
    {
        [MaxLength (30)]
        public string? Language { get; set; }
        public KnowledgeEnum? LanguageLevel { get; set; } 
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
}
