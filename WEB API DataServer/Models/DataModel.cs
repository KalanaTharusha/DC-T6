using API_Classes;
using DataLibrary;
using System.Collections.Generic;

namespace WEB_API_DataServer.Models
{
    public class DataModel
    {
        private Database _database;
        public DataModel() 
        {
            _database = new Database();
        }

        public int GetCount()
        {
            return _database.GetNumRecords();
        }

        public List<DataIntermed> GetAll()
        {
            //return _database.GetAll();
            //DataIntermed d1 = new DataIntermed(1, 1, "hello", "hello", 1, "hello");
            //DataIntermed d2 = new DataIntermed(2, 2, "hello2", "hello2", 2, "hello2");

            List <DataIntermed> dataList = _database.GetAll();

            //DataIntermed result = new DataIntermed();
            //result.Pin = 1111;
            //result.Balance = 2423435;
            //result.AcctNo = 948587468;
            //result.FirstName = "Kalana";
            //result.LastName = "Tharusha";
            //result.Bitmap = "This should be a bitmap";

            return dataList;
        }

    }
}
