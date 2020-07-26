using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataBase.Model;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class PlatosRepository : RepositoryBase<Platos, ApiAppCenarContext>
    {
        private readonly IngredientesRepository _ingredientesRepository;
        public PlatosRepository(ApiAppCenarContext context) : base(context)
        {
            _ingredientesRepository = new IngredientesRepository(context);
        }

        public async Task<bool> UpdatePlatoDto(int id, PlatosDTO entity)
        {
            try
            {
                var plato = await GetById(id);

                plato.Nombre = entity.Nombre;
                plato.Precio = entity.Precio;
                plato.Limite = entity.Limite;
                plato.Categoria = entity.Categoria;

                await Update(plato);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<List<PlatosDTO>> GetAllDto()
        {
            var list = await GetAll();

            var listDto = new List<PlatosDTO>();

            foreach (var item in list)
            {
                var dto = Mapper.Map<PlatosDTO>(item);

                var listIngredientesDto = await _ingredientesRepository.GetIngredientesDtoByIds(item.IdPlatos);

                dto.Ingredientes = listIngredientesDto;

                listDto.Add(dto);
            }

            return listDto;
        }

    }
}
