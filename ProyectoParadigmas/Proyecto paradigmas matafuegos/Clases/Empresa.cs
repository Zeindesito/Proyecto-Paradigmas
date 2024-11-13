using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Empresa
    {
        public List<Empleado> EmpleadoList { get; set; }
        public List<Tecnico> TecnicoList { get; set; }
        //public List<Recepcionista> RecepcionistaList { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Matafuego> MatafuegosList { get; set; }

        //constructor
        public Empresa(List<Empleado> empleados, List<Tecnico> tecnicos, List<Recepcionista> recepcionistas, List<Cliente> clientes)
        {
            EmpleadoList = empleados;
            TecnicoList = tecnicos;
           //RecepcionistaList = recepcionistas;
            Clientes = clientes;
        }

        //metodos
        public void AñadirCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public void AñadirTecnico(Tecnico tecnico)
        {
            TecnicoList.Add(tecnico);
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
