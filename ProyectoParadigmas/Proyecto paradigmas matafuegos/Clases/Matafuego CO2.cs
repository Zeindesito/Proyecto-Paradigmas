using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos.Clases
{
    public class Matafuego_CO2 : Matafuego
    {
        public Matafuego_CO2(string arosello_precinto, bool gas, double peso, double precio) : base(arosello_precinto, gas, peso, precio)
        {
            DeterminarPrecioRecarga();
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
                    PrecioVenta += 1800;
                    break;
                case 2.5:
                    PrecioVenta += 2100;
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
