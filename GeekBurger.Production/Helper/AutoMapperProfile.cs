using AutoMapper;
using GeekBurger.Production.Contract;
using GeekBurger.Production.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Helper
{
    /// <summary>
    /// Classe responsável por configurar o AutoMapper 
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductionArea, ProductionAreaTO>().AfterMap<MatchTOFromRepository>();
            CreateMap<ProductionAreaCRUD, ProductionArea>().ForMember(dest => dest.Restrictions, opt => opt.Ignore())
                                                            .AfterMap<MatchRepositoryFromCRUD>();

            CreateMap<EntityEntry<ProductionArea>, ProductionAreaChangedMessage>().ForMember(dest => dest.ProductionArea
                                                                                                , opt => opt.MapFrom(src => src.Entity));
        }
    }
}
