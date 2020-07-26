using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataBase.Model;
using DTO;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class MesasRepository : RepositoryBase<Mesas, ApiAppCenarContext>
    {
        private readonly OrdenesRepository _ordenesRepository;
        public MesasRepository(ApiAppCenarContext context) : base(context)
        {
            _ordenesRepository = new OrdenesRepository(context);
        }

        public async Task<bool> UpdateMesaDto(int id, MesasDTO entity)
        {
            try
            {
                var mesa = await GetById(id);

                mesa.CantidadP = entity.CantidadP;
                mesa.Descripcion = entity.Descripcion;
                mesa.Estado = entity.Estado;

                await Update(mesa);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> ChangeStatus(int id, string estado)
        {
            try
            {
                var mesa = await GetById(id);

                mesa.Estado = estado;

                await Update(mesa);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> CompleteTable(int id)
        {
            try
            {
                var mesa = await _ordenesRepository.GetOrdenesInProccess(id);

                if (mesa == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<MesasDTO>> GetAllDto()
        {
            var list = await GetAll();

            var listDto = new List<MesasDTO>();

            foreach (var item in list)
            {
                var dto = Mapper.Map<MesasDTO>(item);

                listDto.Add(dto);
            }

            return listDto;
        }
        
        public async Task<List<OrdenesDTO>> GetAllDtoByStatus(int id)
        {
            var list = await _ordenesRepository.GetAllOrdenesByStatus(id);
            return list;
        }

    }
}
