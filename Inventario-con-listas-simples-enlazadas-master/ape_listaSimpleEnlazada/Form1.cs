using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ape_listaSimpleEnlazada
{
    public partial class Form1 : Form
    {
        Inventario inventario = new Inventario();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (vacio())
                MessageBox.Show("Favor de llenar los campos incompletos. Gracias.");
            else
            {
                int vCodigo = Convert.ToInt16(txtCodigo.Text);
                string vNombre = txtNombre.Text;
                double vPrecio = Convert.ToDouble(txtPrecio.Text);
                int vCantidad = Convert.ToInt16(txtCantidad.Text);

                inventario.agregar(new Producto(vCodigo, vNombre, vPrecio, vCantidad));
                limpiarTXT();
            }
        }

        private void btnAgregarEnInicio_Click(object sender, EventArgs e)
        {
            if (vacio())
                MessageBox.Show("Favor de llenar los campos incompletos. Gracias.");
            else
            {
                int vCodigo = Convert.ToInt16(txtCodigo.Text);
                string vNombre = txtNombre.Text;
                double vPrecio = Convert.ToDouble(txtPrecio.Text);
                int vCantidad = Convert.ToInt16(txtCantidad.Text);

                inventario.agregarEnInicio(new Producto(vCodigo, vNombre, vPrecio, vCantidad));
                limpiarTXT();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (vacio())
                MessageBox.Show("Favor de llenar los campos incompletos. Gracias.");
            else
            {
                int vCodigo = Convert.ToInt16(txtCodigo.Text);
                string vNombre = txtNombre.Text;
                double vPrecio = Convert.ToDouble(txtPrecio.Text);
                int vCantidad = Convert.ToInt16(txtCantidad.Text);

                inventario.insertar(new Producto(vCodigo, vNombre, vPrecio, vCantidad), Convert.ToInt16(txtInsertar.Text));
                limpiarTXT();
                txtInsertar.Text = "";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Favor de escribir el código del producto a buscar.");
            else
                if (inventario.buscar(Convert.ToInt16(txtCodigo.Text)) == null)
                    MessageBox.Show("El producto no existe.");
                else
                    txtReporte.Text = inventario.buscar(Convert.ToInt16(txtCodigo.Text)).ToString();

            limpiarTXT();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Favor de escribir el código del producto a eliminar.");
            else
            {
                if (inventario.eliminar(Convert.ToInt16(txtCodigo.Text)))
                {
                    MessageBox.Show("Producto eliminado.");
                    txtReporte.Text = inventario.mostrar();
                }
                else
                    MessageBox.Show("El producto no existe.");
            }

            limpiarTXT();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = inventario.mostrar();
        }

        public bool vacio()
        {
            if (txtCodigo.Text == "" || txtNombre.Text == "" || txtPrecio.Text == "" || txtCantidad.Text == "")
                return true;
            else
                return false;
        }

        public void limpiarTXT()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }
    }
}
