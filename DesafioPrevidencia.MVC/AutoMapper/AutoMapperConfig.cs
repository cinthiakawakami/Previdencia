using AutoMapper;

namespace DesafioPrevidencia.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DominioPraModelMappingProfile>();
                cfg.AddProfile<ModelParaDominioMappingProfile>();
            }).CreateMapper();
        }
    }
}