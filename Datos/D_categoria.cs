using System.Data;
using System.Data.SqlClient;
using System;
using Entidades; 


namespace Datos
{
    public class D_categoria
    {
        public DataTable Listar_ca(string cTexto)
        {
            SqlDataReader Resultado; //recibe los datos sql
            DataTable mi_tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection(); //conexion 
            try
            {
                sqlCon = Conexion.GetConexion().Crear_conexion();
                SqlCommand Comando = new SqlCommand("USP_listado_ca", sqlCon);
                Comando.CommandType = CommandType.StoredProcedure; //la forma mediante un procedimiento
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;  //tipo de dato usado en sql
                sqlCon.Open();
                Resultado = Comando.ExecuteReader(); //se guarda la info
                mi_tabla.Load(Resultado); //envia la info a la tabla
                return mi_tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally //cerrar en caso que este abierto la conexion
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        public string Guardar_ca(int Opcion, E_categoria obj_ca)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection(); //conexion
            try
            {

                sqlCon = Conexion.GetConexion().Crear_conexion();
                SqlCommand Comando = new SqlCommand("USP_guardar_ca", sqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Opcion", SqlDbType.Int).Value = Opcion;
                Comando.Parameters.Add("@id_ca", SqlDbType.Int).Value = obj_ca.id_ca;
                Comando.Parameters.Add("@descripcion_ca", SqlDbType.VarChar).Value = obj_ca.descripcion_ca;
                sqlCon.Open();
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo registrar el proceso";
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                if(sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return respuesta;
        }
    }
}
