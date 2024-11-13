using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Servicio
    {
        public Tecnico TecnicoServicio { get; set; }
        public List<Matafuego> Matafuegos;
        public Cliente cliente;
        public DateTime Fecha { get; set; }

        //determino el color del arosello anualmente
        public string ColorArosello { get; private set; }
        // Lista de colores rotativos (podrías cambiar o añadir colores si deseas)
        private static readonly string[] ColoresArosello = { "Verde", "Rojo", "Azul", "Amarillo", "Naranja" };

        public Servicio(Tecnico tecnico, List<Matafuego> matafuegos, Cliente cliente, DateTime fecha)
        {
            this.Matafuegos = matafuegos;
            this.cliente = cliente;
            this.Fecha = fecha;
        }
        public void RealizarMantenimiento()
        {
            // Realizar el mantenimiento a los matafuegos   
            foreach (var matafuego in Matafuegos)
            {
                Etiqueta nuevaetiqueta = new Etiqueta();
                nuevaetiqueta.Rellenar(DateTime.Now, DateTime.Now.AddYears(1), matafuego);
                TecnicoServicio.RecargarMatafuego(matafuego, ObtenerColorAroselloAnual(), nuevaetiqueta);
            }
        }

        private static string ObtenerColorAroselloAnual()
        {
            int year = DateTime.Now.Year;
            int index = (year - 2024) % ColoresArosello.Length; // Empieza en 2024 con "Verde" y rota anualmente
            return ColoresArosello[index];
        }

        public double CalcularCosto(Matafuego matafuego)
        {
            return matafuego.CalcularCosto();
        }
    }
}
