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

        public Matafuego_K(Etiqueta etiqueta, string arosello_precinto, bool gas, bool liquido, string manometro, int peso) : base(etiqueta, arosello_precinto, gas, peso)
        {
            Liquido = liquido;
            Manometro = manometro;
            DeterminarPrecioVenta();
        }

        public override void Recargar(string color, Etiqueta etiqueta)
        {
            base.Recargar(color, etiqueta);
            Manometro = "Verde";
            Liquido = true;
        }

        public override void DeterminarPrecioVenta()
        {
            switch (Peso)
            {
                case 1:
                    PrecioVenta += 00;
                    break;
                case 2.5:
                    PrecioVenta += 00;
                    break;
                case 5:
                    PrecioVenta += 400000;
                    break;
                case 10:
                    PrecioVenta += 00;
                    break;
            }
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
