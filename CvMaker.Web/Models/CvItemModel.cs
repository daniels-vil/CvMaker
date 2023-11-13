using System.Text.RegularExpressions;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CvMaker.Web.Models
{
    public class CvItemModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Fill out name field")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Fill out E-mail field")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Fill out last name field")]
        public string? LastName { get;  set; }
        public string? OtherName { get;  set; }
        [Required(ErrorMessage = "Fill out phone number field")]
        public string? PhoneNumber { get;  set; }

        public List<LanguageKnowledgeViewModel> 
            LanguageKnowledge { get; set; } = new List<LanguageKnowledgeViewModel>();

        public List<SkillsViewModel> Skills { get; set; } = new List<SkillsViewModel>();

        public List<EducationViewModel> Educations { get; set; } = new List<EducationViewModel>();
        public List<EmploymentViewModel> Employments { get; set; } = new List<EmploymentViewModel>();

        public AddressViewModel? Address { get; set; } = new AddressViewModel();

        public string FullName()
        {
            var fullname = $"{this.Name} {this.OtherName ?? ""} {this.LastName}";
            return Regex.Replace(fullname, @"\s+", " ");
        }
        public string FullAddress()
        {
            var fullAddress = $"{this.Address.City}, {this.Address.Street} {this.Address.StreetNumber}, {this.Address.PostCode}";
            return Regex.Replace(fullAddress, @"\s+", " ");
        }
    }

   
}