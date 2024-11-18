using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_paradigmas_matafuegos.Forms
{
    public partial class ServicioForm : Form
    {
        RecepcionistaForm recepcionistaForm;
        private Empresa empresa_;
        public ServicioForm(RecepcionistaForm recepcionistaForm, Empresa empresa)
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServicioForm_FormClosing);
            this.recepcionistaForm = recepcionistaForm;
            empresa_ = empresa;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recepcionistaForm.Show();
            this.Hide();
        }

        private void ServicioForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de matafuego y su peso.");
                return;
            }
            else
            {
                Random random = new Random();

                // Obtener un índice aleatorio
                int indiceAleatorio = random.Next(empresa_.TecnicoList.Count);

                // Seleccionar el elemento aleatorio
                Tecnico tenico = empresa_.TecnicoList[indiceAleatorio];


                Servicio servicio = new Servicio(tenico, empresa_.Clientes.Last(), DateTime.Now);
            }
        }

        private void ServicioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
