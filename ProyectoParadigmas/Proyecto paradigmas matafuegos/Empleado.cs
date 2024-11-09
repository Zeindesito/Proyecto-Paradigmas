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
        public string ObraSocial { get; set; }
        public string Codigo { get; set; }

        //constructor
        public Empleado(string nombre, string apellido, string email, string numeroTelefono, string cuil, string obraSocial, string codigo) : base(nombre, apellido, email, numeroTelefono, cuil)
        {
            ObraSocial = obraSocial;
            Codigo = codigo;
        }


   
        

        


    }
}
