using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieModel
    {
        public int PeliculaID { get; set; }
        public string Titulo { get; set; }
        
        [DataType(DataType.Date)]  public DateTime FechaLanzamiento { get; set; }    
        public string Genero { get; set; }
        public decimal Precio { get; set; }
    }

}
