using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class PlatosDTO
    {
        public int IdPlatos { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? Limite { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Categoria { get; set; }

        public List<IngredientesDTO> Ingredientes { get; set; }
    }
}
