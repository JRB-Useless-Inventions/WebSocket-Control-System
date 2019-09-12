# WebSocket-Control-System
A useful wrapper & schema type handler for controlling IP devices that have the WebSocket API installed.

# How To Install NuGet Dependencies
- `Install-Package Newtonsoft.Json -Version 12.0.2`
- `Install-Package WebSocketSharp -Pre`

# How To Start a Socket Server
```cs
using WebSocket_Master_Server; 

Socket ss = new Socket(port: 8080);

ss.Start();
```
# How To Know When A Client Has Connected
```cs

using WebSocket_Master_Server; 

private Socket ss = new Socket(port: 8080);

this.clientel.client_connected_event += connected;

this.ss.Start();

...

private void connected(Client client)
{
	Console.Write("A Client Has Connected")
}

```

# How To Send A Command To A Client
This design uses a `Schema` architecture. The `Send` command must recieve an `Object`, in which it converts the `Object` into a JSON Object. This can be any object you like!

## Schemas
Any `public` variable in the class will be added to the output. Anything `private` will not be included in the output.
```cs
/* SCHEMA.cs*/
using System;
using System.Collections.Generic;

namespace MyApplicationNamespace
{
    public class PERIPHERAL
    {
        public string property;
        public PERIPHERAL()
        {
        }
        public Object on()
        {
            this.property = "on";
            return this;
        }
        public Object off()
        {
            this.property = "off";
            return this;
        }
    }
}
```

```cs
/* Program.cs */
using System;
using System.Configuration;
using System.Threading;
using WebSocket_Master_Server;

namespace MyApplicationNamespace
{
    public class Program
    {
        
        public static void Main (string[] args)
        {
            App app = new App();
            app.run();
            Console.ReadLine ();
        }       
    }
    public class App
    {
        private Socket ss = new ss(port: 8080);
        PERIPHERAL device;

        public App()
        {
            this.ss.client_connected_event += connected;
            //Regitser schemas
            this.device = new PERIPHERAL();
        }

        public void run()
        {
            this.ss.Start();
        }

        private void connected(Client client)
        {
            this.ss.Send(this.device.on(), this.ss.clients[0]);
        }
    }
}
```

The output of this `Send` command will look like this
```json
{"property" : "on"}
```
