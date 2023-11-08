using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CvMaker.Core.Models;

namespace CvMaker.Core.Services
{
    public interface ICurriculumVitaeService : IEntityService<CurriculumVitae>
    {
        public bool CheckForInvalidPhoneNumber(string phoneNumber);
    }
}
