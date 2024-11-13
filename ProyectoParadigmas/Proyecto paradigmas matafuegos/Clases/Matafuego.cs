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
        public double PrecioVenta { get; set; }
        public double PrecioRecarga { get; set; }
        public Etiqueta EtiquetaMatafuego { get; set; }
        public string Arosello_Precinto { get; set; }
        public bool Gas { get; set; }
        public double Peso { get; set; }


        //constructor PREGUNTA SI ES LEGAL PONER EL CONSTRUCTOR POR MAS QUE LA CLASE NO SE INSTANCIE!!!!!!!
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

        public abstract void DeterminarPrecioVenta();

        public abstract void DeterminarPrecioRecarga();














       /* public virtual void DeterminarPrecioVenta()
        {
            switch (Peso)
            {
                case 1:
                    Precio = 200;
                    break;
                case 2:
                    Precio = 500;
                    break;
                case 5:
                    Precio = 1000;
                    break;
                case 10:
                    Precio = 2500;
                    break;
            }
        } */

        //public abstract string DeterminarTipo();
    }

}
