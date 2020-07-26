using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class PlatosIngredientesRepository : RepositoryBase<PlatosIngredientes, ApiAppCenarContext>
    {

        public PlatosIngredientesRepository(ApiAppCenarContext context) : base(context)
        {

        }

        public async Task<List<PlatosIngredientes>> GetIngredientesByPlatos(int id)
        {

            var ingredientesPlatos = await base._context.PlatosIngredientes.Where(c => c.IdPlatos == id).ToListAsync();


            return ingredientesPlatos;
        }

    }
}
