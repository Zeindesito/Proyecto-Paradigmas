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
    public partial class Factura : Form
    {
        private double CostoTotal;
        private Cliente Cliente_;
        public Factura(double CostoTotalVenta, Cliente cliente)
        {
            InitializeComponent();
            CostoTotal = CostoTotalVenta;
            Cliente_ = cliente;
            foreach (var matafuego in cliente.Matafuegos)
            {
                dataGridView1.Rows.Add(matafuego.DeterminarTipo(), matafuego.Peso, matafuego.PrecioVenta);
            }
        }


    }
}
