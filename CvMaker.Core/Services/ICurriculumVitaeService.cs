using CvMaker.Core.Models;

namespace CvMaker.Core.Services
{
    public interface ICurriculumVitaeService : IEntityService<CurriculumVitae>
    {
        public bool CheckForInvalidPhoneNumber(string phoneNumber);
    }
}
