using System;
using System.Collections.Generic;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class GenericRepository<TItem>
    {
           // To use set GenericRepository to <Items,TKey>
       // public TKey? Key { get; set; }

        private readonly List<TItem> _items = new(); // protected to read commented area below*

        public void Add(TItem item)
        {
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
    // just a class created to learn about Inheritance 

    //public class GenericRepositoryWithRemove<TItem> : GenericRepository<TItem,string>
    // {
    //     public void Remove(TItem item)
    //    {
    //       _items.Remove(item);
    //     }
    //  }
}
