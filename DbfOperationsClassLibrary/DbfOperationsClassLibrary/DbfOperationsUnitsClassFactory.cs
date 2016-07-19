using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbfOperationsClassLibrary
{
    public class DbfOperationsUnitsClassFactory
    {
        private string pathToDbfDirectory;

        public void Initialize(string path)
        {
            pathToDbfDirectory = path;
        }

        public DbfSelectChiefAndGruppaUnit CreateChiefAndGruppaUnit(int cashDescId)
        {
            return new DbfSelectChiefAndGruppaUnit(pathToDbfDirectory, cashDescId);
        }

        public DbfSelectServiceCostPercentUnit CreateServiceCostPercentUnit(int cashDescId)
        {
            return new DbfSelectServiceCostPercentUnit(pathToDbfDirectory, cashDescId);
        }
    }
}
