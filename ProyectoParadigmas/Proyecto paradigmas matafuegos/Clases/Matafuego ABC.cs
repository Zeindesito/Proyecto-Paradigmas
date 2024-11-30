using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Matafuego_ABC : Matafuego
    {
        public string Manometro { get; set; } //Verde = bien, amarrillo = falta gas, rojo = exceso de gas
        public bool KgPolvo {  get; set; } //true = lleno, false = vacio

        //constructor
        public Matafuego_ABC(bool kilos, string arosello_precinto, bool gas, double peso,string manometro, double precio) : base(arosello_precinto,gas, peso, precio)
        {
            KgPolvo = kilos;
            Manometro = manometro;
        }

        //metodos
        public override void Recargar(string color)
        {
            base.Recargar(color);
            Manometro = "Verde";
            KgPolvo = true;
        }

        public override void DeterminarPrecioRecarga()
        {
            switch (Peso)
            {
                case 1:
                    PrecioRecarga = 5000;
                    break;
                case 2.5:
                    PrecioRecarga = 8000;
                    break;
                case 5:
                    PrecioRecarga = 15000;
                    break;
                case 10:
                    PrecioRecarga = 28000;
                    break;
            }
        }

        public override string DeterminarTipo()
        {
            return "ABC";
        }


    }

}
