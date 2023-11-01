using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CvMaker.Core.Enums;

namespace CvMaker.Core.Models
{
    public class LanguageKnowledge : Entity
    {
        [MaxLength (30)]
        public string? Language { get; set; }
        public KnowledgeEnum LanguageLevel { get; set; } 
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
    }
}
