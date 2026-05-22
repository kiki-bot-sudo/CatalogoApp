using System;
using System.Collections.Generic;
using System.Linq;
using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentation.Controllers
{
    public class CatalogoController : Controller
    {
        private static List<Item> _items = new List<Item>
        {
            new Item { Id = Guid.NewGuid(), Titulo = "The Legend of Zelda: Breath of the Wild", Descripcion = "Un juego de aventura y mundo abierto", Precio = 59.99m, Genero = "Aventura", ImageUrl = "https://th.bing.com/th/id/OIP.YjE9R9l6m3q8h1x1c9y3gQHaEK?pid=ImgDet&rs=1"},
            new Item { Id = Guid.NewGuid(), Titulo = "Super Mario Odyssey", Descripcion = "Un juego de plataformas en 3D", Precio = 49.99m, Genero = "Plataformas", ImageUrl = "https://th.bing.com/th/id/OIP.Q0y1k2r8v3t9z4s7r3b8uAHaEK?pid=ImgDet&rs=1" },
            new Item { Id = Guid.NewGuid(), Titulo = "The Witcher 3: Wild Hunt", Descripcion = "Un juego de rol y mundo abierto", Precio = 39.99m, Genero = "Rol", ImageUrl = "https://th.bing.com/th/id/OIP.O2v3n4r8v3t9z4s7r3b8uAHaEK?pid=ImgDet&rs=1" }
        };

        private readonly CatalogoApp.Aplication.Services.ItemService _itemService;

        public CatalogoController(CatalogoApp.Aplication.Services.ItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index(string? genero)
        {
            // Tratar de obtener del servicio
            List<Item> itemsParaMostrar = _itemService.GetAllItems();
            
            // Si el servicio no devuelve nada, usamos la lista estática
            if (itemsParaMostrar == null || !itemsParaMostrar.Any())
            {
                itemsParaMostrar = _items;
            }

            return View(itemsParaMostrar);
        }

        public IActionResult Detalle(Guid id)
        {
            var item = _itemService.GetItemById(id);
            // Fallback a la lista estática si el item no se encuentra
            if (item == null)
            {
                item = _items.FirstOrDefault(i => i.Id == id);
            }
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            item.Id = Guid.NewGuid(); 
            _items.Add(item);
            
            _itemService.AddItem(item);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddReview(Guid id, string author, int rating, string content)
        {
            var review = new CatalogoApp.Domain.Models.Review
            {
                Autor = author,
                Calificacion = rating,
                Contenido = content
            };

            _itemService.AddReviewToItem(id, review); 

            return RedirectToAction("Detalle", new { id = id });
        }

        [HttpPost]
        public IActionResult Eliminar(Guid id)
        {
            _itemService.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}