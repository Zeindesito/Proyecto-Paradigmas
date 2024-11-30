using Proyecto_paradigmas_matafuegos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_paradigmas_matafuegos.Forms
{
    public partial class AgregarInventarioForm : Form
    {
        RecepcionistaForm recepcionistaForm;
        private Empresa Empresa_;
        private int selectedRowIndex = -1;
        private Matafuego MatafuegoElegido;
        public AgregarInventarioForm(RecepcionistaForm recepcionistaForm, Empresa empresa)
        {
            InitializeComponent();
            this.recepcionistaForm = recepcionistaForm;
            Empresa_ = empresa;
            MostrarMatafuegos();
        }


        //cargar al inventario
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cbxTipo.Text))
            {
                MessageBox.Show("Por favor, seleccione un tipo de matafuego.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtColorArosello.Text))
            {
                MessageBox.Show("Por favor, ingrese el color del arosello.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(cbxPeso.Text, out double peso) || peso <= 0)
            {
                MessageBox.Show("Por favor, ingrese un peso válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtPrecio.Text, out double precio) || precio <= 0)
            {
                MessageBox.Show("Por favor, ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Matafuego matafuego = null;
            

            switch (cbxTipo.Text)
            {
                case "ABC":
                    matafuego = new Matafuego_ABC(true, txtColorArosello.Text, true, peso, "Verde", Convert.ToDouble(txtPrecio.Text));
                    break;

                case "K":
                    matafuego = new Matafuego_K(txtColorArosello.Text, true, true, "Verde", peso, Convert.ToDouble(txtPrecio.Text));
                    break;

                case "CO2":
                    matafuego = new Matafuego_CO2(txtColorArosello.Text, true, peso, Convert.ToDouble(txtPrecio.Text));
                    break;

                default:
                    MessageBox.Show("El tipo de matafuego seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            precio = 0;
            matafuego.EtiquetaMatafuego.Rellenar(dateTimePicker1.Value.Date, dateTimePicker1.Value.Date.AddYears(1), matafuego.DeterminarTipo());
            Empresa_.AñadirMatafuego(matafuego);
            MostrarMatafuegos();
            MessageBox.Show("Matafuego añadido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //eliminar
        private void button3_Click(object sender, EventArgs e)
        {
            if (MatafuegoElegido != null)
            {
                Empresa_.MatafuegosList.RemoveAt(selectedRowIndex);
                // Limpia la selección
                MatafuegoElegido = null;
                // Agrega el producto seleccionado al DataGridView
                MostrarMatafuegos();
                MessageBox.Show("Matafuego eliminado con éxito");
            }
        }

        private void MostrarMatafuegos()
        {
            dataGridView1.Rows.Clear();
            foreach (var matafuego in Empresa_.MatafuegosList)
            {
                dataGridView1.Rows.Add(matafuego.DeterminarTipo(), matafuego.Peso, matafuego.PrecioVenta, matafuego.Arosello_Precinto, matafuego.EtiquetaMatafuego.FechaRevision, matafuego.EtiquetaMatafuego.FechaVencimiento);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que se selecciona una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                selectedRowIndex = e.RowIndex;
                // Guarda el producto de la fila seleccionada
                MatafuegoElegido = Empresa_.MatafuegosList[e.RowIndex];

            }
            else
            {
                MessageBox.Show("Elija una fila valida");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            recepcionistaForm.Show();
            this.Hide();
        }
    }
}
