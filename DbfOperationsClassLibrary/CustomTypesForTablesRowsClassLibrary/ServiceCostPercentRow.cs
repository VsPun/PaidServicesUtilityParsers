using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CustomTypesForTablesRowsClassLibrary
{
    public class ServiceCostPercentRow
    {
        private string serviceCode;
        public string ServiceCode { get { return serviceCode; } }

        private double prDr;
        public double PrDr { get { return prDr; } }

        private double prMs;
        public double PrMs { get { return prMs; } }

        private double prSn;
        public double PrSn { get { return prSn; } }

        private double prIn;
        public double PrIn { get { return prIn; } }


        public ServiceCostPercentRow(DataRow dataRow)
        {
            serviceCode = dataRow["nusl"].ToString().Trim();
            try
            {
                prDr = Convert.ToDouble(dataRow["prdr"].ToString());
            }
            catch (System.FormatException)
            {
                prDr = 0.0;
            }

            try
            {
                prMs = Convert.ToDouble(dataRow["prms"].ToString());
            }
            catch (System.FormatException)
            {
                prMs = 0.0;
            }

            try
            {
                prSn = Convert.ToDouble(dataRow["prsn"].ToString());
            }
            catch (System.FormatException)
            {
                prSn = 0.0;
            }

            try
            {
                prIn = Convert.ToDouble(dataRow["prin"].ToString());
            }
            catch (System.FormatException)
            {
                prIn = 0.0;
            }
        }
    }
}
