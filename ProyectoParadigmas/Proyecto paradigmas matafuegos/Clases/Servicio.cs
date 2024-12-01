using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos.Forms
{
    public class Servicio
    {
        public Tecnico Tecnico_ {get; set;}
        public Cliente Cliente_ { get; set;}
        public DateTime Fecha { get; set;}
        public double Costo { get; set;}

        public Servicio(Tecnico tecnico_, Cliente cliente_, DateTime fecha)
        {
            Tecnico_ = tecnico_;
            Cliente_ = cliente_;
            Fecha = fecha;
        }

        public double RealizarRecarga(Cliente cliente, Tecnico tecnico, DateTime fecha, string arosello)
        {
            Costo = 0;

            // Crear una lista temporal para iterar sin modificar la original
            List<Matafuego> matafuegosCopia = cliente.Matafuegos.ToList();

            // Lista para almacenar los matafuegos recargados
            List<Matafuego> matafuegosRecargados = new List<Matafuego>();

            foreach (var matafuego in matafuegosCopia)
            {
                // Cargar los datos de la etiqueta del matafuego
                matafuego.EtiquetaMatafuego.Rellenar(fecha, fecha.AddYears(1), arosello);

                // Llamar al técnico para recargar el matafuego y agregarlo a la lista de recargados
                Matafuego matafuegoRecargado = tecnico.RecargarMatafuego(matafuego, arosello);
                matafuegosRecargados.Add(matafuegoRecargado);

                // Sumar el costo de la recarga al costo total
                Costo += matafuegoRecargado.PrecioRecarga;
            }

            // Actualizar la lista de matafuegos del cliente con los recargados
            cliente.Matafuegos = matafuegosRecargados;

            // Retornar el costo total de la recarga
            return Costo;
        }




        private double CalcularCostoTotalRecarga(Cliente cliente)
        {
            double Costo = 0;
            //recorro la lista de matafuegos para calcular cuando vale la recarga de cada uno, dependiendo del tipo
            foreach (var matafuego in cliente.Matafuegos)
            {
                Costo += matafuego.PrecioRecarga; //CONSULTAR ESTO ROMPE EL ENCAPSULAMIENTO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
            return Costo;
        }

        /*
        public string ColorArosello { get; private set; }
        // Lista de colores rotativos (podrías cambiar o añadir colores si deseas)
        private static readonly string[] ColoresArosello = { "Verde", "Rojo", "Azul", "Amarillo", "Naranja" };

        private static string ObtenerColorAroselloAnual()
        {
            int year = DateTime.Now.Year;
            int index = (year - 2024) % ColoresArosello.Length; // Empieza en 2024 con "Verde" y rota anualmente
            return ColoresArosello[index];
        }
        */
    }
}
