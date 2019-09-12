using System;
using System.Collections.Generic;

namespace WebSocket_Test
{
    public class LED
    {
        public class Args
        {
            public string color;
            public double period;
            // Visible Keys
            
            public Args()
            {
                this.color = "red";
                this.period = 0.1;
            }

            public void setColor(string color)
            {
                this.color = color;
            }
            public void setPeriod(double period)
            {
                this.period = period;
            }
        }
        public string led;
        public Args args;
        public LED()
        {
        }
        public Object on(string color = null)
        {
            if(color != null)
            {
                this.args.setColor(color);
            }
            this.led = "on";
            return this;
        }
        public Object off()
        {
            this.led = "off";
            this.args = null;
            return this;
        }
        public Object flash(string color = null)
        {
            if (color != null)
            {
                this.args.setColor(color);
            }
            this.led = "flash";
            return this;
        }
    }
}
