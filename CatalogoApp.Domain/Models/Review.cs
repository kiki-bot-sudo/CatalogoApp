using System;

namespace CatalogoApp.Domain.Models
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Autor { get; set; }
        public int Calificacion { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
