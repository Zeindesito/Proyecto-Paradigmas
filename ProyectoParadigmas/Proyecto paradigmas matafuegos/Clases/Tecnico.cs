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
        public Tecnico(string nombre, string apellido, string dni,string codigoEmpleado) : base(nombre, apellido,dni, codigoEmpleado)
        {

        }

        //metodos
        public string RecargarMatafuego(Matafuego matafuego, string color, Etiqueta etiqueta)
        {
            matafuego.Recargar(color, etiqueta);//daba error, no todas las rutas devuelven un valor. sino poner public void RecargarMatafuego
            return "El matafuego ha sido cargado correctamente";
        }

    }
}
