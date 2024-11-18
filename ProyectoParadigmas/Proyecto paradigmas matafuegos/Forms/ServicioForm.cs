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
        }

        //agregar matafuego
        private void button3_Click(object sender, EventArgs e)
        {
            ClienteServicio = empresa_.Clientes.Last();

            if (cbxTipo.SelectedIndex == -1 || cbxPeso.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de matafuego, su peso y su color de arosello");
                return;
            }
            else
            {
                switch (cbxTipo.Text)
                {
                    case "ABC":
                        ClienteServicio.Matafuegos.Add(new Matafuego_ABC(false, txtColorArosello.Text, false, Convert.ToDouble(cbxPeso.Text), "---"));
                        break;

                    case "K":
                        ClienteServicio.Matafuegos.Add(new Matafuego_K(txtColorArosello.Text, false, false, "---", Convert.ToInt32(cbxPeso.Text)));
                        break;

                }
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

        private void ServicioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recepcionistaForm.Show();
            this.Hide();
        }

        private void ServicioForm_Load(object sender, EventArgs e)
        {

        }

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

                Factura factura = new Factura(empresa_);
                factura.Show();
            }
            else
            {
                MessageBox.Show("No se encontró el técnico en la lista.");
            }
        }

        /*para despues va a servir
                         Random random = new Random();

                // Obtener un índice aleatorio
                int indiceAleatorio = random.Next(empresa_.TecnicoList.Count);

                // Seleccionar el elemento aleatorio
                Tecnico tenico = empresa_.TecnicoList[indiceAleatorio];
        */
    }
}
