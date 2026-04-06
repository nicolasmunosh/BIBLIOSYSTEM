using System;
using System.Collections.Generic;
using System.Linq;
using BiblioSystem.Models;

namespace BiblioSystem.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();

        // Agregar usuario
        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        // Obtener todos
        public List<Usuario> ObtenerTodos()
        {
            return usuarios;
        }

        // Buscar por nombre
        public List<Usuario> BuscarPorNombre(string nombre)
        {
            return usuarios
                .Where(u => u.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToList();
        }

        // Eliminar usuario
        public void EliminarUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
            }
        }

        // Ordenar por nombre
        public List<Usuario> OrdenarPorNombre()
        {
            return usuarios.OrderBy(u => u.Nombre).ToList();
        }
    }
}