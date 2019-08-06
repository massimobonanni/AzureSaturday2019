using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Interfaces;

namespace WebAPI.Repositories
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private static readonly ConcurrentDictionary<int, Product> products = new ConcurrentDictionary<int, Product>();

        public bool Add(Product entity)
        {
            int newId = 1;
            if (products.Keys.Any())
                newId = products.Keys.Max() + 1;
            entity.Id = newId;
            return products.TryAdd(newId, entity);
        }

        public bool Delete(int entityId)
        {
            if (products.ContainsKey(entityId))
            {
                Product product;
                return products.TryRemove(entityId, out product);
            }
            return false;
        }

        public IQueryable<Product> GetAll()
        {
            return products.Values.AsQueryable();
        }

        public Product GetById(int id)
        {
            if (products.ContainsKey(id))
                return products[id];
            return null;
        }

        public bool Update(Product entity)
        {
            if (products.ContainsKey(entity.Id))
            {
                products[entity.Id] = entity;
                return true;
            }
            return false;
        }
    }
}
