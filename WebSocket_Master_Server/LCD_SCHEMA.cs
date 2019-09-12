using System;
using System.Collections.Generic;

namespace WebSocket_Test
{
    class DISPLAY
    {
        public class Args
        {
            public string text;
            // Visible Keys
            public Args()
            {
            }
            public void textToShow(string text)
            {
                this.text = text;
            }
        }
        public string lcd;
        public Args args;
        public DISPLAY()
        {
            this.args = new Args();
        }
        public Object off()
        {
            this.lcd = "off";
            this.args = null;
            return this;
        }
        public Object on()
        {
            this.lcd = "on";
            this.args = null;
            return this;
        }
        public Object show(string text)
        {
            this.lcd = "show";
            this.args.textToShow(text: text);
            return this;
        }
    }
}
