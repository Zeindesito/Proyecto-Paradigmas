using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    [Serializable]
    public class Cliente : Persona
    {
        
        public string Email { get; set; }
        public List<Matafuego> Matafuegos { get; set; }
        public Cliente(string nombre, string apellido, string dni, string email, List<Matafuego> matafuegos) : base(nombre, apellido, dni)
        {
            Matafuegos = matafuegos;
            Email = email;
        }

        //PREGUNTA ASOCIALE LOS MATAFUEGOS AL CLIENTE POR MEDIO DEL SUS ATRIBUTOS ESTA MAL?
        //Deveria agregar un metodo para asociale matafuegos?
    }
}
