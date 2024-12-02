using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_paradigmas_matafuegos
{
    public partial class VentaForm : Form
    {
        RecepcionistaForm recepcionistaForm;
        private Empresa Empresa_;
        private List<Matafuego> MatafuegosSeleccion;
        private List<Matafuego> MatafuegosFiltrados;
        private List<Matafuego> ListaMatafuego;
        private List<Matafuego> matafuegosParaVenta = new List<Matafuego>();
        private Cliente Cliente_;
        private int selectedRowIndex = -1;
        private int selectedRowIndex_ = -1;
        private Matafuego matafuegoElegido;

        public VentaForm(Empresa empresa, RecepcionistaForm recepcionistaForm)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.VentaForm_FormClosing);

            this.recepcionistaForm = recepcionistaForm;
            this.Empresa_ = empresa;

            MatafuegosSeleccion = Empresa_.MatafuegosList;
            MatafuegosFiltrados = new List<Matafuego>(MatafuegosSeleccion);

            ActuaizarDatagridview();

            dgvSeleccion.CellClick += dgvSeleccion_CellClick;
            dataGridView2.CellClick += dataGridView2_CellClick;
            button1.Click += button1_Click_1;

            Cliente_ = Empresa_.Clientes.Last();
            ListaMatafuego = Cliente_.Matafuegos;
            Cliente_.Matafuegos = new List<Matafuego>();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (matafuegoElegido != null)
            {
                dataGridView2.Rows.Add(matafuegoElegido.Marca, matafuegoElegido.DeterminarTipo(), matafuegoElegido.Peso, matafuegoElegido.PrecioVenta);

                MatafuegosSeleccion.Remove(matafuegoElegido);
                MatafuegosFiltrados.Remove(matafuegoElegido);
                matafuegosParaVenta.Add(matafuegoElegido);

                ActuaizarDatagridview();

                matafuegoElegido = null;
                lblTotal.Text = $"{CalcularTotalCarrito()}";
                comboBox2.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Seleccione un matafuego.");
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            double CostoTotalVenta = Empresa_.VenderMatafuego(matafuegosParaVenta, Cliente_);
            Factura factura = new Factura(Empresa_, CostoTotalVenta, ListaMatafuego, recepcionistaForm);

            factura.Show();
            this.Hide();
            ActuaizarDatagridview();
        }

        private void dgvSeleccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < MatafuegosFiltrados.Count)
            {
                selectedRowIndex = e.RowIndex;
                matafuegoElegido = MatafuegosFiltrados[selectedRowIndex];
            }
            else
            {
                MessageBox.Show("Elija una fila válida.");
            }
        }

        private double CalcularTotalCarrito()
        {
            return matafuegosParaVenta.Sum(matafuego => matafuego.PrecioVenta);
        }

        //atras
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (ListaMatafuego == null || !ListaMatafuego.Any())
            {
                Empresa_.Clientes.Remove(Cliente_);
            }


            Cliente_.Matafuegos = ListaMatafuego;
            recepcionistaForm.Show();
            recepcionistaForm.Empresa_ = Empresa_;
            recepcionistaForm.MostrarClientes();
            this.Hide();
        }

        private void VentaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ActuaizarDatagridview()
        {
            dgvSeleccion.Rows.Clear();
            dataGridView2.Rows.Clear();

            foreach (var matafuego in MatafuegosFiltrados)
            {
                dgvSeleccion.Rows.Add(matafuego.Marca, matafuego.DeterminarTipo(), matafuego.Peso, matafuego.PrecioVenta);
            }

            foreach (var item in matafuegosParaVenta)
            {
                dataGridView2.Rows.Add(item.Marca, item.DeterminarTipo(), item.Peso, item.PrecioVenta);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                string filtro = comboBox2.SelectedItem.ToString();

                MatafuegosFiltrados = filtro == "TODOS"
                    ? new List<Matafuego>(MatafuegosSeleccion)
                    : MatafuegosSeleccion.Where(m => m.DeterminarTipo() == filtro).ToList();

                ActuaizarDatagridview();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < matafuegosParaVenta.Count)
            {
                selectedRowIndex_ = e.RowIndex;
                matafuegoElegido = matafuegosParaVenta[selectedRowIndex_];
            }
            else
            {
                MessageBox.Show("Elija una fila válida.");
            }
        }

        //Sacar del carrito
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (selectedRowIndex_ >= 0 && selectedRowIndex_ < matafuegosParaVenta.Count)
            {
                matafuegosParaVenta.RemoveAt(selectedRowIndex_);

                MatafuegosSeleccion.Add(matafuegoElegido);
                MatafuegosFiltrados.Add(matafuegoElegido);
                matafuegosParaVenta.Remove(matafuegoElegido);

                ActuaizarDatagridview();
                lblTotal.Text = $"{CalcularTotalCarrito()}";
                MessageBox.Show("Matafuego eliminado con éxito.");
            }
            else
            {
                MessageBox.Show("Seleccione un matafuego para eliminar.");
            }
        }
    }
}
