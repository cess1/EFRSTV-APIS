using PrjFlowersshoesAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace PrjFlowersshoesAPI.DAO
{
    public class TallasDAO
    {
        public string cad_sql { get; set; } = string.Empty;

        public TallasDAO(IConfiguration cfg)
        {
            cad_sql = cfg.GetConnectionString("cn1");
        }

        public List<Tallas> GetTallas()
        {
            var list = new List<Tallas>();

            using (SqlDataReader rd = SqlHelper.ExecuteReader(cad_sql, "PA_LISTAR_TALLAS"))
            {
                while (rd.Read())
                {
                    list.Add(new Tallas()
                    {
                        idtalla = rd.GetInt32(0),
                        talla = rd.GetString(1)
                    });
                }
            }

            return list;
        }



        public string GrabarTalla(Tallas obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@talla", obj.talla));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_GRABAR_TALLA", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

        public string ActualizarTalla(Tallas obj)
        {
            string mensaje = "";

            List<KeyValuePair<string, object>> parametros = new List<KeyValuePair<string, object>>();
            parametros.Add(new KeyValuePair<string, object>("@idtalla", obj.idtalla));
            parametros.Add(new KeyValuePair<string, object>("@talla", obj.talla));

            try
            {
                mensaje = SqlHelper.ExecuteNonQuery2(cad_sql, "PA_MODIFICAR_TALLA", parametros);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

        public string EliminarTalla(int id)
        {
            string mensaje = "";

            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_ELIMINAR_TALLA", id);
                mensaje = "Talla Eliminada correctamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

        public string RestaurarTalla(int id)
        {
            string mensaje = "";

            try
            {
                SqlHelper.ExecuteNonQuery(cad_sql, "PA_RESTAURAR_TALLA", id);
                mensaje = "Talla Restaurada correctamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }
    }
}
