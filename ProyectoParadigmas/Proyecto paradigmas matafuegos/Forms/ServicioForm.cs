using Proyecto_paradigmas_matafuegos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_paradigmas_matafuegos.Forms
{
    public partial class ServicioForm : Form
    {
        RecepcionistaForm recepcionistaForm;
        private Empresa empresa_;
        private Cliente ClienteServicio;
        private List<Matafuego> ListaMatafuego;
        public ServicioForm(RecepcionistaForm recepcionistaForm, Empresa empresa)
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServicioForm_FormClosing);
            this.recepcionistaForm = recepcionistaForm;
            empresa_ = empresa;

            //Cargo el combobox de tecnicos
            foreach (var tecnico in empresa_.TecnicoList)
            {
                cbxTenicos.Items.Add(tecnico.ApellidoYnombre());
            }

            ClienteServicio = empresa_.Clientes.Last();
            ListaMatafuego = ClienteServicio.Matafuegos;
            ClienteServicio.Matafuegos = new List<Matafuego>();
        }

        //agregar matafuego
        private void button3_Click(object sender, EventArgs e)
        {
            if (cbxTipo.SelectedIndex == -1 || cbxPeso.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de matafuego, su peso y su color de arosello");
                return;
            }
            else
            {
                Matafuego Matafuego_ = null;
               switch (cbxTipo.Text)
               {
                    case "ABC":
                        Matafuego_ = new Matafuego_ABC(false, txtColorArosello.Text, false, Convert.ToDouble(cbxPeso.Text), "---", 0);
                        break;

                    case "K":
                        Matafuego_ = new Matafuego_K(txtColorArosello.Text, false, false, "---", Convert.ToDouble(cbxPeso.Text), 0);
                        break;

                    case "CO2":
                        Matafuego_ = new Matafuego_CO2(txtColorArosello.Text, false, Convert.ToDouble(cbxPeso.Text), 0);
                        break;
               }
                DateTime fecha;
                fecha = DateTime.Now;
                Matafuego_.EtiquetaMatafuego.Rellenar(fecha, fecha.AddYears(1), Matafuego_.DeterminarTipo());
                ClienteServicio.Matafuegos.Add(Matafuego_);

                dataGridView1.Rows.Clear();

                double Total = 0;
                foreach (var item in ClienteServicio.Matafuegos)
                {
                    dataGridView1.Rows.Add(item.DeterminarTipo(), item.Peso, item.PrecioRecarga);
                    Total += item.PrecioRecarga;
                }
                lblTotal.Text = Total.ToString();
            }
            

            

        }

        //Recargar matafuego
        private void btnRealizarServicio_Click(object sender, EventArgs e)
        {
            if (cbxTenicos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un tecnico");
                return;
            }

            // Obtener el nombre del técnico seleccionado
            string tecnicoSeleccionadoNombre = cbxTenicos.SelectedItem.ToString();

            // Buscar el técnico en la lista
            var tecnico = empresa_.TecnicoList.FirstOrDefault(t => t.ApellidoYnombre() == tecnicoSeleccionadoNombre);

            if (tecnico != null)
            {
                MessageBox.Show($"Técnico seleccionado: {tecnico.ApellidoYnombre()}");

                // Crear el servicio con el técnico seleccionado
                empresa_.ServiciosRealizados.Add(new Servicio(tecnico, ClienteServicio, DateTime.Now));
                Factura factura = new Factura(empresa_, ListaMatafuego,recepcionistaForm);
                factura.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se encontró el técnico en la lista.");
            }
        }

        //Volver
        private void button2_Click(object sender, EventArgs e)
        {

            if (ListaMatafuego == null || !ListaMatafuego.Any())
            {
                empresa_.Clientes.Remove(ClienteServicio);
            }
            recepcionistaForm.Show();
            recepcionistaForm.Empresa_ = empresa_;
            recepcionistaForm.MostrarClientes();

            this.Hide();
        }
        private void ServicioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
