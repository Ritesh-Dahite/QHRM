using System.Data;

namespace QHRM.Models
{
    public class ProductInfo
    {
        public int Sr_No { get; set; }
        public string Pro_Name { get; set; }
        public string Pro_Description { get; set; }
        public int Pro_Price { get; set; }
        public DateTime Pro_Created { get; set; }
        public int TotalRowCount { get; set; }
    }

    public class ProductInfoModel
    {
        private List<ProductInfo> _products = new List<ProductInfo>();

        public List<ProductInfo> ProductsList
        {
            get { return _products; }
            set { _products = value; }
        }
    }
}