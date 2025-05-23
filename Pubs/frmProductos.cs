using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen3
{
    public partial class frmProductos: Form
    {
        Datos dt = new Datos();
        public frmProductos()
        {
            InitializeComponent();
        }


        private void frmProductos_Load(object sender, EventArgs e)
        {
            actualizar();
        }

        private void actualizar() {
            DataSet ds;
            ds = dt.comando("select id as [No. Producto], nombre as [Nombre], descripcion as [Descripción], precio as [Precio], stock as [Almacén], categoria as [Categoría], fechaCreacion as [Fecha de Creación] from productos;");
            if (ds != null)
            {
                dgvProductos.DataSource = ds.Tables[0];
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds;
            ds = dt.comando("select id as [No. Producto], nombre as [Nombre], descripcion as [Descripción], precio as [Precio], stock as [Almacén], categoria as [Categoría], fechaCreacion as [Fecha de Creación] from productos" +
                $" WHERE nombre LIKE '{tbBuscar.Text}%';"
             );
            if (ds != null)
            {
                dgvProductos.DataSource = ds.Tables[0];
            }

        }

        // Actualizar
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = dgvProductos.CurrentRow.Index;
            
            frmProd unico = new frmProd(
                    Convert.ToInt32(dgvProductos.Rows[i].Cells[0].Value), //id
                    dgvProductos.Rows[i].Cells[1].Value.ToString(), // nombre
                    dgvProductos.Rows[i].Cells[2].Value.ToString(), // descripcion
                    Convert.ToDouble(dgvProductos.Rows[i].Cells[3].Value), // precio
                    Convert.ToInt32(dgvProductos.Rows[i].Cells[4].Value), // stock
                    dgvProductos.Rows[i].Cells[5].Value.ToString(), // categoria
                    dgvProductos.CurrentRow.Cells[6].Value.ToString() // fecha de creacion
            );

            unico.Show();
        }

        // Eliminar
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int i = dgvProductos.CurrentRow.Index;
            DialogResult f = MessageBox.Show("Eliminar producto: " + dgvProductos.Rows[i].Cells[1].Value.ToString() + "?","Eliminar",MessageBoxButtons.YesNo);

            if (f == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvProductos.Rows[i].Cells[0].Value);
                string comando = $"DELETE FROM productos WHERE id={id}";
                dt.executeCmd(comando);
                MessageBox.Show("Datos eliminados");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProd unique = new frmProd();
            unique.Show();
        }

        private void frmProductos_Activated(object sender, EventArgs e)
        {
            actualizar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            rptProductos rp = new rptProductos();
            rp.Show();
        }

        private void cmsProductos_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
