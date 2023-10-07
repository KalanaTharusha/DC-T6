using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WEB_API_Data_Server
{
    [DataContract]
    public class IndexFault
    {
        private string message;

        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
