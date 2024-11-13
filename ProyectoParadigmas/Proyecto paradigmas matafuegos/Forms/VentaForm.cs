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
    public partial class VentaForm : Form
    {
        public VentaForm()
        {
            InitializeComponent();
        }
        private int selectedRowIndex = -1;

        //seleccionar
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0 && selectedRowIndex < dgvSeleccion.Rows.Count)
            {
                // Obtiene la fila seleccionada en el primer DataGridView
                DataGridViewRow selectedRow = dgvSeleccion.Rows[selectedRowIndex];

                // Crea una nueva fila en el segundo DataGridView
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView2);

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                }

                // Añade la nueva fila al segundo DataGridView
                dataGridView2.Rows.Add(newRow);
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida.");
            }
        }

        private void dgvSeleccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              // Guarda el índice de la fila seleccionada
              selectedRowIndex = e.RowIndex;
        }
    }
}
