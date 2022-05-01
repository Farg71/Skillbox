using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace Networking.BotsClass.Discord
{
    internal class DiscordClient
    {
        const string GATEWAY_URI = "wss://gateway.discord.gg/?v=6&encoding=json";
        readonly string TOKEN;

        ClientWebSocket client;
        byte[] buffer = new byte[4096];
        UTF8Encoding encoding = new UTF8Encoding();

        public DiscordClient(string token)
        {
            TOKEN = token;
        }

        public async void Connect()
        {
            client = new ClientWebSocket();
            await client.ConnectAsync(new Uri(GATEWAY_URI), CancellationToken.None);
            await client.ReceiveAsync(buffer, CancellationToken.None);
            JObject json = JObject.Parse(Encoding.UTF8.GetString(buffer));
            Array.Clear(buffer, 0, buffer.Length);

            string t = json["t"].ToString();
            string s = json["s"].ToString();
            string op = json["op"].ToString();
            int heartbeatInterval = int.Parse(json["d"]["heartbeat_interval"].ToString());
            ReceiveAsync();
            SendHeartbeatAsync(heartbeatInterval);
            await SendIdentifyAsync();

        }

        async Task SendIdentifyAsync()
        {
            JObject json = JObject.Parse(Payload.identify);
            json["d"]["token"] = TOKEN;
            Payload.identify = json.ToString();
            await client.SendAsync(new ArraySegment<byte>(encoding.GetBytes(Payload.identify)), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        async void SendHeartbeatAsync(int interval)
        {
            while (true)
            {
                await client.SendAsync(new ArraySegment<byte>(encoding.GetBytes(Payload.heartbeat)), WebSocketMessageType.Text, true, CancellationToken.None);
                await Task.Delay(interval);
            }
        }

        async void ReceiveAsync()
        {
            while (true)
            {
                await client.ReceiveAsync(buffer, CancellationToken.None);
                Console.WriteLine(encoding.GetString(buffer));
                Array.Clear(buffer, 0, buffer.Length);
            }
        }


    }
}
