using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;//formatear
using System.IO; //manejar archivos

namespace Proyecto_paradigmas_matafuegos.Forms
{
    [Serializable]
    public class Sistema
    {
        public List<Cliente> Clientes { get; set; } = new List<Cliente> { };

        public List<Tecnico> Tecnicos { get; set; } = new List<Tecnico> { };

        public List<Matafuego_ABC> MatafuegoABC { get; set; } = new List<Matafuego>


        public void Save()
        {
            var fileName = "ELmaskapito";
            var formater = new BinaryFormatter();
            var file = new FileStream(fileName, FileMode.OpenOrCreate);

            formater.Serialize(file,this);
            file.Close();
        }

        public static Sistema Open()
        {
            var filename = "Elmaskapito";
            var formater = new BinaryFormatter();
            var file = new FileStream(filename, FileMode.OpenOrCreate);

            var sistema = formater.Deserialize(file) as Sistema;
            file.Close();
            return sistema;
        }
    }
}
