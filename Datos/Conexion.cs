using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //agregar using

namespace Datos
{
    
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;

        private Conexion()
        {
            this.Base = "mi_base_datos";
            this.Servidor = "MSI\\SQLEXPRESS";
            this.Usuario = "sa";
            this.Clave = "fede";
        }

        //metodo crear conexion
        public SqlConnection Crear_conexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + 
                                          "; Database=" + this.Base + 
                                          "; User Id=" + this.Usuario + 
                                          "; Password=" + this.Clave; 
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }
        //metodo estabelcer conexion
        public static Conexion GetConexion()
        {
            if(Con == null)
            {
                Con = new Conexion();   
            }
            return Con;
        }
    }
}
