using System.Linq;
using WebAPI.DTOs;
using WebAPI.Entities;

namespace WebAPI.Interfaces
{
    public interface IProductsRepository : IEntityRepository<Product>
    {

    }
}