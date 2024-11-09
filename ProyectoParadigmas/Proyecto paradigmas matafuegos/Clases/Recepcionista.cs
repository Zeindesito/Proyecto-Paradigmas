using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Recepcionista : Empleado
    {
        public Recepcionista(string nombre, string apellido, string email, string numeroTelefono, string codigo) : base(nombre, apellido, email, numeroTelefono, codigo)
        {
        }

        // Preguntar si el servicio es urgente o no, si es asi cobrar un plus por prisa a realizar

       /* public void RealizarServicio(Servicio servicio)
        {

        }

        public void VenderMataFuego(Matafuego matafuego,Persona persona)
        {

        }*/
    }
}
