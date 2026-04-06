using System;
using System.Collections.Generic;
using System.Linq;
using BiblioSystem.Models;

namespace BiblioSystem.Services
{
    public class LibroService
    {
        private List<Libro> libros = new List<Libro>();

        // Agregar libro
        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        // Obtener todos
        public List<Libro> ObtenerTodos()
        {
            return libros;
        }

        // Buscar por título
        public List<Libro> BuscarPorTitulo(string texto)
        {
            return libros
                .Where(l => l.Titulo.ToLower().Contains(texto.ToLower()))
                .ToList();
        }

        // Eliminar por ID
        public void EliminarLibro(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);
            if (libro != null)
            {
                libros.Remove(libro);
            }
        }

        // Ordenar por título
        public List<Libro> OrdenarPorTitulo()
        {
            return libros.OrderBy(l => l.Titulo).ToList();
        }

        // KPIs
public int TotalLibros()
{
    return libros.Count;
}

public int LibrosDisponibles()
{
    return libros.Count(l => l.Disponible);
}

public int LibrosPrestados()
{
    return libros.Count(l => !l.Disponible);
}
    }
}