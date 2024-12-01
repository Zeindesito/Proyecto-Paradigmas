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
            if(ValidarCamposYCrearCliente() == true)
            {
                MostrarClientes();
                ServicioForm servicioForm = new ServicioForm(this, Empresa_);
                servicioForm.Show();
                this.Hide();
            }
            
        }

        //Venta
        private void ButtonVenta_Click(object sender, EventArgs e)
        {
            if (ValidarCamposYCrearCliente() == true)
            {
                MostrarClientes();
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

        public void MostrarClientes()
        {
            dataGridView1.Rows.Clear();
            foreach (var cliente in Empresa_.Clientes)
            {
                if (cliente.Matafuegos.Count > 0)
                {
                    foreach (var matafuego in cliente.Matafuegos)
                    {
                        dataGridView1.Rows.Add(cliente.Nombre, cliente.DNI, cliente.Email, matafuego.DeterminarTipo(), matafuego.Peso, matafuego.EtiquetaMatafuego.FechaVencimiento);
                    }
                }
                else
                {
                   dataGridView1.Rows.Add(cliente.Nombre, cliente.DNI, cliente.Email, "-", "-", "-");
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
        private bool BuscarCliente()
        {
            if(!EsDniValido(txtBuscarDni.Text))
            {
                MessageBox.Show("Por favor, ingrese un DNI válido en el formato ##.###.### para buscar.");
                return false;

            }
            var clienteEncontrado = Empresa_.Clientes.FirstOrDefault(item => item.DNI == txtBuscarDni.Text);

            if (clienteEncontrado != null)
            {
                // Eliminar y volver a agregar el cliente asi queda al final de la lista
                Empresa_.Clientes.Remove(clienteEncontrado);
                Empresa_.Clientes.Add(clienteEncontrado);

                MessageBox.Show("DNI encontrado y cliente actualizado.");
                return true;
            }
            else
            {
                MessageBox.Show("DNI no encontrado.");
                return false;

            }
           
        }

        private void agregarTecnicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarTecnicoForm agregarTecnicoForm = new AgregarTecnicoForm(this,Empresa_);
            agregarTecnicoForm.StartPosition = FormStartPosition.CenterParent;
            agregarTecnicoForm.ShowDialog();
        }

        private void agregarMatafuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarInventarioForm agregarInventarioForm = new AgregarInventarioForm(this, Empresa_);
            agregarInventarioForm.StartPosition = FormStartPosition.CenterParent;
            agregarInventarioForm.Show();
        }

        private bool ValidarCamposYCrearCliente()
        {
            if (string.IsNullOrEmpty(textNombre.Text) || string.IsNullOrEmpty(textApellido.Text) || string.IsNullOrEmpty(textDni.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {

                if (!string.IsNullOrWhiteSpace(txtBuscarDni.Text))
                {
                    if (BuscarCliente())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Por favor, Complete todos los campos.");
                    return false;
                }
                //montejo valida que el dni sea un numero valido
            }
            else
            {
                if(!EsDniValido(textDni.Text))
                {
                    MessageBox.Show("Por favor, ingrese un DNI válido en el formato ##.###.###");
                    return false;
                }
                if(!EsEmailValido(txtEmail.Text))
                {
                    MessageBox.Show("Ingrese un email valido");
                    return false;
                }

                CrearCliente();
                MessageBox.Show("Cliente creado con exito");
                return true;
            }
        }
        //validar email
        private bool EsEmailValido(string email)
        {
            try
            {
                var direccion = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //validar que el dni tenga formato ##.###.###
        private bool EsDniValido(string dni)
        {
            // Validar longitud
            if (dni.Length != 10)
                return false;

            // Validar formato (##.###.###)
            if (dni[2] != '.' || dni[6] != '.')
                return false;

            // Validar que los caracteres sean números o puntos
            foreach (char c in dni)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
