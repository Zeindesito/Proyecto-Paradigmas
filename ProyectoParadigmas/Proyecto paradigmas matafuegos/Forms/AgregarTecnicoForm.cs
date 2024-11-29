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

        RecepcionistaForm recepcionistaForm;
        public List<Tecnico> TecnicoList { get; set; }
        public Empresa Empresa_ {  get; set; }
        private int selectedRowIndex = -1;
        private Tecnico TecnicoElegido;
        public AgregarTecnicoForm(RecepcionistaForm recepcionistaForm, Empresa empresa)
        {
            InitializeComponent();
            this.recepcionistaForm = recepcionistaForm;
            Empresa_ = empresa;
            MostrarTecnicos();
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
                if (!EsDniValido(textDni.Text))
                {
                    MessageBox.Show("Por favor, ingrese un DNI válido en el formato ##.###.###");
                    return;
                }
                CrearTecnico();
                MessageBox.Show("Tecnico creado correctamente.");
            }
        }

        private void CrearTecnico()
        {
            Empresa_.AñadirTecnico(new Tecnico(textNombre.Text, textApellido.Text, textDni.Text));
            textNombre.Clear();
            textApellido.Clear();
            textDni.Clear();
            MostrarTecnicos();
            
        }

        //seleccionar objetos del dataGridView
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que se selecciona una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                selectedRowIndex = e.RowIndex;
                // Guarda el producto de la fila seleccionada
                TecnicoElegido = Empresa_.TecnicoList[e.RowIndex];

            }
            else
            {
                MessageBox.Show("Elija una fila valida");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (TecnicoElegido != null)
            {
                Empresa_.TecnicoList.RemoveAt(selectedRowIndex);
                // Limpia la selección
                TecnicoElegido = null;
                // Agrega el producto seleccionado al DataGridView
                MostrarTecnicos();
                MessageBox.Show("Tecnico eliminado con éxito");
            }

            
        }

        private void MostrarTecnicos()
        {
            dataGridView1.Rows.Clear();
            foreach (var tecnico in Empresa_.TecnicoList)
            {
                dataGridView1.Rows.Add(tecnico.Nombre, tecnico.Apellido, tecnico.DNI);
            }
        }
        //validar dni
        private bool EsDniValido(string dni)
        {
            // Validar longitud
            if (dni.Length != 10)
                return false;

            // Validar formato (##.###.###)
            if (dni[2] != '.' || dni[6] != '.')
                return false;

            // Validar que los caracteres sean números o puntos
            foreach (char c in dni)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
