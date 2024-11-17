using Proyecto_paradigmas_matafuegos.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_paradigmas_matafuegos
{
    public partial class RecepcionistaForm : Form
    {
        public Empresa Empresa_ { get; set; }
        Form1 form1;
        public RecepcionistaForm(Form1 form1, Empresa empresa)
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecepcionistaForm_FormClosing);

            this.form1 = form1;
            Empresa_ = empresa;
            MostrarClientes();
        }

        //Recarga
        private void button1_Click(object sender, EventArgs e)
        {
            CrearCliente();
            ServicioForm servicioForm = new ServicioForm(this, Empresa_);
            servicioForm.Show();
            this.Hide();
        }

        //Venta
        private void ButtonVenta_Click(object sender, EventArgs e)
        {
            CrearCliente();
            VentaForm ventaForm = new VentaForm(Empresa_, this);
            ventaForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Close();
        }

        private void MostrarClientes()
        {
            foreach (var cliente in Empresa_.Clientes)
            {
                foreach (var matafuego in cliente.Matafuegos)
                {
                    dataGridView1.Rows.Add(cliente.Nombre, cliente.Email, matafuego.DeterminarTipo(), matafuego.Peso, matafuego.EtiquetaMatafuego.FechaVencimiento);
                }

            }

        }

        private void CrearCliente()
        {
            if (string.IsNullOrEmpty(textNombre.Text) || string.IsNullOrEmpty(textApellido.Text) || string.IsNullOrEmpty(textDni.Text))
            {
                MessageBox.Show("Por favor, Complete todos los campos.");
            }
            else
            {
                Empresa_.AñadirCliente(new Cliente(textNombre.Text, textApellido.Text, textDni.Text, txtEmail.Text, new List<Matafuego>()));
                textNombre.Clear();
                textApellido.Clear();
                textDni.Clear();

                dataGridView1.Rows.Clear();
                MostrarClientes();

            }
        }

        private void clientesCargadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void RecepcionistaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }

    }
}
