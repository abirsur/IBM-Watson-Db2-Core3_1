using APPCOVID.DAL.DataManagers.Managers;
using APPCOVID.Entity.DTO;
using APPCOVID.Entity.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace APPCOVID.BAL.Helpers
{
    public class ProductHelper
    {
        private ProductManager _productManager;
        public ProductHelper()
        {
            _productManager = new ProductManager();
        }

        public IList<ProductViewModel> GetAll()
        {
            List<ProductDto> products = _productManager.GetProductData();
            return viewMapper(products);
        }

        public bool CreateProduct(ProductViewModel product)
        {
            return _productManager.CreateInsuranceProduct(product);
        }

        public IList<ProductViewModel> viewMapper(List<ProductDto> products)
        {
            return products.Select(t => t.ConvertTo<ProductViewModel>()).AsEnumerable().ToList();
        }
    }
}
