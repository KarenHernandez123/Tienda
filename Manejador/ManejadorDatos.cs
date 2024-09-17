using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso;
using Entidades;

namespace Manejador
{
    public class ManejadorDatos
    {
        private Funciones f = new Funciones();
        public DataSet ObtenerProductos()
        {
            string query = "SELECT * FROM Productos";
            return f.Mostrar(query, "Productos");
        }

        public string GuardarProducto(Productos producto)
        {
            string query = $"INSERT INTO Productos (nombre, descripcion, precio) VALUES ('{producto.Nombre}', '{producto.Descripcion}', {producto.Precio})";
            return f.Guardar(query);
        }

        public string ModificarProducto(Productos producto)
        {
            string query = $"UPDATE Productos SET nombre = '{producto.Nombre}', descripcion = '{producto.Descripcion}', precio = {producto.Precio} WHERE idproducto = {producto.Id}";
            return f.Modificar(query);
        }

        public string BorrarProducto(int id)
        {
            string query = $"DELETE FROM Productos WHERE idproducto = {id}";
            return f.Borrar(query);
        }
    }
}
