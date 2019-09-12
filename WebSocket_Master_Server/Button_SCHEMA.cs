using System;
using System.Collections.Generic;

namespace WebSocket_Test
{
    public class BUTTON
    {
        public string button;
        public BUTTON()
        {
        }
        public Object on()
        {
            this.button = "on";
            return this;
        }
        public Object off()
        {
            this.button = "off";
            return this;
        }
    }
}
