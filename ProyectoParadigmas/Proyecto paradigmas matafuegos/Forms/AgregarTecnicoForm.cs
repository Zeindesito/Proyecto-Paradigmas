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
    public partial class AgregarTecnicoForm : Form
    {
        Sistema sistema;

        RecepcionistaForm recepcionistaForm;
        public List<Tecnico> TecnicoList { get; set; }
        public Empresa Empresa_ {  get; set; }
        public AgregarTecnicoForm(RecepcionistaForm recepcionistaForm, Empresa empresa)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textNombre.Text) || string.IsNullOrEmpty(textApellido.Text) || string.IsNullOrEmpty(textDni.Text))
            {
               
                MessageBox.Show("Por favor, Complete todos los campos.");
                return;
            }
            else
            {
                CrearTecnico();
                var p

                MessageBox.Show("Tecnico creado correctamente.");
            }
        }

        private void CrearTecnico()
        {
            Empresa_.AñadirTecnico(new Tecnico(textNombre.Text, textApellido.Text, textDni.Text));
            textNombre.Clear();
            textApellido.Clear();
            textDni.Clear();
        }
    }
}
