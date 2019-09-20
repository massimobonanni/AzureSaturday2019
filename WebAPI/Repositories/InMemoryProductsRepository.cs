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
    /// <summary>
    /// Class InMemoryProductsRepository.
    /// Implements the <see cref="WebAPI.Interfaces.IProductsRepository" />
    /// </summary>
    /// <seealso cref="WebAPI.Interfaces.IProductsRepository" />
    public class InMemoryProductsRepository : IProductsRepository
    {
        public InMemoryProductsRepository()
        {
            SeedData();
        }

        private void SeedData()
        {
            if (!products.Any())
            {
                foreach (var product in ProductsHelper.GenerateProducts())
                {
                    products.TryAdd(product.Id, product);
                }
            }
        }

        /// <summary>
        /// The products
        /// </summary>
        private static readonly ConcurrentDictionary<int, Product> products = new ConcurrentDictionary<int, Product>();

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Add(Product entity)
        {
            int newId = 1;
            if (products.Keys.Any())
                newId = products.Keys.Max() + 1;
            entity.Id = newId;
            return products.TryAdd(newId, entity);
        }

        /// <summary>
        /// Deletes the specified entity identifier.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Delete(int entityId)
        {
            if (products.ContainsKey(entityId))
            {
                Product product;
                return products.TryRemove(entityId, out product);
            }
            return false;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IQueryable&lt;Product&gt;.</returns>
        public IQueryable<Product> GetAll()
        {
            return products.Values.AsQueryable();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product.</returns>
        public Product GetById(int id)
        {
            if (products.ContainsKey(id))
                return products[id];
            return null;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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
