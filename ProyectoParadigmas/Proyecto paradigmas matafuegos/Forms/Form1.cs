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

namespace Proyecto_paradigmas_matafuegos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contra = textBox2.Text;

            if (Usuario.ValidarUsuario(usuario, contra))
            {
                RecepcionistaForm recepcionistaForm = new RecepcionistaForm(this);
                recepcionistaForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
            textBox1.Clear();
            textBox2.Clear();

        }
    }
}
