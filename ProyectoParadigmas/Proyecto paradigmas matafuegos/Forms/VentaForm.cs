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
        private Empresa Empresa_;
        private List<Matafuego> MatafuegosSeleccion;
        private List<Matafuego> ListaMatafuego;
        private List<Matafuego> matafuegosParaVenta = new List<Matafuego>();
        private Cliente Cliente_;
        private int selectedRowIndex = -1;
        private Matafuego matafuegoElegido;

        public VentaForm(Empresa empresa,RecepcionistaForm recepcionistaForm)
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VentaForm_FormClosing);
            this.recepcionistaForm = recepcionistaForm;
            this.Empresa_ = empresa;
            MatafuegosSeleccion = Empresa_.MatafuegosList;

            ActuaizarDatagridview();

            dgvSeleccion.CellClick += dgvSeleccion_CellClick;
            button1.Click += button1_Click;

            Cliente_ = Empresa_.Clientes[Empresa_.Clientes.Count - 1];

            Cliente_ = Empresa_.Clientes.Last();
            ListaMatafuego = Cliente_.Matafuegos;
            Cliente_.Matafuegos = new List<Matafuego>();
        }


        //seleccionar
        private void button1_Click(object sender, EventArgs e)
        {
            if (matafuegoElegido != null)
            {
                // Agrega el producto seleccionado al segundo DataGridView
                dataGridView2.Rows.Add(matafuegoElegido.DeterminarTipo(), matafuegoElegido.Peso, matafuegoElegido.PrecioVenta);

                //borro el producto de la lista auxiliar para no borrar de la original
                MatafuegosSeleccion.Remove(matafuegoElegido);

                //añado a la lista para vender
                matafuegosParaVenta.Add(matafuegoElegido);

                ActuaizarDatagridview();

                // Limpia la selección
                matafuegoElegido = null;
                
                lblTotal.Text = $"{CalcularTotalCarrito()}";
            }
          
        }

        //vender
        private void button2_Click(object sender, EventArgs e)
        {

            double CostoTotalVenta = Empresa_.VenderMatafuego(matafuegosParaVenta, Cliente_);
            foreach (var matafuego in matafuegosParaVenta)
            {
                Empresa_.MatafuegosList.Remove(matafuego);
            }

            Factura factura = new Factura(Empresa_, CostoTotalVenta, ListaMatafuego);
            factura.Show();
            this.MinimizeBox = true;
            ActuaizarDatagridview();
        }


        private void dgvSeleccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que se selecciona una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dgvSeleccion.Rows.Count - 1)
            {
                selectedRowIndex = e.RowIndex;
                // Guarda el producto de la fila seleccionada
                matafuegoElegido = Empresa_.MatafuegosList[e.RowIndex];

            }
            else
            {
                MessageBox.Show("Elija una fila valida");
            }
        }




        private double CalcularTotalCarrito()
        {
            return matafuegosParaVenta.Sum(matafuego => matafuego.PrecioVenta);
        }
        
        //flecha volver al menu anterior
        private void button3_Click(object sender, EventArgs e)
        {
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

            //actualizado el datagridview donde estan cargados
            foreach (var matafuego in MatafuegosSeleccion)
            {
                dgvSeleccion.Rows.Add(matafuego.DeterminarTipo(), matafuego.Peso, matafuego.PrecioVenta);
            }

            //actualizo el carrito
            foreach (var item in matafuegosParaVenta)
            {
                dataGridView2.Rows.Add(item.DeterminarTipo(), item.Peso, item.PrecioRecarga);
            }

        }
    }
}
