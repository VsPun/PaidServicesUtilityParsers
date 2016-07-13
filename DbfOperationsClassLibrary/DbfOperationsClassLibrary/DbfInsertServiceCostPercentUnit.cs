using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace DbfOperationsClassLibrary
{
    class DbfInsertServiceCostPercentUnit : DbfOperationsUnit
    {
        //перечисление профессиональных категорий
        enum Categories
        {
            Doctor = 1,
            Nurse = 2,
            Orderly = 3,
            Engineer = 4
        };

        //поля для хранения полей для вставки, полученных из принятого словаря
        private string serviceCode;
        private int cashDeskId;
        private double prDr, prMs, prSn, prIn;


        public DbfInsertServiceCostPercentUnit(string path) : base(path)
        {
        }

        protected override void ParsingDictionary(Dictionary<string, object> dataForInsert)
        {
            try
            {
                serviceCode = (string)dataForInsert["ServiceCode"];
                prDr = (double)dataForInsert["PrDr"];
                prMs = (double)dataForInsert["PrMs"];
                prSn = (double)dataForInsert["PrSn"];
                prIn = (double)dataForInsert["PrIn"];
            }
            catch (Exception ex)
            {
                Logger.PrintLog(ex.Message);
                throw;
            }
        }

        protected override void DoInsert()
        {
            int serviceCostId;

            serviceCostId = FindRecordIdInTableSeviceCostByServiceCode();

            if (prDr != 0)
                InsertRecordIntoServiceCostPercentTable(serviceCostId, cashDeskId, prDr, (int)Categories.Doctor);
            if (prMs != 0)
                InsertRecordIntoServiceCostPercentTable(serviceCostId, cashDeskId, prMs, (int)Categories.Nurse);
            if (prSn != 0)
                InsertRecordIntoServiceCostPercentTable(serviceCostId, cashDeskId, prSn, (int)Categories.Orderly);
            if (prIn != 0)
                InsertRecordIntoServiceCostPercentTable(serviceCostId, cashDeskId, prIn, (int)Categories.Engineer);
        }

        //поиск ID записи в таблице ServiceCost, соответствуюшей коду услуги
        private int FindRecordIdInTableSeviceCostByServiceCode()
        {
            int serviceCostId = 0;

            string command = "SELECT ID FROM SERVICE_COST WHERE SERVICE_ID = " +
                 "(SELECT ID FROM SERVICE WHERE CODE = ?)";

            FbCommand findServiceCostIdCommand = new FbCommand(command, fbConnect, transaction);
            findServiceCostIdCommand.Parameters.Add("serviceCode", FbDbType.VarChar);
            findServiceCostIdCommand.Parameters["serviceCode"].Value = serviceCode;

            try
            {
                FbDataReader reader = findServiceCostIdCommand.ExecuteReader();
                reader.Read();
                serviceCostId = reader.GetInt32(0);
            }
            catch (Exception ex)
            {
                Logger.PrintLog(ex.Message);
                transaction.Rollback();
                throw;
            }

            return serviceCostId;
        }

        private void InsertRecordIntoServiceCostPercentTable(int serviceCostId, int cashDeskId, double percent, int profCategoryId)
        {
            string command = "INSERT INTO SERVICE_COST_PERCENT(SERVICE_COST_ID, CASH_DESK_ID, SALARY_PERCENT, PROF_CATEGORY_ID) " +
                "VALUES (?, ?, ?, ?)";

            FbCommand insertServiceCostPercentCommand = new FbCommand(command, fbConnect, transaction);

            insertServiceCostPercentCommand.Parameters.Add("serviceCostId", FbDbType.Integer);
            insertServiceCostPercentCommand.Parameters["serviceCostId"].Value = serviceCostId;

            insertServiceCostPercentCommand.Parameters.Add("cashDeskId", FbDbType.Integer);
            insertServiceCostPercentCommand.Parameters["cashDeskId"].Value = cashDeskId;

            insertServiceCostPercentCommand.Parameters.Add("salaryPercent", FbDbType.Decimal);
            insertServiceCostPercentCommand.Parameters["salaryPercent"].Value = percent;

            insertServiceCostPercentCommand.Parameters.Add("profCategoryId", FbDbType.Integer);
            insertServiceCostPercentCommand.Parameters["profCategoryId"].Value = profCategoryId;


            try
            {
                insertServiceCostPercentCommand.ExecuteNonQuery();
            }
            catch (FbException ex)
            {
                Logger.PrintLog(ex.Message);
                transaction.Rollback();
                throw;
            }
        }
    }
}
