using System;
using System.Collections.Generic;
using CatalogoApp.Domain.Models;
using CatalogoApp.Domain.Interfaces;

namespace CatalogoApp.Aplication.Services
{
    public class ItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public List<Item> GetAllItems()
        {
            return _repository.GetAll();
        }

        public Item GetItemById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void AddItem(Item item)
        {
            _repository.Add(item);
        }

        public void Eliminar(Guid id)
        {
            _repository.Eliminar(id);
        }

        public void Update(Item item)
        {
            _repository.Update(item);
        }

        public void AddReviewToItem(Guid itemId, Review review)
        {
            var item = _repository.GetById(itemId);
            if (item != null)
            {
                item.Reviews.Add(review);
                _repository.Update(item);
            }
        }
    }
}