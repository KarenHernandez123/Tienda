﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;
using Entidades;

namespace Tienda
{
    public partial class Form1 : Form
    {
      ManejadorDatos m;
        public Form1()
        {
            InitializeComponent();
            m=new ManejadorDatos();
            CargarProductos();
        }
        private void CargarProductos()
        {
            DataSet ds = m.ObtenerProductos();
            dtgvProducto.DataSource = ds.Tables["Productos"];
        }


        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrecio.Text, out decimal precio) &&
            !string.IsNullOrWhiteSpace(txtNombre.Text) &&
            !string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                var producto = new Productos
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio
                };

                string resultado = m.GuardarProducto(producto);
                MessageBox.Show(resultado);
                CargarProductos();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese datos válidos.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int id))
            {
                string resultado = m.BorrarProducto(id);
                MessageBox.Show(resultado);
                CargarProductos();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido.");
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int id) &&
               decimal.TryParse(txtPrecio.Text, out decimal precio) &&
               !string.IsNullOrWhiteSpace(txtNombre.Text) &&
               !string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                var producto = new Productos
                {
                    Id = id,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio
                };

                string resultado = m.ModificarProducto(producto);
                MessageBox.Show(resultado);
                CargarProductos();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese datos válidos.");
            }
        }
    }
}
