using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Infrastructure.Repositories
{
    public class JsonItemRepository : IItemRepository
    {
        private readonly string _filePath;
        private List<Item> _items;

        public JsonItemRepository(string filePath)
        {
            _filePath = filePath;
            LoadItems();
        }

        private void LoadItems()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _items = JsonSerializer.Deserialize<List<Item>>(json) ?? new List<Item>();
            }
            else
            {
                _items = new List<Item>();
            }
        }

        private void SaveItems()
        {
            var json = JsonSerializer.Serialize(_items);
            File.WriteAllText(_filePath, json);
        }

        public List<Item> ObtenerTodos()
        {
            return _items;
        }

        public Item? ObtenerPorId(Guid id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public void Agregar(Item item)
        {
            item.Id = Guid.NewGuid(); // Remove the + operator error
            _items.Add(item);
            SaveItems();
        }

        public void Actualizar(Item item)
        {
            var index = _items.FindIndex(i => i.Id == item.Id);
            if (index != -1)
            {
                _items[index] = item;
                SaveItems();
            }
        }
        
        public void Eliminar(Guid id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
                SaveItems();
            }
        }

        public List<Item> GetAll()
        {
            return _items;
        }

        public Item GetById(Guid id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public void Add(Item item)
        {
            item.Id = Guid.NewGuid();
            _items.Add(item);
            SaveItems();
        }

        public void Update(Item item)
        {
             var index = _items.FindIndex(i => i.Id == item.Id);
            if (index != -1)
            {
                _items[index] = item;
                SaveItems();
            }
        }
    }
}
