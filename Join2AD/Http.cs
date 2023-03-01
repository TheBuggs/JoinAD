using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Join2AD
{
    class Http
    {
        private string newName;
        private string macAddress;
        private string uuid;
        private string user;
        private string key;
        private string ip;
        private string idDB;
        private string urlCreate;
        private string urlPush;
        private string urlRemove;

        public Http(string newName, string username)
        {

            this.ip = this.GetLocalIPAddress();

            if (this.ip != String.Empty)
            {
                this.macAddress = this.GetLocalMACAddress(this.ip);
            }

            /// <summary>
            /// Inicialize varibles. Hardcoded... Must be fix!
            /// </summary>
            this.newName = newName;
            this.uuid = (this.GetSystemUUID()).Trim();
            this.user = username;
            this.key = Program.ApiKey;
            this.idDB = String.Empty;
            this.urlCreate = Program.URL + "/script-joinad-computer-log";
            this.urlPush = Program.URL + "/script-joinad-computer-log-confirm";
            this.urlRemove = Program.URL + "/script-joinad-computer-log-remove";
        }

        public string IdDB
        {
            set { idDB = value; }
            get { return newName; }
        }
        public string NewName
        {
            get { return newName; }
        }

        public string MacAddress
        {
            get { return macAddress; }
        }

        public string Uuid
        {
            get { return uuid; }
        }

        public string User
        {
            get { return user; }
        }

        public string Ip
        {
            get { return ip; }
        }

        public void removeRecordJSON() {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(this.urlRemove);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 5000;
            httpWebRequest.ReadWriteTimeout = 5000;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                /// <summary>
                /// Send JSON data with ID and token. Token must be fix!
                /// </summary>
                string id = this.idDB;
                string json = "{\"key\":\"" + (this.key).ToString() + "\"," +
                                "\"id\":\"" + (this.idDB).ToString() + "\"}";
                streamWriter.Write(json);
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return;
                }
            }
            catch (WebException webEx)
            {
                webEx.Response.Close();
            }

            return;
        }
        public void sendFinalJSON() {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(this.urlPush);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 5000;
            httpWebRequest.ReadWriteTimeout = 5000;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                /// <summary>
                /// Send JSON data with ID, token and process state. Must be FIX!!!
                /// </summary>
                int successed = 0;
                string id = this.idDB;
                string json = "{\"key\":\"" + (this.key).ToString() + "\"," +
                                "\"id\":\"" + (this.idDB).ToString() + "\"," +
                                "\"fin\":\"" + (successed).ToString() + "\"}";
                streamWriter.Write(json);
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return;
                }
            }
            catch (WebException webEx)
            {
                webEx.Response.Close();
            }

            return;
        }
        public Dictionary<string, string> sendJSON()
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(this.urlCreate);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 5000;
            httpWebRequest.ReadWriteTimeout = 5000;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                /// <summary>
                /// Send JSON data with ID and token. Token must be fix!!!
                /// </summary>
                string json = "{\"key\":\"" + (this.key).ToString() + "\"," +
                                "\"new\":\"" + this.newName + "\"," +
                                "\"mac\":\"" + this.macAddress + "\"," +
                                "\"uuid\":\"" + this.uuid + "\"," +
                                "\"user\":\"" + this.user + "\"}";
                streamWriter.Write(json);
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return String2Dictionary(result.ToString());
                }
            }
            catch (WebException webEx)
            {
                webEx.Response.Close();
            }
            return null;
        }

        public Dictionary<string, string> String2Dictionary(string str) {
            
            Dictionary<string, string> dict = new Dictionary<string, string>();
            // Must be fix
            str = str.Replace('{', ' ');
            str = str.Replace('}', ' ');
            string[] words = str.Split(',');
           
            foreach (string row in words)
            {
                string[] word = row.Split(':');
                if (word.Length == 2)
                {
                    dict.Add(word[0].ToString().Trim(), word[1].ToString().Trim());
                }
            }

            if (!dict.TryGetValue("\"id\"", out (this.idDB))){}
            return dict;
        }

        private string GetLocalMACAddress(string ipAddress)
        {
            string macAddresses = string.Empty;

            var query = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n =>
                    n.OperationalStatus == OperationalStatus.Up &&  // only grabbing what's online
                    n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(_ => new
                {
                    PhysicalAddress = _.GetPhysicalAddress(),
                    IPProperties = _.GetIPProperties(),
                });

            var mac = query
                .Where(q => q.IPProperties.UnicastAddresses
                    .Any(ua => ua.Address.ToString() == ipAddress))
                .FirstOrDefault()
                .PhysicalAddress;
            
            return String.Join(":", mac.GetAddressBytes().Select(b => b.ToString("X2")));
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return String.Empty;
            //throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private string GetSystemUUID()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C wmic csproduct get UUID";
            
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            
            string output = process.StandardOutput.ReadToEnd();
            output = (output.Trim()).Replace("UUID", "");
            return output.Trim();
        }
    }
}
