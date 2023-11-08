using CvMaker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CvMaker.Data;

public class CvDbContext : DbContext
{
    public CvDbContext(DbContextOptions<CvDbContext> options) : base(options)
    {
        
    }

    DbSet<CurriculumVitae> curriculumVitae { get; set; }
    DbSet<LanguageKnowledge> languageKnowledge { get; set; }
    DbSet<Education> education { get; set; }
    DbSet<Employment> employment { get; set; }
    DbSet<Skills> skills { get; set; }
    DbSet<Address> address { get; set; }
}