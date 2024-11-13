using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Servicio
    {
        public Tecnico TecnicoServicio { get; set; }
        //public List<Matafuego> Matafuegos { get; set; }
        public Cliente Cliente {  get; set; }
        public DateTime Fecha { get; set; }
        public double Costo {  get; set; }
        
        //determino el color del arosello anualmente
        public string ColorArosello { get; private set; }
        // Lista de colores rotativos (podrías cambiar o añadir colores si deseas)
        private static readonly string[] ColoresArosello = { "Verde", "Rojo", "Azul", "Amarillo", "Naranja" };






        //Servicio
        public Servicio(Tecnico tecnico, Cliente cliente, DateTime fecha)
        {
            Cliente = cliente;
            TecnicoServicio = tecnico;
            Fecha = fecha;
        }
        public void RealizarMantenimiento()
        {
            // Realizar el mantenimiento a los matafuegos   
            List<Matafuego> matafuegosRecargados = new List<Matafuego>();
            foreach (var matafuego in Cliente.Matafuegos)
            {
                Etiqueta nuevaetiqueta = new Etiqueta();
                nuevaetiqueta.Rellenar(Fecha, Fecha.AddYears(1), matafuego);
                matafuegosRecargados.Add(TecnicoServicio.RecargarMatafuego(matafuego, ObtenerColorAroselloAnual(), nuevaetiqueta));
            }
            CalcularCostoTotalRecarga();

            //le paso al cliente la lista de matafuegos ya recargados
            Cliente.Matafuegos = matafuegosRecargados;
        }

        private static string ObtenerColorAroselloAnual()
        {
            int year = DateTime.Now.Year;
            int index = (year - 2024) % ColoresArosello.Length; // Empieza en 2024 con "Verde" y rota anualmente
            return ColoresArosello[index];
        }

        //por ahora lo dejamos asi!!!
        private void CalcularCostoTotalRecarga()
        {
            Costo = 0;
            //recorro la lista de matafuegos para calcular cuando vale la recarga de cada uno, dependiendo del tipo
            foreach (var matafuego in Cliente.Matafuegos)
            {
                Costo += matafuego.PrecioRecarga; //CONSULTAR ESTO ROMPE EL ENCAPSULAMIENTO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }

        }
    }
}
