using API_Classes;
using DataLibrary;

namespace WEB_API_DataServer.Models
{
    public class DataModel
    {
        private Database _database;
        public DataModel()
        {
            _database = new Database();
        }

        public int GetNumEntries()
        {
            return _database.GetNumRecords();
        }

        public DataIntermed GetValuesForEntry(int id)
        {
            DataIntermed data = new DataIntermed();
            data.AcctNo = _database.GetAcctNoByIndex(id);
            data.FirstName = _database.GetFirstNameByIndex(id);
            data.LastName = _database.GetLastNameByIndex(id);
            data.Balance = _database.GetBalanceByIndex(id);
            data.Pin = _database.GetPINByIndex(id);
            data.Bitmap = _database.GetBitmapByIndex(id);

            return data;
        }

        public DataIntermed Search(string lastName)
        {

            int numOfEntries = _database.GetNumRecords();

            for (int i = 0; i < numOfEntries; i++)
            {
                string currLName = GetValuesForEntry(i).LastName;
                if (currLName.ToLower() == lastName.ToLower())
                {
                    //Thread.Sleep(2000);
                    return GetValuesForEntry(i);

                }
            }

            return null;
        }

        public List<DataIntermed> GetAll()
        {

            List<DataIntermed> dataList = _database.GetAll();

            return dataList;
        }
    }
}
