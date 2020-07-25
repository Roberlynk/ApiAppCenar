using System;
using System.Collections.Generic;

namespace DataBase.Model
{
    public partial class Ordenes
    {
        public int IdOrdenes { get; set; }
        public int? IdMesas { get; set; }
        public decimal? SubTotal { get; set; }
        public bool? Estado { get; set; }

        public virtual Mesas IdMesasNavigation { get; set; }
    }
}
