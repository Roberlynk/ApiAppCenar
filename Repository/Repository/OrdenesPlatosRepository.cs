using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class OrdenesPlatosRepository : RepositoryBase<OrdenesPlatos, ApiAppCenarContext>
    {

        public OrdenesPlatosRepository(ApiAppCenarContext context) : base(context)
        {

        }

        public async Task<bool> DeleteOrdenesPlatosId(int id)
        {

            try
            {
                var platosId = await base._context.OrdenesPlatos.Where(c => c.IdOrdenes == id).ToListAsync();

                foreach (var item in platosId)
                {
                    _context.Remove(item);
                }

                await _context.SaveChangesAsync();

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
