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
        private RecepcionistaForm recepcionistaForm;
        private double CostoVenta;
        private Empresa Empresa_;

        //recarga
        public Factura(Empresa empresa, List<Matafuego> matafuegos, RecepcionistaForm recepcionistaForm)
        {
            InitializeComponent();

            Rellenar(empresa, 0, matafuegos);
            this.recepcionistaForm = recepcionistaForm;
        }

        //venta
        public Factura(Empresa empresa, double costoVenta, List<Matafuego> matafuegos, RecepcionistaForm recepcionistaForm)
        {
            InitializeComponent();
            Rellenar(empresa, costoVenta, matafuegos);
            this.recepcionistaForm= recepcionistaForm;

            lblTotal.Text = CostoVenta.ToString();
                lblApelli.Text = " ";
                lblNom.Text = " ";
                lblApellidoTecnico.Text = " ";
                lblNombreTecnico.Text = " ";
                lblRecargadoPor.Text = " ";
        }

        private void Rellenar(Empresa empresa, double costoVenta, List<Matafuego> matafuegos)
        {
            Empresa_ = empresa;
            CostoVenta = costoVenta;
            Cliente cliente_ = Empresa_.Clientes.Last();
            dataGridView1.Rows.Clear();
            foreach (var matafuego in cliente_.Matafuegos)
            {
                dataGridView1.Rows.Add(matafuego.DeterminarTipo(), matafuego.Peso, matafuego.PrecioVenta, matafuego.Arosello_Precinto, matafuego.EtiquetaMatafuego.FechaRevision, matafuego.EtiquetaMatafuego.FechaVencimiento);
            }

            //le cargo los matafuegos viejos
            foreach (var item in matafuegos)
            {
                cliente_.Matafuegos.Add(item);
            }


            lblNombre.Text = cliente_.Nombre;
            lblApellido.Text = cliente_.Apellido;
            lblDni.Text = cliente_.DNI;
            lblFecha.Text = DateTime.Now.ToString();

            if(costoVenta == 0)
            {
                Servicio servicio = empresa.ServiciosRealizados.Last();
                lblApellidoTecnico.Text = servicio.Tecnico_.Nombre;
                lblNombreTecnico.Text = servicio.Tecnico_.Apellido;
            }
       
        }

        private void Factura_FormClosing(object sender, FormClosingEventArgs e)
        {
            recepcionistaForm.Show();
            this.Hide();
        }
    }
}
