using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace CustomTypesForTablesRowsClassLibrary
{
    public class GruppaRow
    {
        private string nGrup;
        public string NGrup { get { return nGrup; } }

        private string gruppaName;
        public string GruppaName { get { return gruppaName; } }

        public GruppaRow(DataRow dataRow)
        {
            nGrup = dataRow[0].ToString().Trim();
            gruppaName = dataRow[1].ToString().Trim();
            gruppaName = Regex.Replace(gruppaName, @"\s+", " ");
        }
    }
}
