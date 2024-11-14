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
    public partial class ServicioForm : Form
    {
        RecepcionistaForm recepcionistaForm;
        public ServicioForm(RecepcionistaForm recepcionistaForm)
        {
            InitializeComponent();
            this.recepcionistaForm = recepcionistaForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de matafuego y su peso.");
                return;
            }

            //= comboBox1.Text

        }

        private void button2_Click(object sender, EventArgs e)
        {
            recepcionistaForm.Show();
            this.Close();
        }
    }
}
