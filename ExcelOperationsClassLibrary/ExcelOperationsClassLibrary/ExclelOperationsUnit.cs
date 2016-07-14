using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using System.IO;
using System.Data;

namespace ExcelOperationsClassLibrary
{
    public class ExcelOperationsUnit
    {
        #region константы для номеров столбцов в исходном файле
        private const int fullNameColumn = 0;
        private const int tabNumColumn = 1;
        private const int profCatColumn = 3;
        private const int addInformationColumn = 2;
        #endregion

        DataSet fileData;

        public ExcelOperationsUnit(string filePath)
        {
            using (FileStream readerStream = File.Open(filePath, FileMode.Open))
            {
                try
                {
                    IExcelDataReader excelReader;
                    if(filePath.Contains(".xlsx"))
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(readerStream);
                    }
                    else if(filePath.Contains(".xls"))
                    {
                        excelReader = ExcelReaderFactory.CreateBinaryReader(readerStream);
                    }
                    else
                    {
                        throw new ArgumentException("Должен быть указан путь к xlsx/xls файлу", "filePath");
                    }

                    fileData = excelReader.AsDataSet();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        //метод, возвращающий итератор для получения записей о работниках по одному за раз
        public IEnumerable<Dictionary<string, object>> WorkersList()
        {
            foreach (DataRow dataRow in fileData.Tables[0].Rows)
            {
                //проверка на конец DataSet-а, что-бы не попала пустая строка
                if (dataRow[fullNameColumn].ToString() == "") yield break;

                Dictionary<string, object> worker = ParseString(dataRow);
                yield return worker;
            }
        }

        //парсинг строки DataSet-а в словарь, представляющий поля для одного работника
        private Dictionary<string, object> ParseString(DataRow dataRow)
        {
            Dictionary<string, object> worker = new Dictionary<string, object>();

            ParseFullName(dataRow, worker);
            worker["TabNum"] = ParseTabNum(dataRow);
            worker["ProfCat"] = ParseProfCategory(dataRow);
            worker["AddInformation"] = ParseAddInformation(dataRow);

            return worker;
        }

        //разбивает поле с полным именем на отдельные строки
        private void ParseFullName(DataRow dataRow, Dictionary<string, object> worker)
        {
            string[] nameList = dataRow[fullNameColumn].ToString().Split(' ');

            worker["FirstName"] = nameList[1];
            worker["LastName"] = nameList[0];

            //случай отсутствия отчества
            try
            {
                worker["MiddleName"] = nameList[2];
            }
            catch (IndexOutOfRangeException)
            {
                worker["MiddleName"] = "";
            }
        }

        private int ParseProfCategory(DataRow dataRow)
        {
            int profCat = 0;

            switch (dataRow[profCatColumn].ToString())
            {
                case "Прочий":
                case "Прочий-Совместители":
                    profCat = 4;
                    break;
                case "Врачи":
                case "Врачи-Совместители":
                    profCat = 1;
                    break;
                case "Младший мед.персонал":
                case "Младший мед.персонал-Совместители":
                    profCat = 3;
                    break;
                case "Средний мед.персонал":
                case "Средний мед.персонал-Совместители":
                    profCat = 2;
                    break;
                default:
                    throw new ArgumentException("Файл содержит неизвестную врачебную категорию", "dataRow.ProfCatColumn");
            }

            return profCat;
        }

        private string ParseTabNum(DataRow dataRow)
        {
            return dataRow[tabNumColumn].ToString();
        }

        private string ParseAddInformation(DataRow dataRow)
        {
            return (dataRow[addInformationColumn].ToString() != "") ? dataRow[addInformationColumn].ToString() : " ";
        }

        //возвращает количество строк в прочитанном из файла наборе данных
        public int GetSize()
        {
            return fileData.Tables[0].Rows.Count;
        }
    }
}
