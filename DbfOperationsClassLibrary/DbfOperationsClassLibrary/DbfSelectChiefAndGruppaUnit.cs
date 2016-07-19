using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomTypesForTablesRowsClassLibrary;
using System.Data;

namespace DbfOperationsClassLibrary
{
    public class DbfSelectChiefAndGruppaUnit : DbfOperationsUnit
    {
        private List<ChiefAndGruppaRow> listDataRows = new List<ChiefAndGruppaRow>();

        public DbfSelectChiefAndGruppaUnit(string path, int cdi) : base(path, cdi)
        {
        }

        protected override void ReadDataTablesIntoListRows(string path)
        {
            DataSet fileDataSet = new DataSet();

            DataTable gruppaDataTable = ExecuteQuery("SELECT * FROM " + path + "\\GRUPPA.DBF");
            DataTable chiefDataTable = ExecuteQuery("SELECT * FROM " + path + "\\CHIEF.DBF");

            fileDataSet.Tables.Add(gruppaDataTable);
            fileDataSet.Tables.Add(chiefDataTable);

            BuildChiefGruppaRowsList(fileDataSet);
        }

        private void BuildChiefGruppaRowsList(DataSet ds)
        {
            List<ChiefRow> chiefList = ParseChiefTable(ds.Tables[1]);
            List<GruppaRow> gruppaList = ParseGruppaTable(ds.Tables[0]);

            foreach (ChiefRow chief in chiefList)
            {
                foreach (GruppaRow gruppa in gruppaList)
                {
                    if (chief.NGrup == gruppa.NGrup)
                    {
                        ChiefAndGruppaRow row = new ChiefAndGruppaRow(chief, gruppa);

                        listDataRows.Add(row);
                    }
                }
            }
        }

        private List<ChiefRow> ParseChiefTable(DataTable dt)
        {
            List<ChiefRow> resultList = new List<ChiefRow>();

            foreach (DataRow dataRow in dt.Rows)
            {
                if (dataRow[0].ToString() == "") break;

                ChiefRow row = new ChiefRow(dataRow);
                resultList.Add(row);
            }

            return resultList;
        }

        private List<GruppaRow> ParseGruppaTable(DataTable dt)
        {
            List<GruppaRow> resultList = new List<GruppaRow>();

            foreach (DataRow dataRow in dt.Rows)
            {
                if (dataRow[0].ToString() == "") break;

                GruppaRow row = new GruppaRow(dataRow);
                resultList.Add(row);
            }

            return resultList;
        }

        public override IEnumerable<Dictionary<string, object>> RecordsForInsert()
        {
            foreach (ChiefAndGruppaRow cgr in listDataRows)
            {
                Dictionary<string, object> chiefAndGruppa = ParseRow(cgr);
                yield return chiefAndGruppa;
            }
        }

        private Dictionary<string, object> ParseRow(ChiefAndGruppaRow cgr)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            result["ChiefName"] = cgr.ChiefName;
            result["GruppaName"] = cgr.GruppaName;
            result["TabNum"] = cgr.TabNum;
            result["SalaryPercent"] = cgr.SalaryProcent;
            result["CashDeskId"] = cashDeskId;

            return result;
        }

        public override int GetSize()
        {
            return listDataRows.Count;
        }
    }
}
