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
    public partial class frmProd: Form
    {
        int id = 0;
        bool flag = false;

        public frmProd()
        {
            InitializeComponent();
        }

        // actualizar
        public frmProd(int id, string nombre, string descripcion, double precio,
            int stock, string categoria, string fecha)
        {
            InitializeComponent();

            this.id = id;
            tbID.Text = id.ToString();

            tbNombre.Text = nombre;
            rtbDescripcion.Text = descripcion;
            tbPrecio.Text = precio.ToString();
            nudStock.Value = stock;
            tbCategoría.Text = categoria;
            dtpFecha.Value = DateTime.Parse(fecha);

            flag = true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (flag == true)
                /*inserto los valores en funciones diferentes*/
            {
                tbID.Enabled = false;
                // actualizar
                string sql = "UPDATE productos SET " +
                    $"nombre='{tbNombre.Text}'," +
                    $"descripcion='{rtbDescripcion.Text}'," +
                    $"precio='{tbPrecio.Text}'," +
                    $"stock='{nudStock.Value.ToString()}'," +
                    $"categoria='{tbCategoría.Text}'," +
                    $"fechaCreacion='{dtpFecha.Value.ToString("yyyy-MM-dd")}' " +
                    $"where id='{id}'";
                Datos dt = new Datos();
                dt.executeCmd(sql);

                MessageBox.Show("Datos actualizados");
            }
            else {
                // insertar
                string sql = "INSERT INTO productos(nombre,descripcion,precio,stock,categoria,fechaCreacion) " +
                    "VALUES (" +
                    $"'{tbNombre.Text}','{rtbDescripcion.Text}','{tbPrecio.Text}'," +
                    $"'{nudStock.Value.ToString()}','{tbCategoría.Text}'," +
                    $"'{dtpFecha.Value.ToString("yyyy-MM-dd")}');";
                Datos dt = new Datos();
                dt.executeCmd(sql);

                MessageBox.Show("Datos insertados");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
