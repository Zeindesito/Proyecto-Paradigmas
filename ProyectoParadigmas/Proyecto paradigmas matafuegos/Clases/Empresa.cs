using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Empresa
    {
        public List<Tecnico> TecnicoList { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Matafuego> MatafuegosList { get; set; }

        //constructor
        public Empresa(List<Tecnico> tecnicos, List<Cliente> clientes, List<Matafuego> matafuegos)
        {
            //deberia usar composicion?
            TecnicoList = tecnicos;
            Clientes = clientes;
            MatafuegosList = matafuegos;
        }

        //metodos
        public void AñadirCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public double RealizarServicio(Cliente cliente, Tecnico tecnico, DateTime Fecha)
        {
            double Costo = 0;
            // Realizar el mantenimiento a los matafuegos   
            List<Matafuego> matafuegosRecargados = new List<Matafuego>();
            foreach (var matafuego in cliente.Matafuegos)
            {
                Etiqueta nuevaetiqueta = new Etiqueta();
                nuevaetiqueta.Rellenar(Fecha, Fecha.AddYears(1), matafuego);
                matafuegosRecargados.Add(tecnico.RecargarMatafuego(matafuego, ObtenerColorAroselloAnual(), nuevaetiqueta));
            }

            //le paso al cliente la lista de matafuegos ya recargados
            cliente.Matafuegos = matafuegosRecargados;

            return Costo = CalcularCostoTotalRecarga(cliente);

        }

        public double VenderMatafuego(List<Matafuego> matafuegos, Cliente cliente)
        {
            foreach (var matafuego in matafuegos)
            {
                cliente.Matafuegos.Add(matafuego);
            }

            return CalcularCostoTotalVenta(matafuegos);
        }

        //por ahora lo dejamos asi!!!
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

        private double CalcularCostoTotalVenta(List<Matafuego> matafuegos)
        {
            double Costo = 0;
            foreach (var matafuego in matafuegos)
            {
               Costo += matafuego.PrecioVenta;
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
