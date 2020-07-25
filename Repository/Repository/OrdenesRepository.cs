using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataBase.Model;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class OrdenesRepository : RepositoryBase<Ordenes, ApiAppCenarContext>
    {
        private OrdenesPlatosRepository ordenesPlatosRepository;
        public OrdenesRepository(ApiAppCenarContext context) : base(context)
        {
            ordenesPlatosRepository = new OrdenesPlatosRepository(context);
        }

        public async Task<bool> UpdateOrden(int id, Ordenes entity)
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

        public async Task<bool> DeleteOrdenes(int id)
        {
            try
            {
                await ordenesPlatosRepository.DeleteOrdenesPlatosId(id);

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
