using System;
using System.Collections.Generic;
using System.Linq;
using BiblioSystem.Models;

namespace BiblioSystem.Services
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos = new List<Prestamo>();

        // Agregar préstamo
        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamos.Add(prestamo);
        }

        // Obtener todos
        public List<Prestamo> ObtenerTodos()
        {
            return prestamos;
        }

        // Buscar por usuario
        public List<Prestamo> BuscarPorUsuario(int usuarioId)
        {
            return prestamos
                .Where(p => p.UsuarioId == usuarioId)
                .ToList();
        }

        // Buscar por libro
        public List<Prestamo> BuscarPorLibro(int libroId)
        {
            return prestamos
                .Where(p => p.LibroId == libroId)
                .ToList();
        }

        // Eliminar préstamo
        public void EliminarPrestamo(int id)
        {
            var prestamo = prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamo != null)
            {
                prestamos.Remove(prestamo);
            }
        }

        // Ordenar por fecha
        public List<Prestamo> OrdenarPorFecha()
        {
            return prestamos.OrderBy(p => p.FechaPrestamo).ToList();
        }
    }
}