using System;
using System.Data;
using Datos;
using Entidades;


namespace Negocio
{
    public class N_categoria
    {
        public static DataTable Listar_ca(string cTexto)
        {
            D_categoria Datos = new D_categoria();  
            return Datos.Listar_ca(cTexto);
        }

        public static string Guardar_ca(int Opcion, E_categoria obj_ca)
        {
            D_categoria Datos = new D_categoria();
            return Datos.Guardar_ca(Opcion, obj_ca);
        }
    }
}
