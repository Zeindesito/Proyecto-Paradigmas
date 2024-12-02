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
        private int selectedRowIndex = -1;
        private Matafuego MatafuegoElegido;

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

            //guardo el cliente a realizarle el servicio
            ClienteServicio = empresa_.Clientes.Last();

            //guardo la lista que ya tenia de matafuegos
            ListaMatafuego = ClienteServicio.Matafuegos;

            //Borro la lista de matafugos que tenia cliente
            ClienteServicio.Matafuegos = new List<Matafuego>();

        }

        //agregar matafuego
        private void button3_Click(object sender, EventArgs e)
        {
            if (cbxTipo.SelectedIndex == -1 || cbxPeso.SelectedIndex == -1 || string.IsNullOrEmpty(txtColorArosello.Text))
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
                        Matafuego_ = new Matafuego_ABC(false, txtColorArosello.Text, false, Convert.ToDouble(cbxPeso.Text), "---", 0, "Avalle");
                        break;

                    case "K":
                        Matafuego_ = new Matafuego_K(txtColorArosello.Text, false, false, "---", Convert.ToDouble(cbxPeso.Text), 0, "Avalle");
                        break;

                    case "CO2":
                        Matafuego_ = new Matafuego_CO2(txtColorArosello.Text, false, Convert.ToDouble(cbxPeso.Text), 0, "Avalle");
                        break;
                }
                //le cargo los matafuegos al cliente
                ClienteServicio.Matafuegos.Add(Matafuego_);


                Mostrar();
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

                // Crear el servicio con el técnico seleccionado
                Servicio servicio = new Servicio(tecnico, ClienteServicio, DateTime.Now);

                //Recargo los matafuegos
                servicio.RealizarRecarga(ClienteServicio, tecnico, DateTime.Now, txtColorArosello.Text, ClienteServicio.Matafuegos);
                //añado el servicio a la lista de la empresa
                empresa_.CargarServicio(servicio);

                //imprimo la factura          //le paso la lista de matafuegos original que tenia
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

            if (ListaMatafuego == null || ListaMatafuego.Count == 0)
            {
                empresa_.Clientes.Remove(ClienteServicio);
                MessageBox.Show($"Cliente {ClienteServicio.Nombre} eliminado por no realizar operacion");
            }


            ClienteServicio.Matafuegos = ListaMatafuego;
            recepcionistaForm.Empresa_ = empresa_;
            recepcionistaForm.Show();
            recepcionistaForm.MostrarClientes();

            this.Hide();
        }
        private void ServicioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //eliminar
        private void button1_Click(object sender, EventArgs e)
        {
            if (MatafuegoElegido != null)
            {
                ClienteServicio.Matafuegos.RemoveAt(selectedRowIndex);
                // Limpia la selección
                MatafuegoElegido = null;
                // Agrega el producto seleccionado al DataGridView
                Mostrar();
                MessageBox.Show("Matafuego eliminado con éxito");
            }
            else
            {
                MessageBox.Show("Seleccione un matafuego para eliminar.");
            }
        }

        //seleccionar

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que se selecciona una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                selectedRowIndex = e.RowIndex;
                // Guarda el producto de la fila seleccionada
                MatafuegoElegido = ClienteServicio.Matafuegos[e.RowIndex];
            }
            else
            {
                MessageBox.Show("Elija una fila valida");
            }


        }
        
        private void Mostrar()
        {
            //muestro en el datagridview
            dataGridView1.Rows.Clear();
            double Total = 0;
            foreach (var item in ClienteServicio.Matafuegos)
            {
                dataGridView1.Rows.Add(item.DeterminarTipo(), item.Peso, item.PrecioRecarga, DateTime.Now.AddYears(1));

                //cargo el total
                Total += item.PrecioRecarga;
            }
            lblTotal.Text = Total.ToString();
        }
    }
}
