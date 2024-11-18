using Proyecto_paradigmas_matafuegos.Forms;
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

        private Empresa Empresa_;
        public Factura(Empresa empresa)
        {
            InitializeComponent();
            Empresa_ = empresa;
            Cliente cliente_ = Empresa_.Clientes.Last();
                foreach (var matafuego in cliente_.Matafuegos)
                {
                    dataGridView1.Rows.Add(matafuego.DeterminarTipo(), matafuego.Peso, matafuego.PrecioVenta);
                }

            lblNombre.Text = cliente_.Nombre;
            lblApellido.Text = cliente_.Apellido;
            lblDni.Text = cliente_.DNI;
            lblFecha.Text = DateTime.Now.ToString();
            Servicio servicio = empresa.ServiciosRealizados.Last();
            lblApellidoTecnico.Text = servicio.Tecnico_.Nombre;
            lblNombreTecnico.Text = servicio.Tecnico_.Apellido;

        }


    }
}
