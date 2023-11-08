using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvMaker.Core.Models
{
    public class Employment : Entity
    {
        [MaxLength(50)]
        public string? NameOfCompany {  get; set; }
        [MaxLength(70)]
        public string? JobPosition {  get; set; }
        [MaxLength(20)]
        public string? WorkLoad {  get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }

    }
}
