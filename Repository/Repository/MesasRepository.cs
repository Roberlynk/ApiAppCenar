using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataBase.Model;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class MesasRepository : RepositoryBase<Mesas, ApiAppCenarContext>
    {

        public MesasRepository(ApiAppCenarContext context) : base(context)
        {

        }

        public async Task<bool> UpdateMesa(int id, Mesas entity)
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

    }
}
