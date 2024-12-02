using Proyecto_paradigmas_matafuegos.Clases;
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
                new Matafuego_ABC(true, "Verde", true, 1, "Verde", 35000, "Georgia"),
                new Matafuego_ABC(true, "Rojo", true, 2.5, "Amarillo", 65000, "Amerex"),

            }),
            new Cliente("Pedro", "Perez", "22.125.875", "perezpedro@gmail.com", new List<Matafuego>
            {
                new Matafuego_K("Verde", true, true, "Verde", 2.5, 250000, "Yukon"),
                new Matafuego_ABC(true, "Rojo", true, 10, "Amarillo", 190000, "Melisam"),
            }),
             new Cliente("Nazareno", "Rolon", "44.789.897", "nazarolon@gmail.com", new List<Matafuego>
            {
                new Matafuego_CO2("Verde", true, 5, 450000, "Yukon"),
            }),
            new Cliente("Matias", "Inglant", "43.678.234", "inglantmati@gmail.com", new List<Matafuego>
            {
                new Matafuego_K("Verde", true, true, "Verde", 10, 600000, "Melisam"),
            }),
             new Cliente("Luis", "Fonsi", "47.234.101", "luisfonsi21@gmail.com", new List<Matafuego>
            {
                new Matafuego_ABC(true, "Verde", true, 5, "Verde",130000, "Yukon"),
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
                 new Matafuego_K("Rojo", true, true, "Amarillo", 1, 150000, "Yukon"),
                 new Matafuego_CO2("Rojo",true,1,180000, "Yukon"),
                 new Matafuego_ABC(true, "Rojo", true, 1, "Verde", 35000, "Melisam"),
                 //2.5kg
                 new Matafuego_K("Rojo", true, true, "Amarillo", 2.5, 250000, "Georgia"),
                 new Matafuego_CO2("Rojo",true,2.5,250000, "Yukon"),
                 new Matafuego_ABC(true, "Rojo", true, 2.5, "Amarillo", 65000, "Amerex"),
                 //5kg
                 new Matafuego_K("Rojo", true, true, "Verde", 5, 420000, "Yukon"),
                 new Matafuego_CO2("Rojo",true,5,450000, "Georgia"),
                 new Matafuego_ABC(true, "Rojo", true, 5, "Amarillo", 130000, "Melisam"),
                 //10kg
                 new Matafuego_K("Rojo", true, true, "Amarillo", 10, 680000, "Yukon"),
                 new Matafuego_CO2("Rojo",true,10,600000, "Georgia"),
                 new Matafuego_ABC(true, "Rojo", true, 10, "Amarillo", 190000, "Melisam"),

            };
            foreach (var matafuego in MatafuegosEmpresa)
            {
                matafuego.EtiquetaMatafuego.Rellenar(DateTime.Parse("20/11/2024"), DateTime.Parse("20/11/2025"), matafuego.DeterminarTipo());
            }

            Servicio viejoServicio = new Servicio(Tecnicos.Last(), listaClientes.Last(), DateTime.Parse("06/02/2024"));
            viejoServicio.RealizarRecarga(listaClientes.Last(), Tecnicos.Last(), DateTime.Parse("06/02/2024"), "Verde", new List<Matafuego>{ new Matafuego_ABC(true, "Verde", true, 5, "Verde", 130000, "Yukon") });
            List<Servicio> servicios = new List<Servicio>();
            servicios.Add(viejoServicio);
            empresa = new Empresa(Tecnicos, listaClientes, MatafuegosEmpresa, servicios);
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
