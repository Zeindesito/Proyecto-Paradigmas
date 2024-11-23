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
        public Matafuego_ABC(bool kilos, string arosello_precinto, bool gas, double peso,string manometro) : base(arosello_precinto,gas, peso)
        {
            KgPolvo = kilos;
            Manometro = manometro;
            DeterminarPrecioVenta();
            DeterminarPrecioRecarga();
        }

        //metodos
        public override void Recargar(string color)
        {
            base.Recargar(color);
            Manometro = "Verde";
            KgPolvo = true;
        }

        public override void DeterminarPrecioVenta()
        {
            switch (Peso)
            {
                case 1:
                    PrecioVenta += 35000;
                    break;
                case 2.5:
                    PrecioVenta += 45000;
                    break;
                case 5:
                    PrecioVenta += 120000;
                    break;
                case 10:
                    PrecioVenta += 220000;
                    break;
            }
        }

        public override void DeterminarPrecioRecarga()
        {
            switch (Peso)
            {
                case 1:
                    PrecioVenta += 1400;
                    break;
                case 2.5:
                    PrecioVenta += 1600;
                    break;
                case 5:
                    PrecioVenta += 3000;
                    break;
                case 10:
                    PrecioVenta += 4800;
                    break;
            }
        }

        public override string DeterminarTipo()
        {
            return "ABC";
        }


    }

}
