using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Cliente : Persona
    {
        public Matafuego matafuego;
        public Cliente(string nombre, string apellido, string email, string numeroTelefono, string dni) : base(nombre, apellido, email, numeroTelefono, dni)
        {
        }



    }
}
