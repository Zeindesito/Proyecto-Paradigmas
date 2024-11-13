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
        private Matafuego matafuegoElegido;
        private Empresa Empresa_;

        private List<Matafuego> matafuegosParaVenta = new List<Matafuego>();

        private Cliente Cliente_;
        private int selectedRowIndex = -1;

        public VentaForm(Empresa empresa)
        {
            InitializeComponent();
            
            Empresa_ = empresa;
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
                dataGridView2.Rows.Add(matafuegoElegido.DeterminarTipo(), matafuegoElegido.Peso, " - ", matafuegoElegido.PrecioVenta);

                matafuegosParaVenta.Add(matafuegoElegido);
                // Limpia la selección
                matafuegoElegido = null;
            }
            else
            {
                MessageBox.Show("Seleccione una fila antes de hacer clic en el botón.");
            }
        }

        private void dgvSeleccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que se selecciona una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dgvSeleccion.Rows.Count)
            {
                // Guarda el producto de la fila seleccionada
                matafuegoElegido = Empresa_.MatafuegosList[e.RowIndex];
            }
            else
            {
                MessageBox.Show("Elija una columna valida");
            }
        }
        //Hacer flecha para volver al menu anterior
        //vender
        private void button2_Click(object sender, EventArgs e)
        {
            double CostoTotalVenta = Empresa_.VenderMatafuego(matafuegosParaVenta, Cliente_);
            Factura factura = new Factura(CostoTotalVenta, Cliente_);
        }
    }
}
