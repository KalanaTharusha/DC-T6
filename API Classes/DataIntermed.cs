using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Classes
{
    public class DataIntermed
    {
        public uint AcctNo { get; set; }
        public uint Pin { get; set; }
        public int Balance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bitmap { get; set; }

        //public DataIntermed(uint pin, uint acctNo, string firstName, string lastName, int balance, string bitmap)
        //{
        //    this.pin = pin;
        //    this.acctNo = acctNo;
        //    this.firstName = firstName;
        //    this.lastName = lastName;
        //    this.balance = balance;
        //    this.bitmap = bitmap;
        //}
    }

}
