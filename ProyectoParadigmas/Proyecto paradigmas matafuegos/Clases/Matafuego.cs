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
        public Etiqueta EtiquetaMatafuego { get; set; } = new Etiqueta();
        public string Arosello_Precinto { get; set; }
        public bool Gas { get; set; }
        public double Peso { get; set; }
        public string Marca { get; set; }

        //constructor
        public Matafuego(string arosello_precinto, bool gas, double peso, double precio, string marca)
        {
            Arosello_Precinto = arosello_precinto;
            Gas = gas;
            Peso = peso;
            PrecioVenta = precio;
            DeterminarPrecioRecarga();
            Marca = marca;
        }


        //metodos
        public virtual void Recargar(string color)
        {
            Gas = true;
            Arosello_Precinto = color;
        }

        public abstract void DeterminarPrecioRecarga();

        public abstract string DeterminarTipo();
    }

}
