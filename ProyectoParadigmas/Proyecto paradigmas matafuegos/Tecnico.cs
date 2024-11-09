using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Tecnico : Empleado
    {
        //constructor parametrizado
        public Tecnico(string nombre, string apellido, string email, string numeroTelefono, string cuil, string obraSocial, string codigo) : base(nombre, apellido, email, numeroTelefono, cuil, obraSocial, codigo)
        {
        }

        //metodos
        public string RecargarMatafuego(Matafuego matafuego)
        {
            matafuego.Recargar()
        }

    }
}
