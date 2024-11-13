﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_paradigmas_matafuegos
{
    public class Cliente : Persona
    {
        public List<Matafuego> Matafuegos { get; set; }
        public Cliente(string nombre, string apellido, string dni) : base(nombre, apellido, dni)
        {
            Matafuegos = new List<Matafuego>();
        }



    }
}
