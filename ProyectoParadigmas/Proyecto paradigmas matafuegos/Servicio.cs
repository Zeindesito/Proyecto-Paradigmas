using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Servicio
    {
        public Tecnico tecnico;
        public Matafuego matafuego;
        public Cliente cliente;
        public DateTime Fecha {  get; set; }


        public Servicio (Tecnico tecnico, Matafuego matafuego, Cliente cliente, DateTime fecha) 
        {
            this.tecnico = tecnico;
            this.matafuego = matafuego;
            this.cliente = cliente;
            this.Fecha = fecha;
        }

        public void RealizarMantenimiento()
        {
            Etiqueta nuevaetiqueta = new Etiqueta
            {
                FechaRevision = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddYears(1),
                //Matafuego_ = matafuego.GetType().Name //agregar atibuto en etiqueta

            };
        }


    }
}
