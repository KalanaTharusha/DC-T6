using API_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Database
    {
        readonly List<DataIntermed> dataList;

        public Database()
        {
            dataList = new List<DataIntermed>();
            DataGenerator databaseGenerator = new DataGenerator();

            for (int i = 0; i < 1000; i++)
            {
                DataIntermed data = new DataIntermed();
                databaseGenerator.GetNextAccount(out uint pin, out uint acctNo, out string firstName, out string lastName, out int balance, out string bitmap);
                data.AcctNo = acctNo;
                data.FirstName = firstName;
                data.LastName = lastName;
                data.Balance = balance;
                data.Pin = pin;
                data.Bitmap = bitmap;

                dataList.Add(data);
            }

        }

        public uint GetAcctNoByIndex(int index)
        {
            try
            {
                return dataList[index].AcctNo;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }
        public uint GetPINByIndex(int index)
        {
            try
            {
                return dataList[index].Pin;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }
        public string GetFirstNameByIndex(int index)
        {
            try
            {
                return dataList[index].FirstName;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }
        public string GetLastNameByIndex(int index)
        {
            try
            {
                return dataList[index].LastName;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }
        public int GetBalanceByIndex(int index)
        {
            try
            {
                return dataList[index].Balance;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }
        public string GetBitmapByIndex(int index)
        {
            try
            {
                return dataList[index].Bitmap;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }
        
        public List<DataIntermed> GetAll()
        {
            return dataList;
        }
        public int GetNumRecords()
        {
            return dataList.Count;
        }
    }
}
