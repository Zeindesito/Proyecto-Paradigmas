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
        public double PrecioVenta { get; set; } = 0;
        public double PrecioRecarga { get; set; }
        public Etiqueta EtiquetaMatafuego { get; set; } = new Etiqueta();
        public string Arosello_Precinto { get; set; }
        public bool Gas { get; set; }
        public double Peso { get; set; }


        //constructor PREGUNTA SI ES LEGAL PONER EL CONSTRUCTOR POR MAS QUE LA CLASE NO SE INSTANCIE!!!!!!!
        public Matafuego(string arosello_precinto, bool gas, double peso, double precio)
        {
            Arosello_Precinto = arosello_precinto;
            Gas = gas;
            Peso = peso;
            PrecioVenta = precio;
            DeterminarPrecioRecarga();
        }


        //metodos
        public virtual void Recargar(string color)
        {
            Gas = true;
            Arosello_Precinto = color;
        }

        public abstract void DeterminarPrecioRecarga();

        public abstract string DeterminarTipo();














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
