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
    public partial class VentaForm : Form
    {
        RecepcionistaForm recepcionistaForm;
        private Matafuego matafuegoElegido;
        private Empresa Empresa_;

        private List<Matafuego> matafuegosParaVenta = new List<Matafuego>();

        private Cliente Cliente_;
        private int selectedRowIndex = -1;

        public VentaForm(Empresa empresa,RecepcionistaForm recepcionistaForm)
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VentaForm_FormClosing);
            this.recepcionistaForm = recepcionistaForm;
            this.Empresa_ = empresa;

            foreach (var matafuego in Empresa_.MatafuegosList)
            {
                dgvSeleccion.Rows.Add(matafuego.DeterminarTipo(), matafuego.Peso, matafuego.PrecioVenta);
            }

            dgvSeleccion.CellClick += dgvSeleccion_CellClick;
            button1.Click += button1_Click;

            Cliente_ = Empresa_.Clientes[Empresa_.Clientes.Count - 1];
        }


        //seleccionar
        private void button1_Click(object sender, EventArgs e)
        {
            if (matafuegoElegido != null)
            {
                // Agrega el producto seleccionado al segundo DataGridView
                dataGridView2.Rows.Add(matafuegoElegido.DeterminarTipo(), matafuegoElegido.Peso, matafuegoElegido.PrecioVenta);

                matafuegosParaVenta.Add(matafuegoElegido);
                // Limpia la selección
                matafuegoElegido = null;

                lblTotal.Text = $"{CalcularTotalCarrito()}";
            }
          
        }

        private void dgvSeleccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que se selecciona una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dgvSeleccion.Rows.Count -1)
            {
                selectedRowIndex= e.RowIndex;
                // Guarda el producto de la fila seleccionada
                matafuegoElegido = Empresa_.MatafuegosList[e.RowIndex];
            }
            else
            {
                MessageBox.Show("Elija una fila valida");
            }
        }

        //vender
        private void button2_Click(object sender, EventArgs e)
        {
            double CostoTotalVenta = Empresa_.VenderMatafuego(matafuegosParaVenta, Cliente_);
            Factura factura = new Factura(Empresa_);
            factura.Show();
            this.MinimizeBox = true;
        }

        private double CalcularTotalCarrito()
        {
            return matafuegosParaVenta.Sum(matafuego => matafuego.PrecioVenta);
        }
        
        //flecha volver al menu anterior
        private void button3_Click(object sender, EventArgs e)
        {
            recepcionistaForm.Show();
            this.Close();
        }
        private void VentaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
