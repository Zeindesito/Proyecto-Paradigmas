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
        public List<Recepcionista> RecepcionistaList { get; set; }
        public List<Cliente> Cliente { get; set; }

        //constructor
        public Empresa(List<Empleado> empleados, List<Tecnico> tecnicos, List<Recepcionista> recepcionistas, List<Cliente> clientes)
        {
            EmpleadoList = empleados;
            TecnicoList = tecnicos;
            RecepcionistaList = recepcionistas;
            Cliente = clientes;
        }

        //metodos
        public void AñadirCliente(Cliente cliente)
        {
            Cliente.Add(cliente);
        }
    }
}
