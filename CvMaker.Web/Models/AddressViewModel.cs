using CvMaker.Core.Models;

namespace CvMaker.Web.Models;

public class AddressViewModel
{
    public int Id { get; set; }
    public string? PostCode { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? Country { get; set; }
    public string? StreetNumber { get; set; }
    public int CurriculumVitaeId { get; set; }
}