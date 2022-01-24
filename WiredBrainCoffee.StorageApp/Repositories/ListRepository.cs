﻿using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class ListRepository<TItem> : IRepository<TItem> where TItem : IEntity
        
    {
        private readonly List<TItem> _items = new();        

        public TItem GetById(int id)
        {
             return _items.Single(item => item.Id == id);           
        }

        public void Add(TItem item)
        {
            //item.Id=_items.Count + 1;
            item.Id = _items.Any()
                ? _items.Max(item => item.Id) + 1
                : 1;
            _items.Add(item);
        }

        public void Remove(TItem item)
        {
            _items.Remove(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }

}
