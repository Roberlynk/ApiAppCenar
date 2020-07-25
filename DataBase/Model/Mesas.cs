using System;
using System.Collections.Generic;

namespace DataBase.Model
{
    public partial class Mesas
    {
        public Mesas()
        {
            Ordenes = new HashSet<Ordenes>();
        }

        public int IdMesas { get; set; }
        public int? CantidadP { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Ordenes> Ordenes { get; set; }
    }
}
