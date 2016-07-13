using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace DbfOperationsClassLibrary
{
    public abstract class DbfOperationsUnit
    {
        #region константы строки подключения к фалйу БД
        //набор констант для формирования строки подключения
        private const string charset = "WIN1251";
        private const string userID = "SYSDBA";
        private const string password = "masterkey";
        private const int serverType = 0;
        #endregion

        protected FbConnection fbConnect;
        private FbConnectionStringBuilder fbStrBuild;
        protected FbTransaction transaction;

        //в конструкторе только формирование строки подключения, создание - в методе вставки записи
        protected DbfOperationsUnit(string path)
        {
            fbStrBuild = new FbConnectionStringBuilder();
            fbStrBuild.Charset = charset;
            fbStrBuild.UserID = userID;
            fbStrBuild.Password = password;
            fbStrBuild.ServerType = serverType;
            fbStrBuild.Database = path;
        }

        public void InsertRecord(Dictionary<string, object> dataForInsert)
        {
            using (fbConnect = new FbConnection(fbStrBuild.ToString()))
            {
                fbConnect.Open();
                transaction = fbConnect.BeginTransaction();

                try
                {
                    ParsingDictionary(dataForInsert);
                    DoInsert();
                    transaction.Commit();
                }
                catch (FbException ex)
                {
                    Logger.PrintLog(ex.Message);
                    transaction.Rollback();
                    throw;
                }
            }
        }

        //наследники получают из передаваемого словаря нужные для себч поля
        abstract protected void ParsingDictionary(Dictionary<string, object> dataForInsert);

        //метод с основной логикой вставки, перегружаемый наследниками
        abstract protected void DoInsert();
        
        //функция проверки налиция записи в таблице по табельному номеру (используется в двух наследниках)
        protected bool CheckExistRecordInTableByTabNum(string tabNum, string tableName)
        {
            int countRow = 1;
            string command = "SELECT COUNT(*) FROM " + tableName + " WHERE TAB_NUM = ?";

            FbCommand checkUniqueCommand = new FbCommand(command, fbConnect, transaction);
            checkUniqueCommand.Parameters.Add("tabNum", FbDbType.VarChar);
            checkUniqueCommand.Parameters["tabNum"].Value = tabNum;

            try
            {
                FbDataReader reader = checkUniqueCommand.ExecuteReader();
                reader.Read();
                countRow = reader.GetInt32(0);
            }
            catch(FbException ex)
            {
                Logger.PrintLog(ex.Message);
                transaction.Rollback();
                throw;
            }

            return (countRow != 0) ? false : true;
        }
    }
}
