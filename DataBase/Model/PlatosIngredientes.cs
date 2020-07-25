using System;
using System.Collections.Generic;

namespace DataBase.Model
{
    public partial class PlatosIngredientes
    {
        public int IdPlatosIngredientes { get; set; }
        public int? IdIngredientes { get; set; }
        public int? IdPlatos { get; set; }

        public virtual Ingredientes IdIngredientesNavigation { get; set; }
        public virtual Platos IdPlatosNavigation { get; set; }
    }
}
