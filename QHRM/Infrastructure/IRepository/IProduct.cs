using QHRM.Models;

namespace QHRM.Infrastructure.IRepository
{
    public interface IProduct
    {
        List<ProductInfo> GetProductsData();
        ProductInfo GetProductById(int id);
        ProductInfo AddProduct(ProductInfo productInfo);
        ProductInfo UpdateProduct(ProductInfo productInfo);
        ProductInfo DeleteProduct(ProductInfo infoModel);
    }
}