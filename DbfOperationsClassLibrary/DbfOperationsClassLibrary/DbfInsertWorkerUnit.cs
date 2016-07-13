using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace DbfOperationsClassLibrary
{
    class DbfInsertWorkerUnit : DbfOperationsUnit
    {
        //поля для хранения полей для вставки, полученных из принятого словаря
        private string firstName;
        private string middleName;
        private string lastName;
        private string tabNum;
        private int profCat;
        private string addInformation;

        public DbfInsertWorkerUnit(string path) : base(path)
        {
        }

        protected override void ParsingDictionary(Dictionary<string, object> dataForInsert)
        {
            try
            {
                firstName = (string)dataForInsert["FirstName"];
                middleName = (string)dataForInsert["MiddleName"];
                lastName = (string)dataForInsert["LastName"];
                tabNum = (string)dataForInsert["TabNum"];
                profCat = (int)dataForInsert["ProfCat"];
                addInformation = (string)dataForInsert["AddInformation"];
            }
            catch(Exception ex)
            {
                Logger.PrintLog(ex.Message);
                throw;
            }
        }

        protected override void DoInsert()
        {
            int personID;

            if (CheckExistRecordInTableByTabNum(tabNum, "WORKER"))
            {
                personID = InsertRecordIntoPersonTable();
                InsertRecordIntoWorkerTable(personID);
            }
            else
            {
                UpdateRecordInWorkerTable();
            }
        }
        
        //возвращает сгенерированный при вставке ID записи
        private int InsertRecordIntoPersonTable()
        {
            int idRecord = 0;

            string command = "INSERT INTO PERSON(firstname, middlename, lastname) VALUES(?, ?, ?)"
                + " RETURNING ID";

            FbCommand insertPersonCommand = new FbCommand(command, fbConnect, transaction);

            insertPersonCommand.Parameters.Add("fName", FbDbType.VarChar);
            insertPersonCommand.Parameters["fName"].Value = firstName;

            insertPersonCommand.Parameters.Add("mName", FbDbType.VarChar);
            insertPersonCommand.Parameters["mName"].Value = middleName;

            insertPersonCommand.Parameters.Add("lName", FbDbType.VarChar);
            insertPersonCommand.Parameters["lName"].Value = lastName;

            //исходящий параметр запроса для получения сгенерированного ID для вставленной записи
            insertPersonCommand.Parameters.Add("ID", FbDbType.Integer).Direction = ParameterDirection.Output;

            try
            {
                insertPersonCommand.ExecuteNonQuery();
                idRecord = int.Parse(insertPersonCommand.Parameters["ID"].Value.ToString());
            }
            catch(Exception ex)
            {
                Logger.PrintLog(ex.Message);
                transaction.Rollback();
                throw;
            }

            return idRecord;
        }

        //вставка записи в таблицу WORKER 
        private void InsertRecordIntoWorkerTable(int personId)
        {
            string insertWorker = "INSERT INTO WORKER(tab_num, person_id, prof_category_id) " +
                "VALUES(?, ?, ?)";

            FbCommand insertWorkerCommand = new FbCommand(insertWorker, fbConnect, transaction);

            insertWorkerCommand.Parameters.Add("tabNum", FbDbType.VarChar);
            insertWorkerCommand.Parameters["tabNum"].Value = tabNum;

            insertWorkerCommand.Parameters.Add("personID", FbDbType.Integer);
            insertWorkerCommand.Parameters["personID"].Value = personId;

            insertWorkerCommand.Parameters.Add("profCat", FbDbType.Integer);
            insertWorkerCommand.Parameters["profCat"].Value = profCat;


            try
            {
                insertWorkerCommand.ExecuteNonQuery();
            }
            catch (FbException ex)
            {
                Logger.PrintLog(ex.Message);
                transaction.Rollback();
                throw;
            }
        }

        //обновление старой записи новой информацией, если такая уже существует
        private void UpdateRecordInWorkerTable()
        {
            string command = "UPDATE WORKER SET ADD_INFO = ? WHERE TAB_NUM = ?";

            FbCommand updateWorkerCommand = new FbCommand(command, fbConnect, transaction);

            updateWorkerCommand.Parameters.Add("info", FbDbType.VarChar);
            updateWorkerCommand.Parameters["info"].Value = addInformation;

            updateWorkerCommand.Parameters.Add("tabNum", FbDbType.VarChar);
            updateWorkerCommand.Parameters["tabNum"].Value = tabNum;

            try
            {
                updateWorkerCommand.ExecuteNonQuery();
            }
            catch(FbException ex)
            {
                Logger.PrintLog(ex.Message);
                transaction.Rollback();
                throw;
            }
        }
    }
}
