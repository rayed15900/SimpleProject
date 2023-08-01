using BusinessLogic.DTOs.ProductDTOs;
using BusinessLogic.Interfaces.Base;
using Models;

namespace BusinessLogic.Interfaces
{
    public interface IProductService : IService<ProductCreateDTO, ProductUpdateDTO, ProductReadDTO, Product>
    {
    }
}
