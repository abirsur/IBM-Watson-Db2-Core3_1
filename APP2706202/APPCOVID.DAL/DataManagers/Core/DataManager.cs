using IBM.Data.DB2.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using static APPCOVID.DAL.DataManagers.Helper.DataManagerHelper;

namespace APPCOVID.DAL.DataManagers.Core
{
    public class DataManager<TEntity> where TEntity : class
    {
        private readonly string _connectionString = @"Server=dashdb-txn-sbox-yp-lon02-06.services.eu-gb.bluemix.net:50000;DATABASE=BLUDB;UID=fhk80997;PWD=j32sd1pn@m8xd2x2;";
        private readonly DB2Connection _db2Connection;
        private string _query;

        #region Constructor
        public DataManager()
        {
            _db2Connection = new DB2Connection(_connectionString);
        }

        #endregion

        #region Create Drop Exists Table

        private bool GenericExcuteNonQuery(string query)
        {
            bool result = false;
            try
            {
                _db2Connection.Open();
                DB2Command DBCmd = new DB2Command(query, _db2Connection);
                DBCmd.ExecuteNonQuery();
                _db2Connection.Close();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex; ;
            }
            finally
            {
                _db2Connection.Close();

            }
            return result;
        }

        public bool IsTableExistsinDb(string schema, string tableName)
        {
            DataTable dt = GetDb2Data($@"select tabname from syscat.tables where tabschema='{schema}' and tabname='{tableName}'");
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public DbDropStatus DropTable(string schema, string deleteTableName)
        {
            if (IsTableExistsinDb(schema, deleteTableName))
            {
                return GenericExcuteNonQuery($@"drop table {schema}.{deleteTableName}") ? DbDropStatus.DropSuccess : DbDropStatus.DropFailed;
            }
            return DbDropStatus.NotExists;
        }

        public bool CreateNewTable(string createTableQuery, string tableName, string schema)
        {
            var drpStatus = DropTable(tableName, schema);
            if (drpStatus == DbDropStatus.DropSuccess || drpStatus == DbDropStatus.NotExists)
            {
                return GenericExcuteNonQuery(createTableQuery);
            }
            return false;
        }

        #endregion

        #region Get Data in List of Model

        public List<TEntity> GetData(string query)
        {
            _query = query;
            return DataReaderMapToList();
        }
        private List<TEntity> DataReaderMapToList()
        {
            DataTable dataTable = GetDb2Data(_query);
            List<TEntity> list = new List<TEntity>();
            TEntity obj = default;
            if (dataTable == null) return list;
            foreach (DataRow row in dataTable.Rows)
            {
                obj = Activator.CreateInstance<TEntity>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!Equals(row[prop.Name], DBNull.Value))
                    {
                        if (prop.PropertyType.FullName.ToLower() == @"system.string")
                        {
                            string objValue = row[prop.Name].ToString().Trim();
                            prop.SetValue(obj, objValue, null);
                        }
                        else
                        {
                            prop.SetValue(obj, row[prop.Name], null);
                        }
                    }
                }
                list.Add(obj);
            }
            return list;
        }
        private DataTable GetDb2Data(string query)
        {
            DataSet dataSet = new DataSet();
            DB2Command db2Command = new DB2Command(query, _db2Connection);
            try
            {
                _db2Connection.Open();
                DB2DataAdapter dB2DataAdapter = new DB2DataAdapter();
                DB2CommandBuilder dB2CommandBuilder = new DB2CommandBuilder(dB2DataAdapter);
                dB2DataAdapter.SelectCommand = db2Command;
                dB2DataAdapter.Fill(dataSet);
                _db2Connection.Close();
            }
            catch (DB2Exception ex)
            {
                throw ex;
            }
            finally
            {
                _db2Connection.Close();
            }
            return dataSet.Tables.Count > 0 ? dataSet.Tables[0] : null;
        }
        #endregion

        #region Insert

        public bool InsertData(string query)
        {
            bool result = false;
            try
            {
                _db2Connection.Open();
                DB2Command DBCmd = new DB2Command(query, _db2Connection);
                DBCmd.ExecuteNonQuery();
                _db2Connection.Close();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex; ;
            }
            finally
            {
                _db2Connection.Close();

            }
            return result;
        }
        #endregion

    }
}
