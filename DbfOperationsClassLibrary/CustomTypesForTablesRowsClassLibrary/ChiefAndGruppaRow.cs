using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CustomTypesForTablesRowsClassLibrary
{
    public class ChiefAndGruppaRow
    {
        private string chiefName;
        public string ChiefName { get { return chiefName; } }

        private string tabNum;
        public string TabNum { get { return tabNum; } }

        private string gruppaName;
        public string GruppaName { get { return gruppaName; } }

        private double salaryProcent;
        public double SalaryProcent { get { return salaryProcent; } }

        public ChiefAndGruppaRow(ChiefRow chief, GruppaRow grup)
        {
            chiefName = chief.ChiefName;
            tabNum = chief.TabNum;
            gruppaName = grup.GruppaName;
            salaryProcent = chief.SalaryProcent;
        }
    }
}
