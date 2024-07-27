using System;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace Presentacion
{
    public partial class frm_principal : Form
    {
        public frm_principal()
        {
            InitializeComponent();
        }
      
        
        //dar formado a las columnas de dgv
        private void Formato_Ca()
        {
            dgv_principal.Columns[0].Width = 80;
            dgv_principal.Columns[0].HeaderText = "Codigo";
            dgv_principal.Columns[1].Width = 250;
            dgv_principal.Columns[1].HeaderText = "Categoria";
        }
        
        //traer la info desde capa negocio
        private void Listado_ca(string cText)
        {
            dgv_principal.DataSource = Negocio.N_categoria.Listar_ca(cText); //pasar informacion al dgv
            this.Formato_Ca(); //funcion formato
        }
        

        //load
        private void frm_principal_Load(object sender, EventArgs e)
        {
            this.Listado_ca("%");
        }

        //button charge
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            E_categoria obj_ca = new E_categoria();
            obj_ca.id_ca = 1;
            obj_ca.descripcion_ca = txt_descripcion_ca.Text.Trim();
            respuesta = N_categoria.Guardar_ca(1, obj_ca);

            //validar si se cargo correctamente
            if (respuesta.Equals("OK"))
            {
                this.Listado_ca("%");
                MessageBox.Show("Se cargo correctamente", "Aviso del sistema:");
            }
        }

       //funcion buscar
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_ca(txt_buscar.Text.Trim());
        }
    }
}
