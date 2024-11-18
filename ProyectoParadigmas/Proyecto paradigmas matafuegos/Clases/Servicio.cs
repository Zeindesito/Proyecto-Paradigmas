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

        public Servicio(Tecnico tecnico_, Cliente cliente_, DateTime fecha)
        {
            Tecnico_ = tecnico_;
            Cliente_ = cliente_;
            Fecha = fecha;
        }

        public double RealizarRecarga(Cliente cliente, Tecnico tecnico, DateTime Fecha)
        {
            double Costo = 0;
            // Realizar el mantenimiento a los matafuegos   
            List<Matafuego> matafuegosRecargados = new List<Matafuego>();
            foreach (var matafuego in cliente.Matafuegos)
            {
                //Etiqueta nuevaetiqueta = new Etiqueta();
                matafuego.EtiquetaMatafuego.Rellenar(Fecha, Fecha.AddYears(1), matafuego.DeterminarTipo());
                matafuegosRecargados.Add(tecnico.RecargarMatafuego(matafuego, ObtenerColorAroselloAnual()));
            }

            //le paso al cliente la lista de matafuegos ya recargados
            cliente.Matafuegos = matafuegosRecargados;

            return Costo = CalcularCostoTotalRecarga(cliente);
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

        public string ColorArosello { get; private set; }
        // Lista de colores rotativos (podrías cambiar o añadir colores si deseas)
        private static readonly string[] ColoresArosello = { "Verde", "Rojo", "Azul", "Amarillo", "Naranja" };

        private static string ObtenerColorAroselloAnual()
        {
            int year = DateTime.Now.Year;
            int index = (year - 2024) % ColoresArosello.Length; // Empieza en 2024 con "Verde" y rota anualmente
            return ColoresArosello[index];
        }
    }
}
