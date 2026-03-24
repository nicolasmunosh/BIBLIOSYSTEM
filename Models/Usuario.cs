namespace BiblioSystem.Models
{
    public class Usuario
    {
        // Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Correo { get; set; } = "";
        public bool Activo { get; set; }

        // Constructor vacío
        public Usuario() { }

        // Constructor completo
        public Usuario(int id, string nombre, string correo, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            Activo = activo;
        }

        // Método corto
        public string ResumenCorto()
        {
            return $"{Id} - {Nombre}";
        }

        // Método completo
        public string DetalleCompleto()
        {
            return $"ID: {Id}\nNombre: {Nombre}\nCorreo: {Correo}\nActivo: {(Activo ? "Sí" : "No")}";
        }

        // ToString
        public override string ToString()
        {
            return $"{Nombre} ({Correo})";
        }
    }
}