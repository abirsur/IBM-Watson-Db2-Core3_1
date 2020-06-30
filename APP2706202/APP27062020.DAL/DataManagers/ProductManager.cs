using APP27062020.DAL.DataManagers.Core;
using APP27062020.DAL.DTO;
using System.Collections.Generic;

namespace APP27062020.DAL.DataManagers
{
    public class ProductManager : DataManager<ProductInsurance>
    {
        private const string productInsTableName = @"FHK80997.TBLINSURANCEPRODUCT";
        private readonly string getAllDataQuery = $@"select * from {productInsTableName}";
        DataManager<ProductInsurance> dataManager;

        public ProductManager()
        {
            dataManager = new DataManager<ProductInsurance>();
        }
        public List<ProductInsurance> GetInsuranceProductData()
        {
            return dataManager.GetData(getAllDataQuery);
        }

        public bool CreateInsuranceProduct(ProductInsurance product)
        {
            string prepareQuery = $@"insert into {productInsTableName} values({product.ID},'{product.NAME}', '{product.SHORTDESCRIPTION}', '{product.PRODUCTURL}')";
            return dataManager.InsertData(prepareQuery);
        }

    }
}
