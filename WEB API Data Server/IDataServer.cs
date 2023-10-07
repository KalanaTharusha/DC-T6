using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WEB_API_Data_Server
{
    [ServiceContract]
    internal interface IDataServer
    {
        [OperationContract]
        int GetNumEntries();

        [OperationContract]
        [FaultContract(typeof(IndexFault))]
        void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out string fName, out string lName, out String bitmapString);
    }
}
