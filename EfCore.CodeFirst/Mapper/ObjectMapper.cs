using AutoMapper;
using EfCore.CodeFirst.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> layz = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => layz.Value;
    }

    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
