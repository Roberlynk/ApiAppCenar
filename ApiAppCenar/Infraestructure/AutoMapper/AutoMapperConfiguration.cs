using AutoMapper;
using DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingT.Infraestructure.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            ConfigureUsuario();
        }
        private void ConfigureUsuario()
        {

        }
    }
}
