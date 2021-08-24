using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;


namespace MvcMovie.Models
{
    public class MovieDBHandler
    {
        private SqlConnection con;
        Parametros App = new Parametros();
        private void Connection() 
        {
            /*string constring = ConfigurationManager.ConnectionStrings["OtraBase"].ToString();*/

            /*string constring = "Server=172.16.20.3;Database=TESTING;User Id=app;Password=#1Qazse4#;MultipleActiveResultSets=true;";
            
            con = new SqlConnection(constring);*/
            con = new SqlConnection(App.Parametro("CadenaConexion"));
        }

        public bool AgregaPelicula(MovieModel moviemodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("PELICULAALT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Par_PeliculaID", moviemodel.PeliculaID);
            cmd.Parameters.AddWithValue("@Par_Titulo", moviemodel.Titulo);
            cmd.Parameters.AddWithValue("@Par_FechaLanzamiento", moviemodel.FechaLanzamiento);
            cmd.Parameters.AddWithValue("@Par_Genero", moviemodel.Genero);
            cmd.Parameters.AddWithValue("@Par_Precio", moviemodel.Precio);

            con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i >= 1)
                return true;
            else
                return false;

        }
        public List<MovieModel> ListaPeliculas() 
        {
            Connection();
            List<MovieModel> ListaPeliculas = new List<MovieModel>();
            SqlCommand cmd = new SqlCommand("PELICULALIST",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                ListaPeliculas.Add(
                    new MovieModel
                    {
                      
                        
                        PeliculaID =Convert.ToInt32(dr["PeliculaID"]),
                        Titulo = Convert.ToString(dr["Titulo"]),
                        FechaLanzamiento=Convert.ToDateTime(dr["FechaLanzamiento"]),
                        Genero=Convert.ToString(dr["Genero"]),
                        Precio=Convert.ToDecimal(dr["Precio"])
                        
                    });
            }
            return ListaPeliculas;



        }
        public bool ActualizaPelicula(MovieModel moviemodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("PELICULAMOD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Par_PeliculaID", moviemodel.PeliculaID);
            cmd.Parameters.AddWithValue("@Par_Titulo", moviemodel.Titulo);
            cmd.Parameters.AddWithValue("@Par_FechaLanzamiento", moviemodel.FechaLanzamiento);
            cmd.Parameters.AddWithValue("@Par_Genero", moviemodel.Genero);
            cmd.Parameters.AddWithValue("@Par_Precio", moviemodel.Precio);

            con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
