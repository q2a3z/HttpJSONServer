using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            //button1.Click += new EventHandler(button1_Click);
            //button2.Click += new EventHandler(button2_Click);
        }

        private void RequestBtn_Click(object sender, EventArgs e)
        {
            //var now = DateTime.Now;
            //Console.WriteLine(now.ToString("yyyy年M月dd日（ddd）HH:mm:ss.fff"));
            //Console.WriteLine(now.ToString("ggyyyy年MM月dd日（dddd）tthh時mm分ss秒"));
            //ServerListtener.readFile();
            ServerListtener.POStAsync("http://localhost:8800/UAPI/");
        }
        private static ManualResetEvent mre = new ManualResetEvent(false);
        private void StartBtn_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(ThreadListener);
            t.IsBackground = true;
            if (!ServerState)
            {
                StartBtn.BackColor = Color.Red;
                StartBtn.Text = "STARTING";
                //ThreadMethodをスレッドプールで実行できるように
                //WaitCallbackデリゲートを作成
                //WaitCallback waitCallback = new WaitCallback(ThreadListener);

                //スレッドプールに登録
                //ThreadPool.QueueUserWorkItem(waitCallback, "http://localhost:65535/UAPI/");
                //ThreadPool.QueueUserWorkItem(waitCallback, "http://localhost:8800/UAPI/");
                //ThreadPool.QueueUserWorkItem(p => ThreadListener("http://localhost:8800/UAPI/"));
                
                t.Start();
                ServerState = !ServerState;

            }
            else 
            {
                Console.WriteLine("Welcom to C# ABORRT");
                mre.Set();


            }

            //Console.Clear();
            //Console.WriteLine("Welcom to C#");
            //string[] strUserName = new string[1] { "http://localhost:8800/Pay/" };
            //Console.WriteLine("Listening to the: {0}", strUserName[0]);
            //ServerListtener.SimpleListenerExample(strUserName[0]);

            //Console.ReadLine();
        }

        private static void ThreadListener()
        {

            ServerListtener.SimpleListenerExample("http://localhost:8800/UAPI/", true);
        }
    }
}
