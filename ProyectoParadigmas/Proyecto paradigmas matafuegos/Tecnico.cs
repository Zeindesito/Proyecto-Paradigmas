using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Tecnico : Empleado
    {
        //constructor parametrizado
        public Tecnico(string nombre, string apellido, string email, string numeroTelefono, string codigo) : base(nombre, apellido, email, numeroTelefono, codigo)
        {

        }

        //metodos
        public string RecargarMatafuego(Matafuego matafuego, string color, Etiqueta etiqueta)
        {
            matafuego.Recargar(color, etiqueta);
            return ""; //algo va aca.
           
        }

    }
}
