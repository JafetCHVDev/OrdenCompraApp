using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NegocioBLL;
using OrdenCompraBEL;

namespace OrdenCompraUIL
{
    public partial class Form1 : Form
    {
        private Negocio negocio = new Negocio();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OrdenCompra ordenCompra = new OrdenCompra();
            ordenCompra.IdProveedor = int.Parse(txtIdProveedor.Text);
            ordenCompra.Descripcion = txtDescripcion.Text;
            ordenCompra.Estado = 1; // Estado inicial siempre es 1 (Activo)

            try
            {
                negocio.AgregarOrdenCompra(ordenCompra);
                MessageBox.Show("Orden de compra agregada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            OrdenCompra ordenCompra = new OrdenCompra();
            ordenCompra.NumeroOrden = int.Parse(txtNumeroOrden.Text);
            ordenCompra.IdProveedor = int.Parse(txtIdProveedor.Text);
            ordenCompra.Descripcion = txtDescripcion.Text;
            ordenCompra.Estado = int.Parse(txtEstado.Text);

            try
            {
                negocio.ModificarOrdenCompra(ordenCompra);
                MessageBox.Show("Orden de compra modificada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DataTable ordenesCompras = negocio.ConsultarOrdenesComprasActivas();
            dataGridView1.DataSource = ordenesCompras;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            OrdenCompra ordenCompra = new OrdenCompra();
            ordenCompra.NumeroOrden = int.Parse(txtNumeroOrden.Text);
            ordenCompra.IdProveedor = int.Parse(txtIdProveedor.Text);
            ordenCompra.Descripcion = txtDescripcion.Text;
            ordenCompra.Estado = int.Parse(txtEstado.Text);

            try
            {
                negocio.AgregarOrdenCompra(ordenCompra);
                MessageBox.Show("Orden de compra agregada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            OrdenCompra ordenCompra = new OrdenCompra();
            ordenCompra.NumeroOrden = int.Parse(txtNumeroOrden.Text);
            ordenCompra.IdProveedor = int.Parse(txtIdProveedor.Text);
            ordenCompra.Descripcion = txtDescripcion.Text;
            ordenCompra.Estado = int.Parse(txtEstado.Text);

            try
            {
                negocio.ModificarOrdenCompra(ordenCompra);
                MessageBox.Show("Orden de compra modificada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            DataTable ordenesCompras = negocio.ConsultarOrdenesComprasActivas();
            dataGridView1.DataSource = ordenesCompras;

        }
    }
}