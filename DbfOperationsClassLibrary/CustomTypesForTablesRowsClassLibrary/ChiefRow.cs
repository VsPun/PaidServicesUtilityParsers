using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace CustomTypesForTablesRowsClassLibrary
{
    public class ChiefRow
    {
        private string chiefName;
        public string ChiefName { get { return chiefName; } }

        private string tabNum;
        public string TabNum { get { return tabNum; } }

        private string nGrup;
        public string NGrup { get { return nGrup; } }

        private double salaryProcent;
        public double SalaryProcent { get { return salaryProcent; } }

        public ChiefRow(DataRow dataRow)
        {
            nGrup = dataRow[0].ToString().Trim();
            tabNum = dataRow[1].ToString().Trim();
            chiefName = dataRow[2].ToString().Trim();
            chiefName = Regex.Replace(chiefName, @"\s+", " ");
            salaryProcent = Convert.ToDouble(dataRow[3].ToString());
        }
    }
}
