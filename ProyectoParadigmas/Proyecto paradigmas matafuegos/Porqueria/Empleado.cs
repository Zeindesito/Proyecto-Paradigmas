using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public abstract class Empleado : Persona
    {
        public string CodigoEmpleado { get; set; }
        //constructor
        public Empleado(string nombre, string apellido,string dni, string codigoEmpleado) : base(nombre, apellido, dni)
        {
            CodigoEmpleado = codigoEmpleado;
        }


   
        

        


    }
}
