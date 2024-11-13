using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public abstract class Matafuego
    {
        public Etiqueta EtiquetaMatafuego { get; set; }
        public string Arosello_Precinto { get; set; }
        public bool Gas { get; set; }
        public double Peso {  get; set; }


        //constructor
        public Matafuego(Etiqueta etiqueta, string arosello_precinto, bool gas, double peso)
        {
            EtiquetaMatafuego = etiqueta;
            Arosello_Precinto = arosello_precinto;
            Gas = gas;
            Peso = peso;
        }

        //metodos
        public virtual void Recargar(string color, Etiqueta etiqueta)
        {
            Gas = true;
            Arosello_Precinto = color;
            EtiquetaMatafuego = etiqueta;
        }

        public abstract double CalcularCosto();

       
       

    }
}
