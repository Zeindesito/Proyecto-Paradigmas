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
        private List<Cliente> listaClientes;
        private List<Tecnico> Tecnicos;
        private List<Matafuego> Matafuegos;
        public Empresa empresa;
        public RecepcionistaForm()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = listaClientes;

            listaClientes = new List<Cliente>
            {
            new Cliente("Juan", "Frias", "40.211.195"),
            new Cliente("Pedro", "Perez", "22.125.875")
            };

            Tecnicos = new List<Tecnico>
            {
            new Tecnico("Matias", "Gonzalez", "45.557.102"),
            new Tecnico("Agustin", "Montejo", "44.512.122")

            };
            Matafuegos = new List<Matafuego>
            {
                new Matafuego_K(new Etiqueta(), "Rojo", true, true, "Verde", 5)
            };


            empresa = new Empresa(Tecnicos, listaClientes, Matafuegos);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textNombre.Text) || string.IsNullOrEmpty(textApellido.Text) || string.IsNullOrEmpty(textDni.Text)) 
            {
                MessageBox.Show("Por favor, Complete todos los campos.");
            }
            else
            {
                empresa.AñadirCliente(new Cliente(textNombre.Text, textApellido.Text, textDni.Text), new List<Matafuego>());
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
            VentaForm ventaForm = new VentaForm(empresa);
            ventaForm.Show();
            this.Hide();
        }
    }
}
