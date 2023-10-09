using API_Classes;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public delegate DataIntermed SearchDel(string term);

    public partial class MainWindow : Window
    {
        private SearchDel searchDel;
        private RestClient restClient;

        public MainWindow()
        {
            InitializeComponent();

            restClient = new RestClient("http://localhost:5022");
            RestRequest restRequest = new RestRequest("/getvalues/count", Method.Get);
            RestResponse restResponse = restClient.Execute(restRequest);

            ItemCountBlock.Text = "Total Items: " + restResponse.Content;
        }

        private void goBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            string fName = "", lName = "";
            int bal = 0;
            uint acct = 0, pin = 0;
            String bitmapString = null;
            Bitmap bitmap = null;

            clearData();

            searchBox.Text = string.Empty;

            try
            {
                index = Int32.Parse(indexBox.Text);

                RestRequest restRequest = new RestRequest("getvalues/detail?id={i}", Method.Get);
                restRequest.AddUrlSegment("i", index);
                RestResponse restResponse = restClient.Execute(restRequest);

                DataIntermed dataIntermed = JsonConvert.DeserializeObject<DataIntermed>(restResponse.Content);

                UpdateGUI(dataIntermed);

            }
            //catch (FaultException<IndexFault> ex)
            //{
            //    MessageBox.Show(ex.Detail.Message);
            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();

            this.Dispatcher.Invoke((Action)(() =>
            {
                searchBox.IsReadOnly = true;
                indexBox.Text = string.Empty;
                indexBox.IsReadOnly = true;
                SearchBtn.IsEnabled = false;
                goBtn.IsEnabled = false;
                ProgressBar1.IsIndeterminate = true;

            }));

            searchDel = Search;
            AsyncCallback callback;

            callback = this.OnSearchCompletion;

            IAsyncResult result = searchDel.BeginInvoke(searchBox.Text, callback, null);

        }

        private DataIntermed Search(String term)
        {
            string fName = "", lName = "";
            int bal = 0;
            uint acct = 0, pin = 0;
            String bitmapString = null;

            try
            {

                SearchData mySearch = new SearchData();
                mySearch.SearchStr = term;

                RestRequest request = new RestRequest("search/", Method.Post);
                request.AddJsonBody(mySearch);

                RestResponse response = restClient.Post(request);
                DataIntermed dataIntermed = JsonConvert.DeserializeObject<DataIntermed>(response.Content);

                if (!dataIntermed.FirstName.Equals(""))
                {
                    DataIntermed ds = new DataIntermed();
                    ds.AcctNo = acct;
                    ds.Pin = pin;
                    ds.Balance = bal;
                    ds.FirstName = fName;
                    ds.LastName = lName;
                    ds.Bitmap = bitmapString;

                    return dataIntermed;

                }

            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    ProgressBar1.IsIndeterminate = false;
                }));

                MessageBox.Show(ex.Message);
            }

            return null;
        }

        private void OnSearchCompletion(IAsyncResult asyncResult)
        {
            DataIntermed iDataStuct = null;
            SearchDel searchDel = null;
            AsyncResult asyncObj = (AsyncResult)asyncResult;

            if (asyncObj.EndInvokeCalled == false)
            {
                searchDel = (SearchDel)asyncObj.AsyncDelegate;
                iDataStuct = searchDel.EndInvoke(asyncObj);
                if (iDataStuct != null)
                {
                    UpdateGUI(iDataStuct);
                }

                this.Dispatcher.Invoke(new Action(() =>
                {
                    searchBox.IsReadOnly = false;
                    indexBox.IsReadOnly = false;
                    SearchBtn.IsEnabled = true;
                    goBtn.IsEnabled = true;
                    ProgressBar1.IsIndeterminate = false;
                }));
            }

            asyncObj.AsyncWaitHandle.Close();


        }

        private void UpdateGUI(DataIntermed ds)
        {
            fNameBox.Dispatcher.Invoke(new Action(() => { fNameBox.Text = ds.FirstName; }));
            lNameBox.Dispatcher.Invoke(new Action(() => { lNameBox.Text = ds.LastName; }));
            accNoBox.Dispatcher.Invoke(new Action(() => { accNoBox.Text = ds.AcctNo.ToString(); }));
            pinBox.Dispatcher.Invoke(new Action(() => { pinBox.Text = ds.Pin.ToString("D4"); }));
            balBox.Dispatcher.Invoke(new Action(() => { balBox.Text = ds.Balance.ToString("C"); }));

            profilePic.Dispatcher.Invoke(new Action(() =>
            {
                try
                {

                    byte[] imageBytes = Convert.FromBase64String(ds.Bitmap);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Bitmap bitmap = new Bitmap(ms);
                        BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        profilePic.Source = bitmapSource;
                    }
                }
                catch
                {
                    throw new Exception("Error while decoding the bitmap");
                }
            }));
        }

        private void clearData()
        {
            this.Dispatcher.Invoke(() =>
            {
                fNameBox.Text = string.Empty;
                lNameBox.Text = string.Empty;
                accNoBox.Text = string.Empty;
                pinBox.Text = string.Empty;
                balBox.Text = string.Empty;
                profilePic.Source = null;
            });
        }
    }
}
