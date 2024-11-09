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

        public Matafuego_K(Etiqueta etiqueta, string arosello_precinto, bool gas, bool liquido, string manometro) : base(etiqueta, arosello_precinto, gas)
        {
            Liquido = liquido;
            Manometro = manometro;
        }

        public override void Recargar(string color, Etiqueta etiqueta)
        {
            base.Recargar(color, etiqueta);
            Manometro = "Verde";
            Liquido = true;
        }

    }
}
