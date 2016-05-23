using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ARX_Twitch
{
    class IRC
    {
        TcpClient Client;
        NetworkStream NwStream;
        StreamReader Reader;
        StreamWriter Writer;
        List<String> messages;
        int messageCapacity = 0;
        Thread listener;

        public IRC(String username, String key, String channel, int shownMessages)
        {
            Client = new TcpClient("irc.twitch.tv", 6667);
            NwStream = Client.GetStream();
            Reader = new StreamReader(NwStream, Encoding.GetEncoding("iso8859-1"));
            Writer = new StreamWriter(NwStream, Encoding.GetEncoding("iso8859-1"));
            messages = new List<string>();
            messageCapacity = shownMessages;

            listener = new Thread(new ThreadStart(Listener));
            listener.Start();

            SendMessage("USER " + username.ToLower() + "tmi twitch :" + username.ToLower());
            SendMessage("PASS oauth:" + key);
            SendMessage("NICK " + username.ToLower());

            InitChannel(channel);
        }

        private void InitChannel(string name)
        {
            Writer.WriteLine("JOIN #" + name + "\n");
            Writer.Flush();
        }

        public List<string> GetMessages()
        {
            return messages;
        }

        public void Listener()
        {
            string Data = "";
            try
            {
                while ((Data = Reader.ReadLine()) != null)
                {
                    string nick = "";
                    string type = "";
                    string channel = "";
                    string message = "";
                    string[] ex;

                    ex = Data.Split(new char[] { ' ' }, 5);
                    if (ex[0] == "PING")
                    {
                        SendMessage("PONG " + ex[1]);
                    }

                    string[] split1 = Data.Split(':');
                    if (split1.Length > 1)
                    {
                        string[] split2 = split1[1].Split(' ');
                        nick = split2[0];
                        nick = nick.Split('!')[0];
                        type = split2[1];
                        channel = split2[2];
                        if (split1.Length > 2)
                        {
                            for (int i = 2; i < split1.Length; i++)
                            {
                                message += split1[i] + " ";
                            }
                        }
                        if (type == "PRIVMSG" && channel.Contains("#"))
                        {
                            if (messages.Count >= messageCapacity)
                            {
                                messages.RemoveAt(0);
                            }
                            messages.Add(nick + ": " + message);
                        }


                    }
                }
            }
            catch (Exception e)
            {
                listener.Abort();
            }
        }

        public void SendMessage(string message)
        {
            Writer.WriteLine(message);
            Writer.Flush();
        }
    }
}
