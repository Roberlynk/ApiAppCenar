using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class MesasDTO
    {
        public int IdMesas { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? CantidadP { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Estado { get; set; }
    }
}
