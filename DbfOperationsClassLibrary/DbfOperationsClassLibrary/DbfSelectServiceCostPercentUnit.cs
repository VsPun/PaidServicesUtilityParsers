using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CustomTypesForTablesRowsClassLibrary;

namespace DbfOperationsClassLibrary
{
    public class DbfSelectServiceCostPercentUnit : DbfOperationsUnit
    {
        private List<ServiceCostPercentRow> listDataRows = new List<ServiceCostPercentRow>();

        public DbfSelectServiceCostPercentUnit(string path, int cdi) : base(path, cdi)
        {
        }

        protected override void ReadDataTablesIntoListRows(string path)
        {
            DataSet fileDataSet = new DataSet();

            DataTable uslugaDataTable = ExecuteQuery("SELECT * FROM " + path + "\\USLUGA.DBF");
            fileDataSet.Tables.Add(uslugaDataTable);

            BuildServiceCostPercentRowsList(fileDataSet);
        }

        private void BuildServiceCostPercentRowsList(DataSet ds)
        {
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                if (dataRow[0].ToString() == "") break;

                ServiceCostPercentRow row = new ServiceCostPercentRow(dataRow);
                listDataRows.Add(row);
            }
        }

        public override IEnumerable<Dictionary<string, object>> RecordsForInsert()
        {
            foreach (ServiceCostPercentRow scpr in listDataRows)
            {
                Dictionary<string, object> serviceCostPercent = ParseRow(scpr);
                yield return serviceCostPercent;
            }
        }

        private Dictionary<string, object> ParseRow(ServiceCostPercentRow scpr)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            result["ServiceCode"] = scpr.ServiceCode;
            result["PrDr"] = scpr.PrDr;
            result["PrMs"] = scpr.PrMs;
            result["PrSn"] = scpr.PrSn;
            result["PrIn"] = scpr.PrIn;
            result["CashDeskId"] = cashDeskId;

            return result;
        }

        public override int GetSize()
        {
            return listDataRows.Count;
        }
    }
}
