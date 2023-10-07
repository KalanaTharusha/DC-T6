using API_Classes;
using DataLibrary;
using DataServerInterface;
using System.Collections.Generic;
using System.ServiceModel;

namespace WEB_API_DataServer.Models
{
    public class DataModel
    {
        private Database _database;
        public DataModel() 
        {
            _database = new Database();
        }

        private void Connect()
        {
            ChannelFactory<IDataServer> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            //tcp.MaxBufferSize = 2147483647;

            string URL = "net.tcp://localhost:8000/DataService";
            foobFactory = new ChannelFactory<IDataServer>(tcp, URL);
            IDataServer foob = foobFactory.CreateChannel();
        }

        public int GetCount()
        {
            return _database.GetNumRecords();
            //Connect();
        }

        public List<DataIntermed> GetAll()
        {

            List<DataIntermed> dataList = _database.GetAll();
            //List<DataIntermed> dataList = Connect().GetValuesForEntry();

            return dataList;
        }

    }
}
