using CvMaker.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CvMaker.Web.Models
{
    public class EmploymentViewModel
    {
        public int Id { get; set; }
        public string? NameOfCompany { get; set; }
        public string? JobPosition { get; set; }
        public string? WorkLoad { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CurriculumVitaeId { get; set; }
       
    }
}
