using Dapper;
using QHRM.Infrastructure.IRepository;
using QHRM.Models;
using System.Data;

namespace QHRM.Infrastructure.Repository
{
    public class Product : IProduct
    {
        private readonly IDapperServices _dapper;

        public Product(IDapperServices dapper)
        {
            _dapper = dapper;
        }

        public ProductInfo AddProduct(ProductInfo productInfo)
        {
            ProductInfo model = new ProductInfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("Sr_No", productInfo.Sr_No);
                dbPara.Add("Pro_Name", productInfo.Pro_Name);
                dbPara.Add("Pro_Description", productInfo.Pro_Description);
                dbPara.Add("Pro_Price", productInfo.Pro_Price);
                dbPara.Add("Pro_Created", productInfo.Pro_Created);
                model.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<ProductInfo>("ProductAddEdit", dbPara, commandType: CommandType.StoredProcedure)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }

        public ProductInfo DeleteProduct(ProductInfo infoModel)
        {
            ProductInfo model = new ProductInfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@Sr_No", infoModel.Sr_No);
                model.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<ProductInfo>("ProductDelete", dbPara, commandType: CommandType.StoredProcedure)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }

        public ProductInfo GetProductById(int id)
        {
            var query = @"select * from Product where Sr_No = @Sr_No";
            ProductInfo productInfo = new ProductInfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("Sr_No", id);
                productInfo = Task.FromResult(_dapper.Get<ProductInfo>(query, dbPara, commandType: CommandType.Text)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return productInfo;
        }

        public List<ProductInfo> GetProductsData()
        {
            var query = @"select * from Product";
            List<ProductInfo> products = new List<ProductInfo>();
            try
            {
                products = Task.FromResult(_dapper.GetAll<ProductInfo>(query, null, commandType: CommandType.Text)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return products;
        }

        public ProductInfo UpdateProduct(ProductInfo productInfo)
        {
            ProductInfo model = new ProductInfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("Sr_No", productInfo.Sr_No);
                dbPara.Add("Pro_Name", productInfo.Pro_Name);
                dbPara.Add("Pro_Description", productInfo.Pro_Description);
                dbPara.Add("Pro_Price", productInfo.Pro_Price);
                dbPara.Add("Pro_Created", productInfo.Pro_Created);
                productInfo.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<ProductInfo>("ProductAddEdit", dbPara, commandType: CommandType.StoredProcedure)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }
    }
}
