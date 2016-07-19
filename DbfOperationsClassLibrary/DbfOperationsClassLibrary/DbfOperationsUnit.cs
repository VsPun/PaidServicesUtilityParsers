using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace DbfOperationsClassLibrary
{
    public abstract class DbfOperationsUnit
    {
        protected string connectionString;
        protected int cashDeskId;
        private string path;

        protected DbfOperationsUnit(string path, int cdi)
        {
            SetConnectionString(path);
            cashDeskId = cdi;
            ReadDataTablesIntoListRows(path);
        }

        private void SetConnectionString(string path)
        {
            connectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" +
                path + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
        }

        abstract protected void ReadDataTablesIntoListRows(string path);

        abstract public IEnumerable<Dictionary<string, object>> RecordsForInsert();

        abstract public int GetSize();

        protected DataTable ExecuteQuery(string command)
        {
            DataTable selectDataTable = new DataTable();
            OdbcCommand DBFCommand;

            using (OdbcConnection connect = new OdbcConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    DBFCommand = new OdbcCommand(command, connect);
                    selectDataTable.Load(DBFCommand.ExecuteReader());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }

            return selectDataTable;
        }
    }
}
