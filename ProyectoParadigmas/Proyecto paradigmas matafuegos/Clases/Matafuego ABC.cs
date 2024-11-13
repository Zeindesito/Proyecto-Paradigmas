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
        public Matafuego_ABC(bool kilos, Etiqueta etiqueta, string arosello_precinto, bool gas, double peso,string manometro) : base(etiqueta, arosello_precinto,gas, peso)
        {
            KgPolvo = kilos;
            Manometro = manometro;
        }

        //metodos
        public override void Recargar(string color, Etiqueta etiqueta)
        {
            base.Recargar(color, etiqueta);
            Manometro = "Verde";
            KgPolvo = true;
        }

        public override double CalcularCosto()
        {
            double costoBase = 4500;
            costoBase += 3000;
            costoBase += Peso * 500;
            return costoBase;
        }
    }
}
