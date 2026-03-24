namespace BiblioSystem.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = "";
        public string Autor { get; set; } = "";
        public bool Disponible { get; set; }

        // Constructor vacío
        public Libro()
        {
            Disponible = true;
        }

        // Constructor completo
        public Libro(int id, string titulo, string autor)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Disponible = true;
        }

        public Libro(int id, string titulo, string autor, bool disponible)
{
    Id = id;
    Titulo = titulo;
    Autor = autor;
    Disponible = disponible;
}

        // Método corto
        public string ResumenCorto()
        {
            return $"{Id} - {Titulo}";
        }

        // Método detallado
        public string DetalleCompleto()
        {
            return $"ID: {Id}\nTítulo: {Titulo}\nAutor: {Autor}\nDisponible: {(Disponible ? "Sí" : "No")}";
        }

        // ToString
        public override string ToString()
        {
            return $"{Titulo} - {Autor}";
        }
    }
}