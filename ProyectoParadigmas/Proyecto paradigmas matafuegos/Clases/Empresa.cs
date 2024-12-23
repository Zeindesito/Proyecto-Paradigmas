﻿using Proyecto_paradigmas_matafuegos.Clases;
using Proyecto_paradigmas_matafuegos.Forms;
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
        public List<Matafuego> MatafuegosList { get; set; } //inventario
        public List<Servicio> ServiciosRealizados { get; set; }

        //constructor
        public Empresa(List<Tecnico> tecnicos, List<Cliente> clientes, List<Matafuego> matafuegos, List<Servicio> servicios)
        {
            //deberia usar composicion?
            TecnicoList = tecnicos;
            Clientes = clientes;
            MatafuegosList = matafuegos;
            ServiciosRealizados = servicios;
        }

        //metodos
        public void AñadirTecnico(Tecnico tecnico)
        {
            TecnicoList.Add(tecnico);
        }
        public void AñadirCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public void CargarServicio(Servicio servicio)
        {
            ServiciosRealizados.Add(servicio);
        }

        public void AñadirMatafuego(Matafuego matafuego)
        {
            MatafuegosList.Add(matafuego);
        }

        public double VenderMatafuego(List<Matafuego> matafuegos, Cliente cliente)
        {
            foreach (var matafuego in matafuegos)
            {
                cliente.Matafuegos.Add(matafuego);
                MatafuegosList.Remove(matafuego);
            }
            return CalcularCostoTotalVenta(matafuegos);
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











        
    }
}
