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
        public List<Matafuego> Matafuegos { get; set;}
        public DateTime Fecha { get; set;}
        public double Costo { get; set;}

        public Servicio(Tecnico tecnico_, Cliente cliente_, DateTime fecha)
        {
            Tecnico_ = tecnico_;
            Cliente_ = cliente_;
            Fecha = fecha;
        }

        public double RealizarRecarga(Cliente cliente, Tecnico tecnico, DateTime fecha, string arosello, List<Matafuego> matafuegos)
        {
            Costo = 0;

            // Lista para almacenar los matafuegos recargados
            Matafuegos = new List<Matafuego>();

            foreach (var matafuego in cliente.Matafuegos)
            {
                // Cargar los datos de la etiqueta del matafuego
                matafuego.EtiquetaMatafuego.Rellenar(fecha, fecha.AddYears(1), arosello);

                // Llamar al técnico para recargar el matafuego y agregarlo a la lista de recargados
                Matafuego matafuegoRecargado = tecnico.RecargarMatafuego(matafuego, arosello);
                Matafuegos.Add(matafuegoRecargado);

                // Sumar el costo de la recarga al costo total
                Costo += matafuegoRecargado.PrecioRecarga;
            }

            // Retornar el costo total de la recarga
            return Costo;
        }
    }
}
