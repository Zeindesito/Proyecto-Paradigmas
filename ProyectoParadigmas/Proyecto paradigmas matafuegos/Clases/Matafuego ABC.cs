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
        public Matafuego_ABC(bool kilos, string arosello_precinto, bool gas, double peso,string manometro, double precio, string marca) : base(arosello_precinto,gas, peso, precio, marca)
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
                    PrecioRecarga = 4200;
                    break;
                case 2.5:
                    PrecioRecarga = 4900;
                    break;
                case 5:
                    PrecioRecarga = 5600;
                    break;
                case 10:
                    PrecioRecarga = 7700;
                    break;
            }
        }

        public override string DeterminarTipo()
        {
            return "ABC";
        }


    }

}
