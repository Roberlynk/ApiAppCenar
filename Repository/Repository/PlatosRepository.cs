using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class PlatosRepository : RepositoryBase<Platos, ApiAppCenarContext>
    {

        public PlatosRepository(ApiAppCenarContext context) : base(context)
        {

        }

        public async Task<bool> UpdatePlato(int id, Platos entity)
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

    }
}
