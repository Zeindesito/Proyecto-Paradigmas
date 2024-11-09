using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Matafuego_ABC : Matafuego
    {
        public bool Manometro { get; set; } //True = bien, False = roto
        public int KgPolvo {  get; set; }

        //constructor
        public Matafuego_ABC(int kilos, Etiqueta etiqueta, string arosello_precinto, double gas, bool manometro) : base(etiqueta, arosello_precinto, gas)
        {
            KgPolvo = kilos;
            Manometro = manometro;
        }


        //metodos
        public override void Recargar(double cantidadGas, string color, Etiqueta etiqueta, int cantidad) //?????
        {
            base.Recargar(cantidadGas, color, etiqueta, cantidad);

            //añado polvo quimico
            KgPolvo = cantidad;

            //si esta roto lo cambiamos
            if(Manometro == false)
            {
                Manometro = true;
            }
        }




    }
}
