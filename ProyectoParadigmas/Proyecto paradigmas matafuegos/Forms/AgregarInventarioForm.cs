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
        public AgregarInventarioForm(RecepcionistaForm recepcionistaForm, Empresa empresa)
        {
            InitializeComponent();
            this.recepcionistaForm = recepcionistaForm;
            Empresa_ = empresa;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recepcionistaForm.Show();
            this.Hide();
        }

        private void AgregarInventarioForm_Load(object sender, EventArgs e)
        {

        }


        //cargar al inventario
        private void button1_Click(object sender, EventArgs e)
        {
            Matafuego matafuego = null;
            switch (cbxTipo.Text)
            {
                case "ABC":
                    matafuego = new Matafuego_ABC(true, txtColorArosello.Text, true, Convert.ToDouble(cbxPeso.Text), "Verde", Convert.ToDouble(txtPrecio.Text));
                    matafuego.EtiquetaMatafuego.Rellenar(dateTimePicker1.Value.Date, dateTimePicker1.Value.Date.AddYears(1), matafuego.DeterminarTipo());
                    Empresa_.AñadirMatafuego(matafuego);
                    
                    break;

                case "K":
                    matafuego = new Matafuego_K(txtColorArosello.Text, true, true, "Verde", Convert.ToDouble(cbxPeso.Text), Convert.ToDouble(txtPrecio.Text));
                    matafuego.EtiquetaMatafuego.Rellenar(dateTimePicker1.Value.Date, dateTimePicker1.Value.Date.AddYears(1), matafuego.DeterminarTipo());
                    Empresa_.AñadirMatafuego(matafuego);

                    break;

                case "CO2":
                    matafuego = new Matafuego_CO2(txtColorArosello.Text, true, Convert.ToDouble(cbxPeso.Text), Convert.ToDouble(txtPrecio));
                    matafuego.EtiquetaMatafuego.Rellenar(dateTimePicker1.Value.Date, dateTimePicker1.Value.Date.AddYears(1), matafuego.DeterminarTipo());
                    Empresa_.AñadirMatafuego(matafuego);
                    break;
            }
            
        }

    }
}
