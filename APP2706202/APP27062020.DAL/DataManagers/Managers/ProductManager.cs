using APP27062020.DAL.DataManagers.Core;
using APP27062020.DAL.DataManagers.Helper;
using APP27062020.DAL.DTO;
using System.Collections.Generic;

namespace APP27062020.DAL.DataManagers
{
    public class ProductManager : DataManager<ProductDto>
    {
        #region Db Queries 
        private readonly string createTableQuery = "";
        private readonly string getAllDataQuery = $@"select * from {DalCostants.TABLE_SCHEMA}.{DalCostants.PRODUCT_TABLE}";
       
        #endregion

        private DataManager<ProductDto> _dataManager;

        public ProductManager()
        {
            _dataManager = new DataManager<ProductDto>();
            if (!_dataManager.IsTableExistsinDb(DalCostants.TABLE_SCHEMA, DalCostants.PRODUCT_TABLE))
            {
                _dataManager.CreateNewTable(createTableQuery, DalCostants.TABLE_SCHEMA, DalCostants.PRODUCT_TABLE);
            }
        }

        public List<ProductDto> GetInsuranceProductData()
        {
            return _dataManager.GetData(getAllDataQuery);
        }

        public bool CreateInsuranceProduct(ProductDto product)
        {
            string prepareQuery = $@"insert into {DalCostants.TABLE_SCHEMA}.{DalCostants.PRODUCT_TABLE} 
                            values({product.ID},'{product.NAME}', '{product.SHORTDESCRIPTION}', '{product.PRODUCTURL}')";
            return _dataManager.InsertData(prepareQuery);
        }

    }
}
