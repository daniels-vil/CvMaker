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


}