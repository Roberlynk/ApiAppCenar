using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class OrdenesDTO
    {
        public int IdOrdenes { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? IdMesas { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public decimal? SubTotal { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public bool? Estado { get; set; }
    }
}
