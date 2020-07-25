using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataBase.Model;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class IngredientesRepository : RepositoryBase<Ingredientes, ApiAppCenarContext>
    {

        public IngredientesRepository(ApiAppCenarContext context) : base(context)
        {

        }

        public async Task<bool> UpdateIngrediente(int id, Ingredientes entity)
        {
            try
            {
                var ingrediente = await GetById(id);

                ingrediente.Nombre = entity.Nombre;

                await Update(ingrediente);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        } 

    }
}
