using CvMaker.Core.Enums;

namespace CvMaker.Web.Models;

public class LanguageKnowledgeViewModel
{
    public int Id { get; set; }
    public string? Language { get; set; }
    public KnowledgeEnum LanguageLevel { get; set; }
    public int CurriculumVitaeId { get; set; }
}