using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HostedGraphiteSampleConsoleApp
{
    class Client
    {
        public Setting Setting { get; private set; }
        public Client(Setting setting)
        {
            Setting = setting;
        }
        public async Task SendSpreadToGraphiteAsync()
        {
            var spread = 100; // APIを叩いて取得
            await SendToGraphiteAsync(spread);
        }

        private async Task SendToGraphiteAsync(int value)
        {
            var endPoint = new IPEndPoint(Dns.GetHostAddresses(Setting.HostedGraphiteHostName)[0], Setting.HostedGraphitePort);
            var payload = $"{Setting.HostedGraphiteApiKey}.{Setting.HostedGraphiteMetrics} {value}\n";
            var bytes = Encoding.ASCII.GetBytes(payload);
            var sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp) { Blocking = false };
            await sock.SendToAsync(bytes, SocketFlags.None, endPoint);
        }
    }
}
