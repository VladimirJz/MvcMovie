using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieModel
    {
        public int PeliculaID { get; set; }


        [Required(AllowEmptyStrings = true, ErrorMessage = "Debes ingresar un valor!")]
        [StringLength(25, ErrorMessage = "El titulo no debe ser mayor a 25!")]

        public string Titulo { get; set; }
        

        [DataType(DataType.Date)]  
        public DateTime FechaLanzamiento { get; set; }    


        public string Genero { get; set; }
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Solo se permiten dos decimales.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
    }

}
