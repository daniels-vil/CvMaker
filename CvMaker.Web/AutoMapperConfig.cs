using AutoMapper;
using System.Configuration;

namespace CvMaker.Web
{
    public class AutoMapperConfig
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
               
                cfg.AddProfile<MappingProfile>();
            });
#if DEBUG
            config.AssertConfigurationIsValid();
#endif
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
