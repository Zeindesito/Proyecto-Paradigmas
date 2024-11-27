using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Matafuego_K : Matafuego
    {
        public bool Liquido {  get; set; }
        public string Manometro { get; set; }
        public Matafuego_K(string arosello_precinto, bool gas, bool liquido, string manometro, double peso, double precio) : base(arosello_precinto, gas, peso, precio)
        {
            Liquido = liquido;
            Manometro = manometro;
            DeterminarPrecioRecarga();
        }

        public override void Recargar(string color)
        {
            base.Recargar(color);
            Manometro = "Verde";
            Liquido = true;
        }

        public override void DeterminarPrecioRecarga()
        {
            switch (Peso)
            {
                case 1:
                    PrecioRecarga += 5000;
                    break;
                case 2.5:
                    PrecioRecarga += 8000;
                    break;
                case 5:
                    PrecioRecarga += 15000;
                    break;
                case 10:
                    PrecioRecarga += 28000;
                    break;
            }
        }

        public override string DeterminarTipo()
        {
            return "K";
        }

    }
}
