using CvMaker.Core.Models;

namespace CvMaker.Web.Models
{
    public class SkillsViewModel
    {
        public int Id { get; set; }
        public string? SkillName { get; set; }
        public string? SkillDescription { get; set; }
        public int CurriculumVitaeId { get; set; }
       
    }
}