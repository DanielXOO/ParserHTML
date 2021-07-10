using DanielXOO.ShopParser.Service;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace DanielXOO.ShopParser
{
    class OpenProvider : IDataProvider
    {
        private IService Service;
        public Uri Link { get; set; }

        public OpenProvider(string src)
        {
            Service = new ConsoleService();
            if(string.IsNullOrWhiteSpace(src))
            {
                Service.Log("Bad Link", MsgLevel.Error);
            }
            else
            {
                Link = new Uri(src);
            }
          
        }

        public string GetData()
        {
            WebClient client = new WebClient();
            try
            {
                return client.DownloadString(Link);
            }
            catch (System.Net.WebException ex)
            {
                Service.Log(ex.Message, MsgLevel.Error);
                return null;
            }
        }

        public void CheckPing()
        {
            string data = "00000000";
            byte[] buf = Encoding.ASCII.GetBytes(data);
            var send = new Ping();
            try
            {
                PingReply reply = send.Send(Link.Host, timeout: 120, buf);
                if (reply.Status == IPStatus.Success)
                {
                    Service.Log($"Address: {Link}", MsgLevel.Success);
                    Service.Log($"RoundTrip time:: {reply.RoundtripTime}", MsgLevel.Success);
                    Service.Log($"Time to live: {reply.Options.Ttl}", MsgLevel.Success);
                    Service.Log($"Connected!", MsgLevel.Success);
                }
                else
                {
                    Service.Log($"Address: {Link}", MsgLevel.Error);
                    Service.Log($"Not connected!", MsgLevel.Error);
                }
            }
            catch (PingException ex)
            {
                Service.Log(ex.ToString(), MsgLevel.Error);

            }
        }
    }
}
