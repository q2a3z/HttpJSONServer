using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpJSONServer
{
    public static class ServerConst
    {
        /// <summary>
        /// アプリケーションモード(1:販売員)
        /// </summary>
        public const int APP_MODE = 1;

        /// <summary>
        /// API
        /// </summary>
        public const string LOCAL_IP         = "http://*"+LOCAL_PORT;
        public const string LOCAL_PORT       = ":80";
        public const string API_VERSIONCHECK = "/API/"+ JFILE_VERSIONCHECK;


        /// <summary>
        /// RESPONSE JSON FILE
        /// </summary>
        public const string FILE_TYPE          = ".json";
        public const string JFILE_PATH         = @"..\..\JFILE\";
        public const string JFILE_VERSIONCHECK = "VersionCheck";

    }
}
