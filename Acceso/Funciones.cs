﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Acceso
{
    public class Funciones
    {
        Base b = new Base("localhost", "root", "", "Tienda");
        public string Guardar(string q)
        {
            return b.Comando(q);
        }

        public DataSet Mostrar(string q, string tabla)
        {
            return b.Mostrar(q, tabla);
        }
        public string Borrar(string q)
        {
            return b.Comando(q);
        }

        public string Modificar(string q)
        {
            return b.Comando(q);
        }
        public string ObtenerDatos(string q, string tabla, string campo)
        {
            return b.ObtenerDatos(q, tabla, campo);
        }
    }
}

