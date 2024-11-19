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
        public AgregarInventarioForm(RecepcionistaForm recepcionistaForm)
        {
            InitializeComponent();
            this.recepcionistaForm = recepcionistaForm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recepcionistaForm.Show();
            this.Hide();
        }
    }
}
