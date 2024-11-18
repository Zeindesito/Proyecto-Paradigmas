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
            this.form1 = form1;
            Empresa_ = empresa;
            MostrarClientes();
        }

        //Recarga
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBuscarDni.Text == "")
            {
                CrearCliente();
            }
            if (txtBuscarDni.Text != "")
            {
                BuscarCliente();
            }
            
            MostrarClientes();
            ServicioForm servicioForm = new ServicioForm(this, Empresa_);
            servicioForm.Show();
            this.Hide();
        }

        //Venta
        private void ButtonVenta_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrEmpty(textNombre.Text) || string.IsNullOrEmpty(textApellido.Text) || string.IsNullOrEmpty(textDni.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {

                if (!string.IsNullOrWhiteSpace(txtBuscarDni.Text))
                {
                    BuscarCliente();
                }
                else
                {
                    MessageBox.Show("Por favor, Complete todos los campos.");
                    return;
                }

                //montejo valida que el dni sea un numero valido


            }
            else
            {
                //Que se mida la longitud del dni
                CrearCliente();
                VentaForm ventaForm = new VentaForm(Empresa_, this);
                ventaForm.Show();
                this.Hide();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void MostrarClientes()
        {
            foreach (var cliente in Empresa_.Clientes)
            {
                foreach (var matafuego in cliente.Matafuegos)
                {
                    dataGridView1.Rows.Add(cliente.Nombre, cliente.DNI, cliente.Email, matafuego.DeterminarTipo(), matafuego.Peso, matafuego.EtiquetaMatafuego.FechaVencimiento);
                }

            }

        }

        private void CrearCliente()
        {
                Empresa_.AñadirCliente(new Cliente(textNombre.Text, textApellido.Text, textDni.Text, txtEmail.Text, new List<Matafuego>()));
                textNombre.Clear();
                textApellido.Clear();
                textDni.Clear();
                txtEmail.Clear();

                dataGridView1.Rows.Clear();
                MostrarClientes();
        }

        private void RecepcionistaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void RecepcionistaForm_Load(object sender, EventArgs e)
        {

        }

        private void BuscarCliente()
        {

            var clienteEncontrado = Empresa_.Clientes.FirstOrDefault(item => item.DNI == txtBuscarDni.Text);

            if (clienteEncontrado != null)
            {
                // Eliminar y volver a agregar el cliente
                Empresa_.Clientes.Remove(clienteEncontrado);
                Empresa_.Clientes.Add(clienteEncontrado);

                MessageBox.Show("DNI encontrado y cliente actualizado.");
                VentaForm ventaForm = new VentaForm(Empresa_, this);
                ventaForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("DNI no encontrado.");

            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
