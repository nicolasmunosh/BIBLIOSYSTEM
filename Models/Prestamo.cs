namespace BiblioSystem.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public int UsuarioId { get; set; }

        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public bool Activo { get; set; }

        // Constructor vacío
        public Prestamo() { }

        // Constructor completo
        public Prestamo(int id, int libroId, int usuarioId)
        {
            Id = id;
            LibroId = libroId;
            UsuarioId = usuarioId;
            FechaPrestamo = DateTime.Now;
            Activo = true;
        }

        public void RegistrarDevolucion()
        {
            FechaDevolucion = DateTime.Now;
            Activo = false;
        }

        public override string ToString()
        {
            return $"Prestamo #{Id} - Libro: {LibroId} - Usuario: {UsuarioId} - Activo: {Activo}";
        }
    }
}