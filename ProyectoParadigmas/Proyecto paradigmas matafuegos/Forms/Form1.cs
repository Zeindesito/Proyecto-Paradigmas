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

        public Empresa empresa;
        public Form1()
        {
            InitializeComponent();
            List<Cliente> listaClientes;
            List<Tecnico> Tecnicos;
            List<Matafuego> MatafuegosEmpresa;


        listaClientes = new List<Cliente>
            {
            new Cliente("Juan", "Frias", "40.211.195", "aepappasp@gmail.com", new List<Matafuego>
            {
                new Matafuego_ABC(true, new Etiqueta(DateTime.Parse("17/11/2023"), DateTime.Parse("17/11/2024"), "ABC"), "Rojo", true, 1, "Verde"),
                new Matafuego_ABC(true, new Etiqueta(DateTime.Parse("20/10/2024"), DateTime.Parse("20/10/2025"), "ABC"), "Azul", true, 1, "Verde"),
                new Matafuego_ABC(true, new Etiqueta(DateTime.Parse("18/10/2024"), DateTime.Parse("18/10/2025"), "ABC"), "Rojo", true, 1, "Verde")
            }),
            new Cliente("Pedro", "Perez", "22.125.875", "elmaskapito@gmail.com", new List<Matafuego>
            {
                new Matafuego_K(new Etiqueta(DateTime.Parse("01/12/2023"), DateTime.Parse("07/12/2024"), "ABC"), "Azul", true, true, "Verde", 10),
                new Matafuego_K(new Etiqueta(DateTime.Parse("08/12/2023"), DateTime.Parse("08/12/2024"), "ABC"), "Rojo", true, true, "Verde", 5),
            })
            };

            Tecnicos = new List<Tecnico>
            {
            new Tecnico("Matias", "Gonzalez", "45.557.102"),
            new Tecnico("Agustin", "Montejo", "44.512.122")

            };
            MatafuegosEmpresa = new List<Matafuego>
            {
                new Matafuego_K(new Etiqueta(), "Rojo", true, true, "Verde", 5),
                new Matafuego_K(new Etiqueta(), "Rojo", true, true, "Amarillo", 10),
                new Matafuego_ABC(true, new Etiqueta(), "Rojo", true, 1, "Verde")

            };


            empresa = new Empresa(Tecnicos, listaClientes, MatafuegosEmpresa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contra = textBox2.Text;

            if (Usuario.ValidarUsuario(usuario, contra))
            {
                RecepcionistaForm recepcionistaForm = new RecepcionistaForm(this, empresa);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
