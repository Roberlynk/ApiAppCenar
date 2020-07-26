using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataBase.Model;
using DTO;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class IngredientesRepository : RepositoryBase<Ingredientes, ApiAppCenarContext>
    {
        private readonly PlatosIngredientesRepository _platosIngredientesRepository;
        public IngredientesRepository(ApiAppCenarContext context) : base(context)
        {
            _platosIngredientesRepository = new PlatosIngredientesRepository(context);
        }

        public async Task<bool> UpdateIngredienteDto(int id, IngredientesDTO dto)
        {
            try
            {
                var ingrediente = await GetById(id);

                ingrediente.Nombre = dto.Nombre;

                await Update(ingrediente);


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<List<IngredientesDTO>> GetAllDto()
        {
            var list = await GetAll();

            var listDto = new List<IngredientesDTO>();

            foreach (var item in list)
            {
                var dto = Mapper.Map<IngredientesDTO>(item);

                listDto.Add(dto);
            }

            return listDto;
        }

        public async Task<List<IngredientesDTO>> GetIngredientesDtoByIds(int ids)
        {
            var listPlatosIngredientes = await _platosIngredientesRepository.GetIngredientesByPlatos(ids);

            var listIngredientes = new List<Ingredientes>();

            foreach (var item in listPlatosIngredientes)
            {
                var ingrediente = await GetById(item.IdIngredientes);
                listIngredientes.Add(ingrediente);
            }

            var listDto = new List<IngredientesDTO>();

            listIngredientes.ForEach(x =>
            {
                var dto = Mapper.Map<IngredientesDTO>(x);

                listDto.Add(dto);

            });



            return listDto;
        }


    }
}
