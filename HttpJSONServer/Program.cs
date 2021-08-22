using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HttpJSONServer
{
    public class FileImport
    {
        public static string readFile(string FileName)
        {
            return (System.IO.File.Exists(ServerConst.JFILE_PATH + FileName)) 
                ? System.IO.File.ReadAllText(ServerConst.JFILE_PATH + FileName) : "";
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
        }
    } 
}
