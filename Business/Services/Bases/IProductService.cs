using AppCore.Business.Models.Results;
using AppCore.Business.Services.Base;
using Business.Models;

namespace Business.Services.Bases
{
    public interface IProductService: IService<ProductModel>
    {
        Result FakeDelete(string guId);
    }
}
