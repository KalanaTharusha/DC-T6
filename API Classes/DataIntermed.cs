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
        public uint acctNo;
        public uint pin;
        public int balance;
        public string firstName;
        public string lastName;
        public Bitmap bitmap;

        public DataIntermed()
        {
            acctNo = 0;
            pin = 0;
            balance = 0;
            firstName = "";
            lastName = "";
            bitmap = null;
        }

        public DataIntermed(uint pin, uint acctNo, string firstName, string lastName, int balance, Bitmap bitmap)
        {
            this.pin = pin;
            this.acctNo = acctNo;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
            this.bitmap = bitmap;
        }
    }

}
