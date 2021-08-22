using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;*/

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public /*string*/ IActionResult Index()
        {
            return View();
            /*return "Esta es la accion default";*/

        }

        public /*string*/ IActionResult Welcome(string Par_Nombre, int Par_NumVeces =1)
        {
            ViewData["Var_Mensaje"] = "Hola" + Par_Nombre;
            ViewData["Var_NumVeces"] = Par_NumVeces;
            return View();

            /*return HtmlEncoder.Default.Encode($"Hola {Par_Nombre}, ID: {Par_NumVeces}");*/
            /*return HtmlEncoder.Default.Encode($"Hello {Par_Nombre},Numero de Veces es: {Par_NumVeces} ");*/
            /*return "Bienvenido a la App";*/
        }

        public string Bye()
        {
            return "Adios";
        }
        
    }
}
