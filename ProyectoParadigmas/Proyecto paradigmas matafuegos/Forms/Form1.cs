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
            new Cliente("Juan", "Frias", "40.211.195", "juanfrias34@gmail.com", new List<Matafuego>
            {
                new Matafuego_ABC(true, "Verde", true, 1, "Verde",3500),
            }),
            new Cliente("Pedro", "Perez", "22.125.875", "perezpedro@gmail.com", new List<Matafuego>
            {
                new Matafuego_K("Verde", true, true, "Verde", 2.5, 4500),
            }),
             new Cliente("Nazareno", "Rolon", "44.789.897", "nazarolon@gmail.com", new List<Matafuego>
            {
                new Matafuego_CO2("Verde", true, 5, 6500),
            }),
            new Cliente("Matias", "Inglant", "43.678.234", "inglantmati@gmail.com", new List<Matafuego>
            {
                new Matafuego_K("Verde", true, true, "Verde", 10, 7500),
            }),
             new Cliente("Luis", "Fonsi", "47.234.101", "luisfonsi21@gmail.com", new List<Matafuego>
            {
                new Matafuego_ABC(true, "Verde", true, 5, "Verde",5500),
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
            new Tecnico("Agustin", "Montejo", "45.101.907")

            };
            MatafuegosEmpresa = new List<Matafuego>
            {
                 //1kg
                 new Matafuego_K("Rojo", true, true, "Amarillo", 1, 5000),
                 new Matafuego_CO2("Rojo",true,1,5000),
                 new Matafuego_ABC(true, "Rojo", true, 1, "Verde", 3000),
                 //2.5kg
                 new Matafuego_K("Rojo", true, true, "Amarillo", 2.5, 6000),
                 new Matafuego_CO2("Rojo",true,2.5,6500),
                 new Matafuego_ABC(true, "Rojo", true, 2.5, "Amarillo", 4000),
                 //5kg
                 new Matafuego_K("Rojo", true, true, "Verde", 5, 7500),
                 new Matafuego_CO2("Rojo",true,5,8000),
                 new Matafuego_ABC(true, "Rojo", true, 5, "Amarillo", 5500),
                 //10kg
                 new Matafuego_K("Rojo", true, true, "Amarillo", 10, 9000),
                 new Matafuego_CO2("Rojo",true,10,9000),
                 new Matafuego_ABC(true, "Rojo", true, 10, "Amarillo", 7000),

            };
            foreach (var matafuego in MatafuegosEmpresa)
            {
                matafuego.EtiquetaMatafuego.Rellenar(DateTime.Parse("20/11/2024"), DateTime.Parse("20/11/2025"), matafuego.DeterminarTipo());
            }

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
    }
}
