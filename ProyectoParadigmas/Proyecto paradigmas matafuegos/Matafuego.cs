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
        public double Gas { get; set; }

        //constructor
        public Matafuego(Etiqueta etiqueta, string arosello_precinto, double gas)
        {
            EtiquetaMatafuego = etiqueta;
            Arosello_Precinto = arosello_precinto;
            Gas = gas;
        }

        //metodos
        public virtual void Recargar(double cantidadGas, string color, Etiqueta etiqueta, int cantidad)
        {
            RellenarGas(cantidadGas);
            CambiarArosello(color);
            CambiarEtiqueta(etiqueta);
        }

        void RellenarGas(double cantidadGas)
        {
            Gas = cantidadGas;
        }

        void CambiarArosello(string color)
        {
            Arosello_Precinto = color;
        }

        void CambiarEtiqueta(Etiqueta etiqueta)
        {
            EtiquetaMatafuego = etiqueta;
        }

       
       

    }
}
