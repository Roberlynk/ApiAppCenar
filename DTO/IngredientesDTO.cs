using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class IngredientesDTO
    {
        public int IdIngredientes { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

    }
}
