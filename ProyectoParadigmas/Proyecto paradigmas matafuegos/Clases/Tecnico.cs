using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Tecnico : Persona
    {
        //constructor parametrizado
        public Tecnico(string nombre, string apellido, string dni) : base(nombre, apellido, dni)
        {

        }

        //metodos
        public Matafuego RecargarMatafuego(Matafuego matafuego, string color, Etiqueta etiqueta)
        {
            matafuego.Recargar(color, etiqueta);//daba error, no todas las rutas devuelven un valor. sino poner public void RecargarMatafuego
            return matafuego;
        }

    }
}
