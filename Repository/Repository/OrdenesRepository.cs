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
    public class OrdenesRepository : RepositoryBase<Ordenes, ApiAppCenarContext>
    {
        private readonly OrdenesPlatosRepository _ordenesPlatosRepository;
        public OrdenesRepository(ApiAppCenarContext context) : base(context)
        {
            _ordenesPlatosRepository = new OrdenesPlatosRepository(context);
        }

        public async Task<bool> UpdateOrdenDto(int id, OrdenesDTO entity)
        {
            try
            {
                var orden = await GetById(id);

                orden.IdMesas = entity.IdMesas;
                orden.SubTotal = entity.SubTotal;
                orden.Estado = entity.Estado;

                await Update(orden);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<OrdenesDTO>> GetAllDto()
        {
            var list = await GetAll();

            var listDto = new List<OrdenesDTO>();

            foreach (var item in list)
            {
                var dto = Mapper.Map<OrdenesDTO>(item);

                listDto.Add(dto);
            }

            return listDto;
        }

        public async Task<List<OrdenesDTO>> GetAllOrdenesByStatus(int id)
        {
            var todos = await base._context.Ordenes.Where( x => x.IdMesas == id).ToListAsync();

            var listDto = new List<OrdenesDTO>();

            foreach (var item in todos)
            {
                var dto = Mapper.Map<OrdenesDTO>(item);

                listDto.Add(dto);
            }

            return listDto;
        }

        public async Task<bool> GetOrdenesInProccess(int id)
        {
            var todos = await base._context.Ordenes.Where(x => x.IdMesas == id).ToListAsync();

            if (todos.Count == 0)
            {
                return false;
            }

            foreach (var item in todos)
            {
                if (item.Estado == true)
                {
                    item.Estado = false;

                    await Update(item);
                }
            }

            return true;
        }

        public async Task<bool> DeleteOrdenes(int id)
        {
            try
            {
                await _ordenesPlatosRepository.DeleteOrdenesPlatosId(id);

                await base.Delete(id);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

    }

}
