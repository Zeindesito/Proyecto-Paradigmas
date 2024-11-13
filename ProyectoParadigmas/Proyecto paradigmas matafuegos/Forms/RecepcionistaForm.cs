using Proyecto_paradigmas_matafuegos.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_paradigmas_matafuegos
{
    public partial class RecepcionistaForm : Form
    {
        Form1 form1;
        private List<Cliente> listaClientes= new List<Cliente>();
       
        public RecepcionistaForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource=listaClientes;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textNombre.Text) || string.IsNullOrEmpty(textApellido.Text) || string.IsNullOrEmpty(textDni.Text)) 
            {
                MessageBox.Show("Por favor, Complete todos los campos.");
            }
            else
            {
                Cliente nuevoCliente = new Cliente(textNombre.Text, textApellido.Text, textDni.Text);
                listaClientes.Add(nuevoCliente);
                textNombre.Clear();
                textApellido.Clear();
                textDni.Clear();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listaClientes;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServicioForm servicioForm= new ServicioForm();
            servicioForm.Show();
            this.Hide();
        }

        private void ButtonVenta_Click(object sender, EventArgs e)
        {
            VentaForm ventaForm = new VentaForm();
            ventaForm.Show();
            this.Hide();
        }
    }
}
