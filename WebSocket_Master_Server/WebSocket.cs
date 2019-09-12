using System;
using System.Threading;
using WebSocketSharp;
using System.Collections.Generic;
using WebSocketSharp.Server;
using Newtonsoft;
using Newtonsoft.Json;

namespace WebSocket_Master_Server
{
    public delegate void client_connected_delegate(Client client);
    public delegate void client_disconnected_delegate(Client client);

    public class Client
    {
        public WebSocket socket;

        public Client(WebSocket socket)
        {
            this.socket = socket;
        }
    }


    class Socket
    {
        public event client_connected_delegate client_connected_event;
        public event client_disconnected_delegate client_disconnected_event;

        public WebSocketServer wssv;
        public IList<Client> clients = new List<Client>();

        public Socket(int port)
        {

            this.wssv = new WebSocketServer(port);

            // Add the WebSocket services.
            this.wssv.AddWebSocketService<TransportLayer>("/",() => new TransportLayer(this.socket_connected,this.socket_disconnected));

            // Add the WebSocket service with initializing.


            if (this.wssv.IsListening)
            {
                Console.WriteLine("Listening on port {0}, and providing WebSocket services:", wssv.Port);
                foreach (var path in this.wssv.WebSocketServices.Paths)
                    Console.WriteLine("- {0}", path);
            }
        }

        private void socket_disconnected(WebSocket socket)
        {
            //this.clients.Remove(socket);
        }

        private void socket_connected(WebSocket socket)
        {
            Client newClient = new Client(socket);
            clients.Add(newClient);
            this.client_connected_event(newClient);
        }

        public void Stop()
        {
            this.wssv.Stop();
        }
        public void Start()
        {
            this.wssv.Start();
        }

        public void Send(Object obj, Client client)
        {
            string msg = JsonConvert.SerializeObject(obj, Formatting.Indented);
            client.socket.Send(msg);
        }

    }
    
}

