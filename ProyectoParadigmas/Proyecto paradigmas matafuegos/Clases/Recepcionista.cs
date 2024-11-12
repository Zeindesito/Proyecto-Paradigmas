using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Recepcionista : Empleado
    {
        public Recepcionista(string nombre, string apellido, string email, string numeroTelefono, string codigo) : base(nombre, apellido, email, numeroTelefono, codigo)
        {
        }
        
        public void SolicitarServicio(Matafuego matafuego, Cliente cliente)
        {
            Servicio servicio = new Servicio(Tecnico tecnico)
        }
    }
}
