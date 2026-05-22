using System;
using System.Collections.Generic;

namespace CatalogoApp.Domain.Models
{
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Genero { get; set; }
        public string Consola { get; set; }
        public int Ano { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public string ImageUrl { get; set; } // Opcional, dependiendo de si usas Imagen o ImageUrl en las vistas

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
