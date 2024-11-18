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
                new Matafuego_ABC(true, "Verde", true, 1, "Verde"),
                new Matafuego_ABC(true, "Verde", true, 1, "Verde"),
                new Matafuego_ABC(true, "Verde", true, 1, "Verde")
            }),
            new Cliente("Pedro", "Perez", "22.125.875", "elmaskapito@gmail.com", new List<Matafuego>
            {
                new Matafuego_K("Verde", true, true, "Verde", 10),
                new Matafuego_K("Verde", true, true, "Verde", 5),
            })
            };

            //relleno las etiquetas
            foreach (var item in listaClientes)
            {
                foreach (var matafuego in item.Matafuegos)
                {
                    matafuego.EtiquetaMatafuego.Rellenar(DateTime.Parse("20/11/2024"), DateTime.Parse("20/11/2025"), matafuego.DeterminarTipo());
                }
            }

            Tecnicos = new List<Tecnico>
            {
            new Tecnico("Matias", "Gonzalez", "45.557.102"),
            new Tecnico("Agustin", "Montejo", "44.512.122")

            };
            MatafuegosEmpresa = new List<Matafuego>
            {
                new Matafuego_K("Rojo", true, true, "Verde", 5),
                new Matafuego_K("Rojo", true, true, "Amarillo", 10),
                new Matafuego_ABC(true, "Rojo", true, 1, "Verde")

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
