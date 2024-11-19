using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    [Serializable]
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }

        public Persona(string nombre, string apellido, string dni)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
        }


    }
}
