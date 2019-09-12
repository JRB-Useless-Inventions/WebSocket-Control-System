using System;
using System.Collections.Generic;

namespace WebSocket_Test
{
    class AUDIO
    {
        interface FileInterface
        {
            void setFileName(string fileName);
        }
        public class File : FileInterface
        {
            public string name;
            public File()
            {
            }
            public void setFileName(string fileName)
            {
                this.name = fileName;
            }
        }
        interface DSPInterface
        {
            void setVolume(double volume);
        }

        public class DSP : DSPInterface
        {
            public double volume;
            public DSP()
            {
                this.volume = 0.85;
            }
            public void setVolume(double vol)
            {
                this.volume = vol;
            }
        }
        public class Args : FileInterface, DSPInterface
        {
            public File file;
            public DSP dsp;
            // Visible Keys
            public Args()
            {
                this.file = new File();
                this.dsp = new DSP();

            }
            public void setFileName(string fileName)
            {
                this.file.setFileName(fileName);
            }
            public void setVolume(double volume)
            {
                this.dsp.setVolume(volume);
            }
        }
        //Visible keys
        public string audio;
        public Args args;
       
        public AUDIO()
        {
            this.args = new Args();
        }
        public Object play(string file)
        {
            this.audio = "play";
            this.args.setFileName(fileName: file);
            return this;
        }
        public Object stop(int file)
        {
            this.audio = "stop";
            this.args = null;
            return this;
        }
    }
}
