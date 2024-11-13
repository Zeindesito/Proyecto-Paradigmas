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
        public List<Servicio> Servicios {  get; set; }
        public Recepcionista(string nombre, string apellido,string dni,string codigoEmpleado) : base(nombre, apellido,dni,codigoEmpleado)
        {
            Servicios = new List<Servicio>();
        }
        
        public void SolicitarServicio(Cliente cliente, Tecnico tecnico, DateTime fecha)
        {
            Servicio servicio = new Servicio(tecnico, cliente, fecha);
            Servicios.Add(servicio);
            
        }

        public void VenderMatafuego(Matafuego matafuego, Cliente cliente)
        {
            cliente.Matafuegos.Add(matafuego);
        }

    }
}
