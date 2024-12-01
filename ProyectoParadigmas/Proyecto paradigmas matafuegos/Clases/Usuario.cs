using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos.Clases
{
    public static class Usuario
    {
        private static Dictionary<string, string> usuarios = new Dictionary<string, string>
    {
        { "Agustin", "4017" }, // Usuario: Agustin, Contraseña: 4017
    };

        public static bool ValidarUsuario(string usuario, string contraseña)
        {
            return usuarios.ContainsKey(usuario) && usuarios[usuario] == contraseña;
        }
    }
}
