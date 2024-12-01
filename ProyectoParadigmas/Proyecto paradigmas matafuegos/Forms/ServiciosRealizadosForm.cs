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
    public partial class ServiciosRealizadosForm : Form
    {
        public ServiciosRealizadosForm(Empresa empresa)
        {
            InitializeComponent();
            foreach (var item in empresa.ServiciosRealizados)
            {
                foreach (var matafuego in item.Cliente_.Matafuegos)
                {
                    dataGridView1.Rows.Add(item.Cliente_.Nombre, item.Cliente_.Apellido, item.Cliente_.DNI, item.Cliente_.Email, matafuego.DeterminarTipo(), matafuego.Peso, matafuego.Arosello_Precinto, matafuego.EtiquetaMatafuego.FechaRevision, matafuego.EtiquetaMatafuego.FechaVencimiento, item.Tecnico_.Nombre, item.Tecnico_.Apellido, item.Tecnico_.DNI);
                }
            }

        }
    }
}
