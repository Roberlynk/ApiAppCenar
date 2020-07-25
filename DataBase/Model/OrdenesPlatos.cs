using System;
using System.Collections.Generic;

namespace DataBase.Model
{
    public partial class OrdenesPlatos
    {
        public int IdOrdenesPlatos { get; set; }
        public int? IdOrdenes { get; set; }
        public int? IdPlatos { get; set; }

        public virtual Ordenes IdOrdenesNavigation { get; set; }
        public virtual Platos IdPlatosNavigation { get; set; }
    }
}
