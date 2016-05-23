using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;

using ARX;
using TwixelAPI;
using TwixelAPI.Constants;
using System.Threading;

namespace ARX_Twitch
{
    public partial class SettingsForm : Form
    {
        private LogitechArx.logiArxCbContext contextCallback;
        Twixel twitchClient;
        User twitchUser = null;
        Channel twitchChannel = null;
        IRC irc = null;
        string accessToken = "";
        string clientID = "9jxfngcz89nc6cbkajtjb2z5l7dne2e";
        string ircChannel = "";
        int ircMessages = 250;
        public SettingsForm()
        {
            InitializeComponent();
            accessToken = Properties.Settings.Default.Key;
            ircMessages = Properties.Settings.Default.messageCapacity;
            this.messagesNumeric.Value = (decimal)ircMessages;
            this.CallbackInput.Text = accessToken;
            this.millisNumeric.Value = (decimal)Properties.Settings.Default.Interval;
            this.millisChat.Value = (decimal)Properties.Settings.Default.ChatInterval;
            twitchClient = new Twixel(clientID,
                    "http://localhost", Twixel.APIVersion.v3);

        }

        void Start() //Start Logitech ARX INIT
        {
            contextCallback.arxCallBack = new LogitechArx.logiArxCB(this.callback);
            contextCallback.arxContext = System.IntPtr.Zero;
            bool retVal = LogitechArx.LogiArxInit("de.so.TwitchControl", "TwitchControl", ref contextCallback);
            if (!retVal)
            {
                int retCode = LogitechArx.LogiArxGetLastError();
                Debug.Fail("SDK can't be initalized! Error: " + retCode);
            }
        }
        void callback(int eventType, int eventValue, System.String eventArg, System.IntPtr context)
        {
            if (eventType == LogitechArx.LOGI_ARX_EVENT_MOBILEDEVICE_ARRIVAL)
            {
                LogitechArx.LogiArxAddFileAs("index.html", "index.html", "text/html");
                Thread.Sleep(1000);
                LogitechArx.LogiArxAddFileAs("jquery.min.js", "jquery.min.js", "text/html");
                Thread.Sleep(1000);
                LogitechArx.LogiArxSetIndex("index.html");
                try
                {
                    if (twitchUser == null)
                    {
                        MessageBox.Show("You are not logged in!", "Login");
                    }
                    else
                    {
                        update();
                    }

                }
                catch { }
            }
            else if (eventType == LogitechArx.LOGI_ARX_EVENT_MOBILEDEVICE_REMOVAL)
            {
            }
            else if (eventType == LogitechArx.LOGI_ARX_EVENT_FOCUS_ACTIVE)
            {
                if (twitchUser == null)
                {
                    MessageBox.Show("You are not logged in!", "Login");
                }
                else
                {
                    update();
                }
            }
            else if (eventType == LogitechArx.LOGI_ARX_EVENT_FOCUS_INACTIVE)
            {
            }
            else if (eventType == LogitechArx.LOGI_ARX_EVENT_TAP_ON_TAG)
            {
                if (twitchUser == null)
                {
                    MessageBox.Show("You are not logged in!", "Login");
                }
                else
                {
                    switch (eventArg)
                    {
                        case "makeCommercial30":
                            twitchUser.StartCommercial(TwitchConstants.CommercialLength.Sec30);
                            break;
                        case "makeCommercial60":
                            twitchUser.StartCommercial(TwitchConstants.CommercialLength.Sec60);
                            break;
                        case "makeCommercial90":
                            twitchUser.StartCommercial(TwitchConstants.CommercialLength.Sec90);
                            break;
                        case "makeCommercial120":
                            twitchUser.StartCommercial(TwitchConstants.CommercialLength.Sec120);
                            break;
                        case "makeCommercial150":
                            twitchUser.StartCommercial(TwitchConstants.CommercialLength.Sec150);
                            break;
                        case "makeCommercial180":
                            twitchUser.StartCommercial(TwitchConstants.CommercialLength.Sec180);
                            break;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            update();
        }

        private async void update()
        {
            if (twitchUser == null)
            {
                MessageBox.Show("You are not logged in!", "Login");
            }
            else
            {
                twitchChannel = await twitchUser.RetrieveChannel();
                updateStreamInfo();
                updateChannelInfo();
                updateSubscriber();
            }
        }

        private async void updateSubscriber()
        {
            if (twitchChannel != null)
            {
                if (twitchChannel.partner.Value)
                {
                    try
                    {
                        Total<List<Subscription<User>>> subs = await twitchUser.RetriveSubscribers();
                        string text = "<ul>";
                        foreach (Subscription<User> sub in subs.wrapped)
                        {
                            text += "<li>" + sub.wrapped.name.ToString() + "</li>";
                        }
                        text += "</ul>";
                        LogitechArx.LogiArxSetTagContentById("last_subs", text);
                    }
                    catch { }
                }
                else
                {
                    LogitechArx.LogiArxSetTagContentById("last_subs", "No partner");
                }
            }
        }

        private void updateIRC()
        {
            Debug.Print("Update IRC");
            if (irc != null)
            {
                try
                    {
                    List<String> messages = irc.GetMessages();
                        string text = "<ul>";
                        foreach (String message in messages)
                        {
                            text += "<li>" + message + "</li>";
                        }
                        text += "</ul>";
                        LogitechArx.LogiArxSetTagContentById("chat_messages", text);
                    }
                    catch { }
            }
        }

        private void updateChannelInfo()
        {
            if (twitchChannel != null)
            {
                LogitechArx.LogiArxSetTagContentById("channel_views", twitchChannel.views.ToString());
                LogitechArx.LogiArxSetTagContentById("followers", twitchChannel.followers.ToString());
                LogitechArx.LogiArxSetTagContentById("mature", twitchChannel.mature.ToString());
            }
        }

        private async void updateStreamInfo()
        {
            Debug.Print("Update Stream Info");
            Stream twitchStream = null;
            try
            {
                twitchStream = await twitchClient.RetrieveStream(twitchUser.name.ToString());
                LogitechArx.LogiArxSetTagContentById("average_fps", twitchStream.averageFps.ToString());
                LogitechArx.LogiArxSetTagContentById("game", twitchStream.game.ToString());
                LogitechArx.LogiArxSetTagContentById("viewers", twitchStream.viewers.ToString());
                LogitechArx.LogiArxSetTagContentById("video_quality", twitchStream.videoHeight.ToString() + "p");
                LogitechArx.LogiArxSetTagContentById("status", twitchChannel.status.ToString());
                if (twitchChannel.delay.ToString() != "")
                {
                    LogitechArx.LogiArxSetTagContentById("delay", twitchChannel.delay.ToString());
                }
                else
                {
                    LogitechArx.LogiArxSetTagContentById("delay", "None");
                }
            }
            catch
            {
                LogitechArx.LogiArxSetTagContentById("average_fps", "");
                LogitechArx.LogiArxSetTagContentById("game", "");
                LogitechArx.LogiArxSetTagContentById("viewers", "");
                LogitechArx.LogiArxSetTagContentById("video_quality", "");
                LogitechArx.LogiArxSetTagContentById("status", "Stream offline!");
                LogitechArx.LogiArxSetTagContentById("delay", "");
            }


            if (twitchChannel != null)
            {
                if (!twitchChannel.partner.Value)
                {
                    LogitechArx.LogiArxSetTagPropertyById("commercial_card", "hidden", "true");
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ARX_Twitch.Properties.Settings.Default.Interval = Convert.ToInt32(millisNumeric.Value);
            ARX_Twitch.Properties.Settings.Default.Save();
            timer1.Interval = Convert.ToInt32(millisNumeric.Value);
        }

        private void GetKeyButton_Click(object sender, EventArgs e)
        {
            List<TwitchConstants.Scope> scopes = new List<TwitchConstants.Scope>();
            scopes.Add(TwitchConstants.Scope.UserRead);
            scopes.Add(TwitchConstants.Scope.ChannelCheckSubscription);
            scopes.Add(TwitchConstants.Scope.ChannelCommercial);
            scopes.Add(TwitchConstants.Scope.ChannelEditor);
            scopes.Add(TwitchConstants.Scope.ChannelRead);
            scopes.Add(TwitchConstants.Scope.ChannelStream);
            scopes.Add(TwitchConstants.Scope.ChannelSubscriptions);
            scopes.Add(TwitchConstants.Scope.ChatLogin);
            scopes.Add(TwitchConstants.Scope.UserBlocksEdit);
            scopes.Add(TwitchConstants.Scope.UserBlocksRead);
            scopes.Add(TwitchConstants.Scope.UserFollowsEdit);
            scopes.Add(TwitchConstants.Scope.UserSubcriptions);

            Uri uri = twitchClient.Login(scopes);
            Debug.WriteLine(uri.ToString());
            Process.Start(uri.ToString());
        }

        private void CallbackInput_TextChanged(object sender, EventArgs e)
        {
            ARX_Twitch.Properties.Settings.Default.Key = CallbackInput.Text;
            ARX_Twitch.Properties.Settings.Default.Save();
            accessToken = CallbackInput.Text;
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            if (accessToken.Length == 0)
            {
                MessageBox.Show("Please get a key first", "Login");
            }
            else
            {
                if (twitchUser == null)
                {
                    try { 
                        twitchUser = await twitchClient.RetrieveUserWithAccessToken(accessToken);
                        Status.Text = "Logged In!";
                        Status.ForeColor = System.Drawing.Color.Green;
                        timer1.Enabled = true;
                        timer2.Enabled = true;
                        Start();
                    }
                    catch
                    {
                        MessageBox.Show("Login failed!","Login");
                    }
                }
                else
                {
                    MessageBox.Show("Already logged in!", "Login");
                }
            }
        }

        private void channelInput_TextChanged(object sender, EventArgs e)
        {
            ircChannel = channelInput.Text;
        }

        private void messagesNumeric_ValueChanged(object sender, EventArgs e)
        {
            ARX_Twitch.Properties.Settings.Default.messageCapacity = Convert.ToInt32(messagesNumeric.Value);
            ARX_Twitch.Properties.Settings.Default.Save();
            ircMessages = Convert.ToInt32(messagesNumeric.Value);
        }

        private void millisChat_ValueChanged(object sender, EventArgs e)
        {
            ARX_Twitch.Properties.Settings.Default.ChatInterval = Convert.ToInt32(millisChat.Value);
            ARX_Twitch.Properties.Settings.Default.Save();
            timer2.Interval = Convert.ToInt32(millisChat.Value);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (twitchUser == null)
            {
                MessageBox.Show("You are not logged in!", "Login");
            }
            else
            {
                if (irc == null) {
                    irc = new IRC(twitchUser.name, accessToken, twitchUser.name, ircMessages);
                    channelInput.Text = twitchUser.name;
                }
                updateIRC();
            }
        }
    }
}
