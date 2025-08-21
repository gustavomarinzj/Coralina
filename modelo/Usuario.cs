using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coralina.modelo
{
    class Usuario
    {

        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Contrasenna { get; set; }
        public int? Estado { get; set; } // ? aceptamos que puede ser nulo

        public Usuario(int cedula, string nombre, string username, string contrasenna, int? estado = null)
        {
            Cedula = cedula;
            Nombre = nombre;
            UserName = username;
            Contrasenna = contrasenna;
            Estado = estado;
        }
    }
}

// Los tipos Nullable representan una solución elegante a un problema común en la programación: 
// el manejo de situaciones donde un tipo de valor necesita representar la ausencia de un valor válido