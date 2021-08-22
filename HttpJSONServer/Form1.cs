using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HttpJSONServer
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")] // この行を追加
        private static extern bool AllocConsole();                 // この行を追加  
        bool ServerState = false;
        public Form1()
        {
            InitializeComponent();
            //AllocConsole();                                        // この行を追加
        }

        private void RequestBtn_Click(object sender, EventArgs e)
        {
            //var now = DateTime.Now;
            //Console.WriteLine(now.ToString("yyyy年M月dd日（ddd）HH:mm:ss.fff"));
            //Console.WriteLine(now.ToString("ggyyyy年MM月dd日（dddd）tthh時mm分ss秒"));
            //ServerListtener.readFile();
            //ServerListtener.POStAsync("http://localhost:8800/UAPI/");
            SampleData data = new SampleData();
            //data.name = "大泉 洋";
            data.age = "44歳";
            string json = JsonPhase.ToJson(data);
            Console.WriteLine(json);
            using (StreamReader r = new StreamReader(@"..\..\JFILE\file.json"))
            {
                SampleData json2 = data;
                json2 = JsonPhase.ToObject<SampleData>(r.ReadToEnd());
                Console.WriteLine("{0}\n{1}", json2.Name, json2.age);
                //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }
        private static ManualResetEvent mre = new ManualResetEvent(false);
        private void StartBtn_Click(object sender, EventArgs e)
        { 
            // ホスト名を取得する
            string hostname = Dns.GetHostName();

            // ホスト名からIPアドレスを取得する
            IPAddress[] adrList = Dns.GetHostAddresses(hostname);
            foreach (IPAddress address in adrList)
            {
                Console.WriteLine(address.ToString());
            }
            this.label1.Text = HttpJSONServer.API.API_CALL.VersionCheck() ?"SUCCESS" : "FAILD";

        }
    }
}
