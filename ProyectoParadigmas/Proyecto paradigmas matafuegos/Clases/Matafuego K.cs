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
        public Matafuego_K(string arosello_precinto, bool gas, bool liquido, string manometro, double peso, double precio, string marca) : base(arosello_precinto, gas, peso, precio, marca)
        {
            Liquido = liquido;
            Manometro = manometro;
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
                    PrecioRecarga = 16000;
                    break;
                case 2.5:
                    PrecioRecarga = 22000;
                    break;
                case 5:
                    PrecioRecarga = 30000;
                    break;
                case 10:
                    PrecioRecarga = 57000;
                    break;
            }
        }

        public override string DeterminarTipo()
        {
            return "K";
        }

    }
}
