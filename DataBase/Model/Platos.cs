using System;
using System.Collections.Generic;

namespace DataBase.Model
{
    public partial class Platos
    {
        public int IdPlatos { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int? Limite { get; set; }
        public string Categoria { get; set; }
    }
}
