using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using DataServerInterface;

namespace DataServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class DataServer : IDataServer
    {
        private Database _database;

        public DataServer()
        {
            _database = new Database();
        }

        public int GetNumEntries()
        {
            return _database.GetNumRecords();
        }

        public void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out string fName, out string lName, out string bitmap)
        {
            try
            {
                acctNo = _database.GetAcctNoByIndex(index);
                pin = _database.GetPINByIndex(index);
                bal = _database.GetBalanceByIndex(index);
                fName = _database.GetFirstNameByIndex(index);
                lName = _database.GetLastNameByIndex(index);
                bitmap = _database.GetBitmapByIndex(index);
            }
            catch (Exception)
            {
                IndexFault indexFault = new IndexFault();
                indexFault.Message = "Index Out of Bound";
                throw new FaultException<IndexFault>(indexFault, new FaultReason("Index Out of Bound"));
            }
        }
    }
}
