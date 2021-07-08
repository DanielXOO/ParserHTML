using DanielXOO.ShopParser.Controller;
using DanielXOO.ShopParser.Service;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace DanielXOO.ShopParser
{
    class OpenProvider : IDataProvider
    {
        private IService Service;
        private IController URL;
        public string Link { get; set; }

        public OpenProvider(string src)
        {
            Service = new ConsoleService();
            URL = new OnlineShopController();
            if (!string.IsNullOrEmpty(src))
            {
                Link = src;
            }
            else
            {
                Service.Log("Incorrect string", MsgLevel.Error);
                Link = " ";
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
                PingReply reply = send.Send(URL.GetRoot(Link), timeout: 120, buf);
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
