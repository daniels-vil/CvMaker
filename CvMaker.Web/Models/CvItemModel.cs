namespace CvMaker.Web.Models
{
    public class CvItemModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? LastName { get;  set; }
        public string? OtherName { get;  set; }
        public string? PhoneNumber { get;  set; }

        public List<LanguageKnowledgeViewModel> 
            LanguageKnowledge { get; set; } = new List<LanguageKnowledgeViewModel>();
    }
}
