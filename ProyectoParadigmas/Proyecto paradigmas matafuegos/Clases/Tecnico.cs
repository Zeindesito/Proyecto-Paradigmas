﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Tecnico : Persona
    {
        //constructor parametrizado
        public Tecnico(string nombre, string apellido, string dni) : base(nombre, apellido, dni)
        {
        }

        //metodos
        public Matafuego RecargarMatafuego(Matafuego matafuego, string color)
        {
            //no le paso una lista directamente porque necesito una etiqueta para cada matafuego, en la implementacion se hace
            matafuego.Recargar(color);
            return matafuego;
        }

        public string ApellidoYnombre()
        {

           return $"{Apellido}, {Nombre}"; // Concatenación con formato
            
        }

    }
}
