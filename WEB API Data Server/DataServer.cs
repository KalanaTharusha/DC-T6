using DataLibrary;
using System;
using System.IO;
using System.ServiceModel;

namespace WEB_API_Data_Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class DataServer : IDataServer
    {
        Database database;

        public DataServer()
        {
            database = new Database();
        }

        public int GetNumEntries()
        {
            return database.GetNumRecords();
        }

        public void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out string fName, out string lName, out string bitmapString)
        {
            try
            {
                acctNo = database.GetAcctNoByIndex(index);
                pin = database.GetPINByIndex(index);
                bal = database.GetBalanceByIndex(index);
                fName = database.GetFirstNameByIndex(index);
                lName = database.GetLastNameByIndex(index);

                // convert bitmap image into base64 string
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    database.GetBitmapByIndex(index).Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imageBytes = memoryStream.ToArray();

                    bitmapString = Convert.ToBase64String(imageBytes);
                }
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
