using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string NumeroTelefono { get; set; }
        public string DNI { get; set; } //?
        //string Apellido { get; set; }

        public Persona(string nombre, string apellido, string email, string numeroTelefono, string dni)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            NumeroTelefono = numeroTelefono;
            DNI = dni;
        }


    }
}
