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

        public Form1()
        {
            InitializeComponent();
            AllocConsole();                                        // この行を追加
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            Console.WriteLine(now.ToString("yyyy年M月dd日（ddd）HH:mm:ss.fff"));
            Console.WriteLine(now.ToString("ggyyyy年MM月dd日（dddd）tthh時mm分ss秒"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Console.Clear();
            //Console.WriteLine("Welcom to C#");
            //string[] strUserName = new string[1] { "http://localhost:8800/Pay/" };
            //Console.WriteLine("Listening to the: {0}", strUserName[0]);
            //ServerListtener.SimpleListenerExample(strUserName[0]);
    
            //ThreadMethodをスレッドプールで実行できるように
            //WaitCallbackデリゲートを作成
            WaitCallback waitCallback = new WaitCallback(ThreadListener);

            //スレッドプールに登録
            ThreadPool.QueueUserWorkItem(waitCallback, "http://localhost:65535/UAPI/");
            ThreadPool.QueueUserWorkItem(waitCallback, "http://localhost:8800/UAPI/");

            //Console.ReadLine();
        }

        private static void ThreadListener(object state)
        {
            ServerListtener.SimpleListenerExample(state.ToString());
        }
    }
}
