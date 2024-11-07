using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public abstract class Matafuego
    {
        public int Kilos {  get; set; }
        public Etiqueta EtiquetaMatafuego { get; set; }
        public string Arosello { get; set; }
        public double Gas { get; set; }

        public void RellenarGas(double cantidadGas)
        {
            Gas = cantidadGas;
        }


    }
}
