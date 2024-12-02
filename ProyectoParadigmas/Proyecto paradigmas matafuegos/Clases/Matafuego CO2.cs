using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos.Clases
{
    public class Matafuego_CO2 : Matafuego
    {
        public Matafuego_CO2(string arosello_precinto, bool gas, double peso, double precio, string marca) : base(arosello_precinto, gas, peso, precio, marca)
        {
        }
        //metodos
        public override void Recargar(string color)
        {
            Gas = true;
            base.Recargar(color);
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
            return "CO2";
        }
    }
}
