using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Cliente : Persona
    {
        public string Localidad { get; set; }
        public string Provincia { get; set; }

        public Cliente(string nombre, string apellido, string email, string numeroTelefono, string dni, string localidad, string provincia) : base(nombre, apellido, email, numeroTelefono, dni)
        {
            Localidad = localidad;
            Provincia = provincia;
        }



    }
}
