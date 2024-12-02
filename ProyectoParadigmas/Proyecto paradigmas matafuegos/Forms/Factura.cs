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
            // Deshabilitar selección inicial
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            this.recepcionistaForm = recepcionistaForm;
            Empresa_ = empresa;
            Cliente cliente_ = Empresa_.Clientes.Last();

            //muestro en el datagridview
            Servicio servicio = empresa.ServiciosRealizados.Last();
            lblApellidoTecnico.Text = servicio.Tecnico_.Nombre;
            lblNombreTecnico.Text = servicio.Tecnico_.Apellido;
            lblTotal.Text = servicio.Costo.ToString();
            dataGridView1.Rows.Clear();

            foreach (var matafuego in cliente_.Matafuegos)
            {
                dataGridView1.Rows.Add(matafuego.Marca, matafuego.DeterminarTipo(), matafuego.Peso, matafuego.PrecioRecarga, matafuego.Arosello_Precinto, matafuego.EtiquetaMatafuego.FechaRevision, matafuego.EtiquetaMatafuego.FechaVencimiento);
            }

            //muestro la demas informacion
            lblNombre.Text = cliente_.Nombre;
            lblApellido.Text = cliente_.Apellido;
            lblDni.Text = cliente_.DNI;
            lblFecha.Text = DateTime.Now.ToString();

            //le cargo los matafuegos viejos
            foreach (var item in matafuegos)
            {
                cliente_.Matafuegos.Add(item);
            }
        }

        //venta
        public Factura(Empresa empresa, double costoVenta, List<Matafuego> matafuegos, RecepcionistaForm recepcionistaForm)
        {
            InitializeComponent();
            this.recepcionistaForm= recepcionistaForm;
            Empresa_ = empresa;
            CostoVenta = costoVenta;
            Cliente cliente_ = Empresa_.Clientes.Last();
            lblTotal.Text = CostoVenta.ToString();

            //todo lo de tecnico en vacio
                lblApelli.Text = " ";
                lblNom.Text = " ";
                lblApellidoTecnico.Text = " ";
                lblNombreTecnico.Text = " ";
                lblRecargadoPor.Text = " ";

            //muestro en el datagridview
            dataGridView1.Rows.Clear();
            foreach (var matafuego in cliente_.Matafuegos)
            {
                dataGridView1.Rows.Add(matafuego.Marca, matafuego.DeterminarTipo(), matafuego.Peso, matafuego.PrecioVenta, matafuego.Arosello_Precinto, matafuego.EtiquetaMatafuego.FechaRevision, matafuego.EtiquetaMatafuego.FechaVencimiento);
            }

            //muestro la demas informacion
            lblNombre.Text = cliente_.Nombre;
            lblApellido.Text = cliente_.Apellido;
            lblDni.Text = cliente_.DNI;
            lblFecha.Text = DateTime.Now.ToString();

            //le cargo los matafuegos viejos
            foreach (var item in matafuegos)
            {
                cliente_.Matafuegos.Add(item);
            }


        }

        private void Rellenar(Empresa empresa, double costoVenta, List<Matafuego> matafuegos)
        {
            Empresa_ = empresa;
            CostoVenta = costoVenta;

            Cliente cliente_ = Empresa_.Clientes.Last();


            

            lblNombre.Text = cliente_.Nombre;
            lblApellido.Text = cliente_.Apellido;
            lblDni.Text = cliente_.DNI;
            lblFecha.Text = DateTime.Now.ToString();

            if(costoVenta == 0)
            {
                
                dataGridView1.Rows.Clear();
                foreach (var matafuego in cliente_.Matafuegos)
                {
                    dataGridView1.Rows.Add(matafuego.DeterminarTipo(), matafuego.Peso, matafuego.PrecioRecarga, matafuego.Arosello_Precinto, matafuego.EtiquetaMatafuego.FechaRevision, matafuego.EtiquetaMatafuego.FechaVencimiento);
                }
            }
       
        }

        //cierra
        private void Factura_FormClosing(object sender, FormClosingEventArgs e)
        {
            recepcionistaForm.MostrarClientes();
            recepcionistaForm.Show();
            this.Hide();
        }
    }
}
