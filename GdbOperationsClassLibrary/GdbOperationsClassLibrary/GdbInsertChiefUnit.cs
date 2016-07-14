using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace GdbOperationsClassLibrary
{
    public class GdbInsertChiefUnit : GdbOperationsUnit
    {
        //поля для хранения полей для вставки, полученных из принятого словаря
        private string chiefName;
        private string gruppaName;
        private string tabNum;
        private double salaryPercent;
        private int cashDeskId;


        public GdbInsertChiefUnit(string path) : base(path)
        {
        }

        protected override void ParsingDictionary(Dictionary<string, object> dataForInsert)
        {
            try
            {
                chiefName = (string)dataForInsert["ChiefName"];
                gruppaName = (string)dataForInsert["GruppaName"];
                tabNum = (string)dataForInsert["TabNum"];
                salaryPercent = (double)dataForInsert["SalaryPercent"];
                cashDeskId = (int)dataForInsert["CashDeskId"];
            }
            catch (Exception ex)
            {
                Logger.PrintLog(ex.Message);
                throw;
            }
        }

        protected override void DoInsert()
        {
            int chiefID, hierarchyID;

            if(CheckExistRecordInTableByTabNum(tabNum, "CHIEF"))
            {
                chiefID = InsertRecordIntoChiefTable();
            }
            else
            {
                chiefID = FindRecordIdInChiefTableByTabNum();
            }

            hierarchyID = FindRecordIdInHierarchyTableByNameAndCahDeskId();

            InsertRecordIntoChiefHierarchyTable(chiefID, hierarchyID);
        }

        //возвращает ID вставленной в таблицу записи
        private int InsertRecordIntoChiefTable()
        {
            int idRecord = 0;

            string command = "INSERT INTO CHIEF(NAME, TAB_NUM) VALUES(?, ?) RETURNING ID";

            FbCommand insertChiefCommand = new FbCommand(command, fbConnect, transaction);

            insertChiefCommand.Parameters.Add("chiefName", FbDbType.VarChar);
            insertChiefCommand.Parameters["chiefName"].Value = chiefName;

            insertChiefCommand.Parameters.Add("tabNum", FbDbType.VarChar);
            insertChiefCommand.Parameters["tabNum"].Value = tabNum;
            
            //исходящий параметр запроса для получения сгенерированного ID для вставленной записи
            insertChiefCommand.Parameters.Add("chiefId", FbDbType.Integer).Direction = ParameterDirection.Output;

            try
            {
                insertChiefCommand.ExecuteNonQuery();
                idRecord = int.Parse(insertChiefCommand.Parameters["chiefId"].Value.ToString());
            }
            catch (Exception ex)
            {
                Logger.PrintLog(ex.Message);
                transaction.Rollback();
                throw;
            }

            return idRecord;
        }

        //поиск ID существующей запси в таблице начальников
        private int FindRecordIdInChiefTableByTabNum()
        {
            int chiefId = 0;
            string command = "SELECT ID FROM CHIEF WHERE TAB_NUM = ?";

            FbCommand findChiefIdCommand = new FbCommand(command, fbConnect, transaction);
            findChiefIdCommand.Parameters.Add("tabNum", FbDbType.VarChar);
            findChiefIdCommand.Parameters["tabNum"].Value = tabNum;

            try
            {
                FbDataReader reader = findChiefIdCommand.ExecuteReader();
                reader.Read();
                chiefId = reader.GetInt32(0);
            }
            catch (Exception ex)
            {
                Logger.PrintLog(ex.Message);
                transaction.Rollback();
                throw;
            }

            return chiefId;
        }

        //поиск ID записи подразделения, соответствующего названию, и выбранной кассе
        private int FindRecordIdInHierarchyTableByNameAndCahDeskId()
        {
            int hierarchyId = 0;
            string command = "SELECT h.ID FROM HIERARCHY h WHERE h.NAME = ? AND" +
                " (SELECT cdh.CASH_DESK_ID FROM CASH_DESK_HIERARCHY cdh WHERE cdh.HIERARCHY_ID = " +
                " (SELECT FIRST 1 hr.ID FROM HIERARCHY hr WHERE hr.PARENT_ID = h.ID)) = ?";

            FbCommand findHierarchyIdCommand = new FbCommand(command, fbConnect, transaction);
            findHierarchyIdCommand.Parameters.Add("gruppaName", FbDbType.VarChar);
            findHierarchyIdCommand.Parameters["gruppaName"].Value = gruppaName;

            findHierarchyIdCommand.Parameters.Add("cashDeskId", FbDbType.Integer);
            findHierarchyIdCommand.Parameters["cashDeskId"].Value = cashDeskId;

            try
            {
                FbDataReader reader = findHierarchyIdCommand.ExecuteReader();
                reader.Read();
                hierarchyId = reader.GetInt32(0);
            }
            catch (Exception ex)
            {
                Logger.PrintLog(ex.Message);
                transaction.Rollback();
                throw;
            }

            return hierarchyId;
        }

        private void InsertRecordIntoChiefHierarchyTable(int chiefID, int hierarchyID)
        {
            string command = "INSERT INTO CHIEF_HIERARCHY(CHIEF_ID, HIERARCHY_ID, SALARY_PERCENT) VALUES(?, ?, ?)";
            FbCommand insertChiefHierarchyCommand = new FbCommand(command, fbConnect, transaction);

            insertChiefHierarchyCommand.Parameters.Add("chiefId", FbDbType.Integer);
            insertChiefHierarchyCommand.Parameters["chiefId"].Value = chiefID;

            insertChiefHierarchyCommand.Parameters.Add("hierarchyId", FbDbType.Integer);
            insertChiefHierarchyCommand.Parameters["hierarchyId"].Value = hierarchyID;

            insertChiefHierarchyCommand.Parameters.Add("salaryPercent", FbDbType.Decimal);
            insertChiefHierarchyCommand.Parameters["salaryPercent"].Value = salaryPercent;

            try
            {
                insertChiefHierarchyCommand.ExecuteNonQuery();
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
