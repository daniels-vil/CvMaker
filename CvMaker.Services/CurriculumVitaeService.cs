using CvMaker.Core.Models;
using CvMaker.Core.Services;
using CvMaker.Data;

namespace CvMaker.Services;

public class CurriculumVitaeService : EntityService<CurriculumVitae>, ICurriculumVitaeService
{
    public CurriculumVitaeService(CvDbContext context) : base(context)
    {
    }

    public bool CheckForInvalidPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length < 8)
        {
            return false;
        }

        foreach (var c in phoneNumber)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }

        return true;
    }
}