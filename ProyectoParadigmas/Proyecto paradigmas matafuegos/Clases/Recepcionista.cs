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
        public Recepcionista(string nombre, string apellido,string dni,string codigoEmpleado) : base(nombre, apellido,dni,codigoEmpleado)
        {
        }
        
        /*public void SolicitarServicio(Matafuego matafuego, Cliente cliente)
        {
            Servicio servicio = new Servicio(Tecnico tecnico)
        }*/
    }
}
