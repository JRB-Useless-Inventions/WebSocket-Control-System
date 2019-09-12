using System;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Collections.Generic;

namespace WebSocket_Master_Server
{
     
    public delegate void connected_event(WebSocket socket);
    public delegate void disconnected_event(WebSocket socket);
    
    public class TransportLayer : WebSocketBehavior
    {
        public event connected_event connected;
        public event disconnected_event disconnected;

        public TransportLayer ( connected_event connected, disconnected_event disconnected)
        {
            this.disconnected += disconnected;
            this.connected += connected;
        }

        protected override void OnClose (CloseEventArgs e)
        {
            Console.WriteLine("Endpoint Disconnected");
            
        }

        protected override void OnMessage (MessageEventArgs e)
        {
        }

        protected override void OnOpen ()
        {
            Console.WriteLine("Endpoint Connected");
            this.connected(this.Context.WebSocket);

        }
    }
}
