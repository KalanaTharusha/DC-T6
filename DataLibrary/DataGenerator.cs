using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    internal class DataGenerator
    {
        private static readonly Random random = new Random();

        private string GetFirstname()
        {
            string[] firstNames = { "Emily", "John", "Logan", "Smith", "Paul", "Jack", "Lily", "Olivia", "Mark", "Ava" };
            return firstNames[random.Next(firstNames.Length)];
        }

        private string GetLastname()
        {
            string[] lastNames = { "Wilson", "Walker", "Miller", "Shelby", "Williams", "Parker", "Turner", "Phillips", "Collins", "White" };
            return lastNames[random.Next(lastNames.Length)];
        }

        private uint GetPIN()
        {
            return (uint)random.Next(10000);
        }

        private uint GetAccNo()
        {
            return (uint)random.Next(1000000000);
        }

        private int GetBalance()
        {
            return random.Next(1000000);
        }

        private string GetBitmap()
        {
            int height = 32;
            int width = 32;
            string bitmap;

            Bitmap bitmapImg = new Bitmap(height, width);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color = Color.FromArgb(
                        random.Next(256),
                        random.Next(256),
                        random.Next(256)
                        );

                    bitmapImg.SetPixel(x, y, color);
                }
            }

            // convert bitmap image into base64 string
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmapImg.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                byte[] imageBytes = memoryStream.ToArray();

                bitmap = Convert.ToBase64String(imageBytes);
            }

            return bitmap;
            //return "bitamp";
        }

        public void GetNextAccount(out uint pin, out uint acctNo, out string firstName, out string lastName, out int balance, out string bitmap)
        {
            pin = GetPIN();
            acctNo = GetAccNo();
            firstName = GetFirstname();
            lastName = GetLastname();
            balance = GetBalance();
            bitmap = GetBitmap();
        }
    }
}
