using System;
using System.Collections.Generic;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Domain.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item GetById(Guid id);
        void Add(Item item);
        void Update(Item item);
        void Eliminar(Guid id);
    }
}
