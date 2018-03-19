using AutoMapper;
using GeekBurger.Production.Contract;
using GeekBurger.Production.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductionArea, ProductionAreaTO>();
            CreateMap<ProductionAreaCRUD, ProductionArea>();
        }
    }
}
