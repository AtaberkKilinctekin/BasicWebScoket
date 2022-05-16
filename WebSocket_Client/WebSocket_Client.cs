using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSocketSharp;
using WebSocketSharp.Server;


namespace WebSocket_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/Echo"))
            {
                ws.OnMessage += Ws_Onmessage;

                ws.Connect();
                ws.Send("Hello from Client");

                Console.ReadKey();

            }
        }

        private static void Ws_Onmessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Received from the server: " + e.Data);

            
        }
    }
}
