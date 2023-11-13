using System.ComponentModel.DataAnnotations;

namespace CvMaker.Core.Models
{
    public class Address : Entity
    {
        [MaxLength(50)]
        public string? PostCode { get; set; }
        [MaxLength(150)]
        public string? City { get; set; }
        [MaxLength(100)]
        public string? Street { get; set; }
        [MaxLength(70)]
        public string? Country { get; set; }
        [MaxLength(10)]
        public string? StreetNumber { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }

    }
}
