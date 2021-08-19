using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpJSONServer
{
    public class ServerListtener 
    {
        public static void ShowRequestData(HttpListenerRequest request)
        {
            try
            {
                if (!request.HasEntityBody)
                {
                    Console.WriteLine("No client data was send with request");
                    return;
                }
                System.IO.Stream body = request.InputStream;
                System.Text.Encoding encoding = request.ContentEncoding;
                System.IO.StreamReader reader = new System.IO.StreamReader(body,System.Text.Encoding.UTF8);
                if (request.ContentType != null)
                {
                    Console.WriteLine("Client data content type {0}",request.ContentType);
                }
                    Console.WriteLine("Client data content length {0}",request.ContentLength64);

                    Console.WriteLine("Start of client data.");
                //Conver the data to a string and display it on console.
                //string s = reader.ReadToEnd();
                while (!reader.EndOfStream) 
                {
                    string line = reader.ReadLine();
                    string[] splitLine = line.Split(',');
                    Console.WriteLine("{0}",string.Join("\n",splitLine));
                    //File.AppendAllText(@"Text.txt", string.Join("\n",splitLine)); 
                    //Console.WriteLine(line);
                }
                //Console.WriteLine(s);
                Console.WriteLine("End of client data");
                body.Close();
                reader.Close();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine(e.ErrorCode.ToString());
                //Console.WriteLine(e.NativeErrorCode.ToString());
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Source);
                Exception w = e.GetBaseException();
                Console.WriteLine(w.Message);
            }
        }

        // This example requires the System and System.Net namespaces.
        public static void SimpleListenerExample(string prefixes) 
        {
            if (!HttpListener.IsSupported) 
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            //URI prefixes are required
            //for example "http://contoso.com::8080/index"
            if (prefixes == null)
                throw new ArgumentException("prefixes");

            //Create a listener.
            HttpListener listener = new HttpListener();
            //Add the prefixes.
            //foreach (string s in prefixes) 
            //{
            listener.Prefixes.Add(prefixes);
            //}
            while (true) 
            {
                listener.Start();
                Console.WriteLine(prefixes);
                Console.WriteLine("Listening...");
                //Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();

                HttpListenerRequest request = context.Request;
                //Console.Clear();
                Console.WriteLine();
                Console.WriteLine(prefixes + " GET Request");
                ShowRequestData(request);

                //Obtain a response object.
                HttpListenerResponse response = context.Response;
                response.StatusCode = (int)HttpStatusCode.OK;
                response.ContentType = "application/json";
                string jsonString = System.IO.File.ReadAllText(@".\JFILE\WriteText.txt");//"{\"audit-\":\"0000\"}";
                response.StatusDescription = "{}";
                //Construct a response.
                string responseString = jsonString;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                //Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0,buffer.Length);
                //You must close the output stream.
                output.Close();

                listener.Stop();
            }
        }
        public static async void POStAsync(string url)
        {

            //var request = (HttpWebRequest)WebRequest.Create(url);

            //var postData = "username=" + Uri.EscapeDataString("myUser");
            //postData += "&password=" + Uri.EscapeDataString("myPassword");
            //var data = System.Text.Encoding.UTF8.GetBytes(postData);

            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = data.Length;

            //using (var stream = request.GetRequestStream())
            //{
            //    stream.Write(data, 0, data.Length);
            //}

            //var response = (HttpWebResponse)request.GetResponse();
            //private static readonly HttpClient client = new HttpClient();
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "username", "myUser" },
                { "password", "myPassword" }
            };
            var data2 = new FormUrlEncodedContent(values);
            var response2 = await client.PostAsync(url, data2);
            string result = response2.Content.ReadAsStringAsync().Result;
            Console.WriteLine(response2);
            Console.WriteLine(result);
        }
        public static void readFile()
        {
            // Example #1
            // Read the file as one string.
            string text = System.IO.File.ReadAllText(@".\JFILE\WriteText.txt");

            // Display the file contents to the console. Variable text is a string.
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(@".\JFILE\WriteLines2.txt");

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            /*
            //Write to console 
            Console.WriteLine("Welcom to C#");
            string[] strUserName = new string[1] { "http://*:8800/Pay"};
            Console.WriteLine("Listening to the: {0}",strUserName[0]);
            SimpleListenerExample(strUserName[0]);
            */
            //ThreadMethodをスレッドプールで実行できるように
            //WaitCallbackデリゲートを作成
            WaitCallback waitCallback = new WaitCallback(ThreadListener);

            //スレッドプールに登録
            ThreadPool.QueueUserWorkItem(waitCallback, "http://*:65535/UAPI/");
            ThreadPool.QueueUserWorkItem(waitCallback, "http://*:8800//UAPI/");

            Console.ReadLine();
        }
        private static void ThreadListener(object state) 
        {
            //SimpleListenerExample(state.ToString());
        }
    }
}
