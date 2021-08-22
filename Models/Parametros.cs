using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace MvcMovie.Models
{
    public class Parametros
    {
        SqlConnection con;
        string Valor;
        public  string Parametro(string Propiedad)
        {
            var configuracion = GetConfiguration();

            Valor = configuracion.GetSection("Data").GetSection("ConnectionString").Value;

            return Valor;
            /*var configuracion = GetConfiguration();

             * con = new SqlConnection(configuracion.GetSection("Data").GetSection("ConnectionString").Value); -- works */
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
