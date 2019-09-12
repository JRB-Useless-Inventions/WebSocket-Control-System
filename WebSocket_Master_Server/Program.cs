using System;
using System.Configuration;
using System.Threading;
using WebSocket_Master_Server;

namespace WebSocket_Test
{
    public class Program
    {
        
        public static void Main (string[] args)
        {
            App app = new App();
            //app.run();
            Console.ReadLine ();
        }       
    }
    public class App
    {
        private Socket clientel = new Socket(port: 8080);
        public int counter;
        DISPLAY lcd;
        AUDIO audioPlayer;
        LED ledDriver;

        public App()
        {
            this.clientel.client_connected_event += connected;
            this.counter = 0;
            //Regitser schemas
            this.lcd = new DISPLAY();
            this.audioPlayer = new AUDIO();
            this.ledDriver = new LED();
            this.audioPlayer.args.setVolume(0.45);
            this.audioPlayer.play("An_Mp3.mp3");
            this.lcd.show("SOME TEXT");

        }

        public void run()
        {
            this.clientel.Start();
        }

        private void connected(Client client)
        {
            
            Console.Write(counter);

            this.clientel.Send(this.lcd.on(), this.clientel.clients[this.counter]);
            Thread.Sleep(2000);

            this.clientel.Send(this.lcd.show("HELLO WORLD"), this.clientel.clients[this.counter]);
            Thread.Sleep(2000);

            this.clientel.Send(this.lcd.off(), this.clientel.clients[this.counter]);
            Thread.Sleep(2000);

            this.counter++;
        }
    }
}

