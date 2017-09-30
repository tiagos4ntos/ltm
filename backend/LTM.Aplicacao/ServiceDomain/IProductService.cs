using LTM.Application.Dto;
using System.Collections.Generic;

namespace LTM.Application.ServiceDomain
{
    public interface IProductService
    {
        IEnumerable<ProductDto> ListAll();
    }
}
