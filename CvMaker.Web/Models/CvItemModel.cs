using CvMaker.Data.Migrations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.RegularExpressions;
using CvMaker.Core.Models;

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
            var fullAddress = $"{this.Address.City} {this.Address.Street} {this.Address.StreetNumber}, {this.Address.PostCode}";
            return Regex.Replace(fullAddress, @"\s+", " ");
        }
    }

   
}
