using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Etiqueta
    {
        public DateTime FechaRevision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string TipoDeMatafuego { get; set; }

        public Etiqueta() { }
        public Etiqueta(DateTime fechaRevision, DateTime fechaVencimiento, string tipoDeMatafuego)
        {
            FechaRevision = fechaRevision;
            FechaVencimiento = fechaVencimiento;
            TipoDeMatafuego = tipoDeMatafuego;
        }

        public void Rellenar(DateTime fechaRevision, DateTime fechaVencimiento, string tipoDeMatafuego)
        {
            FechaRevision = fechaRevision;
            FechaVencimiento = fechaVencimiento;
            TipoDeMatafuego = tipoDeMatafuego;
        }

        public void Imprimir()
        {
            ToString();
        }
    }
}
