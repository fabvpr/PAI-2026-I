using System;
using System.Collections.Generic;
using System.Text;

namespace Registro_de_clientes
{
    internal class Cliente
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public string DNI { get; set; }

        public string Direccion { get; set; }

        public string EstadoCivil { get; set; }

        public Cliente (string nombre, string apellidos, string dni, string dirección, string estadoCivil)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            DNI = dni;
            Direccion = dirección;
            EstadoCivil = estadoCivil;
        }

    }
}
