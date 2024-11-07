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
        public Matafuego Matafuego_ { get; set; }

        public Etiqueta() { }

        public void Rellenar(DateTime fechaRevision, DateTime fechaVencimiento, Matafuego matafuego)
        {
            FechaRevision = fechaRevision;
            FechaVencimiento = fechaVencimiento;
            Matafuego_ = matafuego;
        }
    }
}
