using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace HttpJSONServer
{
    [DataContract] // ←重要
    class SampleData
    {
        private string name = "Default"; // field
        [DataMember] // ←重要
        public string Name   // property
        {
            get { return name; }   // get method
            set { name = value; }  // set method
        }

        [DataMember] // ←重要
        public string age { get; set; }
    }
    [DataContract]
    class Request
    {
        [IgnoreDataMember]
        public string Result;
        [IgnoreDataMember]
        public long Code;
    };
    [DataContract]
    class Response
    {
		[IgnoreDataMember]
        public string Result;
		[IgnoreDataMember]
        public long Code;
    };
    [DataContract] 
    class ApplicationSetting
    {
        [DataMember] 
        public string CompanyCode { get; set; }

        [DataMember] 
        public string AccessKey { get; set; }

        [DataMember] 
        public string MobilePOSAPIUrl { get; set; }

        [DataMember] 
        public string MobilePOSAPITimeout { get; set; }
    }

    [DataContract] 
    class VersionCheck_Request
    {
        [DataMember(Name = "AppMode")] 
        public string AppMode { get; set; }

        [DataMember] 
        public string AppVersion { get; set; }

        [DataMember] 
        public string AppVersionUpdateDate { get; set; }
    }

    public static class JsonPhase
    {
        /// <summary>
        /// JSONからオブジェクトへ変換します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">オブジェクトへ変換するJSON</param>
        /// <returns>オブジェクト</returns>
        public static T ToObject<T>(string json)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }
        /// <summary>
        /// オブジェクトからJSONへ変換します
        /// </summary>
        /// <param name="obj">JSONへ変換するオブジェクト</param>
        /// <returns>JSON</returns>
        public static string ToJson(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(obj.GetType());
                serializer.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
