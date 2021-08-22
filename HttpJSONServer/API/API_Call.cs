using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpJSONServer.API
{

    public static class API_CALL
    {
        private static void ThreadListener(string ip, string Response)
        {
            MyHttpListener.SimpleListenerExample(ip + "/", Response);
        }

        public static bool VersionCheck() 
        {
            string ResponseJSON = FileImport.readFile(ServerConst.JFILE_VERSIONCHECK + ServerConst.FILE_TYPE);
            if (ResponseJSON == "")
                return false;
            else 
            {
                ThreadPool.QueueUserWorkItem(
                    p => ThreadListener(ServerConst.LOCAL_IP
                                      + ServerConst.API_VERSIONCHECK
                                      , ResponseJSON)
                    );
                return true;
            }
        }

    }
}
