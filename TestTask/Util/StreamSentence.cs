using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Util
{
    public class StreamSentence
    {
        public System.IO.StreamReader reader;
        public string sentence;
        public bool isEnd;
        public StreamSentence(System.IO.StreamReader reader1)
        {
            isEnd = false;
            this.reader = reader1;
        }

        public void GetNextSentence()
        {
            string sent = "";
            int elem;
            while ((elem = reader.Read()) != -1 && (char)elem != '.')
            {
                sent += (char)elem;
            }

            if (elem == -1)
                isEnd = true;

            sentence = sent;
        }
    }
}