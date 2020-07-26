using AutoMapper;
using DataBase.Model;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingT.Infraestructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            IngredientesConfiguration();
            MesasConfiguration();
            OrdenesConfiguration();
            PlatosConfiguration();
        }
        private void IngredientesConfiguration()
        {
            CreateMap<IngredientesDTO, Ingredientes>().ReverseMap();
        }
        private void MesasConfiguration()
        {
            CreateMap<MesasDTO, Mesas>().ReverseMap();
        }
        private void OrdenesConfiguration()
        {
            CreateMap<OrdenesDTO, Ordenes>().ReverseMap();

        }
        private void PlatosConfiguration()
        {
            CreateMap<PlatosDTO, Platos>().ReverseMap().ForMember(dest => dest.Ingredientes, opt => opt.Ignore());
        }
    }
}
