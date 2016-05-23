namespace ARX_Twitch
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.millisNumeric = new System.Windows.Forms.NumericUpDown();
            this.labelMillis = new System.Windows.Forms.Label();
            this.GetKeyButton = new System.Windows.Forms.Button();
            this.CallbackInput = new System.Windows.Forms.TextBox();
            this.labelCallback = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.labelMessages = new System.Windows.Forms.Label();
            this.messagesNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.channelInput = new System.Windows.Forms.TextBox();
            this.labelChatMillis = new System.Windows.Forms.Label();
            this.millisChat = new System.Windows.Forms.NumericUpDown();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.millisNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messagesNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.millisChat)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // millisNumeric
            // 
            this.millisNumeric.Location = new System.Drawing.Point(214, 47);
            this.millisNumeric.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.millisNumeric.Minimum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.millisNumeric.Name = "millisNumeric";
            this.millisNumeric.Size = new System.Drawing.Size(63, 20);
            this.millisNumeric.TabIndex = 2;
            this.millisNumeric.Value = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.millisNumeric.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelMillis
            // 
            this.labelMillis.AutoSize = true;
            this.labelMillis.Location = new System.Drawing.Point(12, 49);
            this.labelMillis.Name = "labelMillis";
            this.labelMillis.Size = new System.Drawing.Size(199, 13);
            this.labelMillis.TabIndex = 3;
            this.labelMillis.Text = "Update Interval Stream Information (ms) :";
            // 
            // GetKeyButton
            // 
            this.GetKeyButton.Location = new System.Drawing.Point(448, 7);
            this.GetKeyButton.Name = "GetKeyButton";
            this.GetKeyButton.Size = new System.Drawing.Size(75, 23);
            this.GetKeyButton.TabIndex = 4;
            this.GetKeyButton.Text = "Get Key";
            this.GetKeyButton.UseVisualStyleBackColor = true;
            this.GetKeyButton.Click += new System.EventHandler(this.GetKeyButton_Click);
            // 
            // CallbackInput
            // 
            this.CallbackInput.Location = new System.Drawing.Point(95, 9);
            this.CallbackInput.Name = "CallbackInput";
            this.CallbackInput.Size = new System.Drawing.Size(266, 20);
            this.CallbackInput.TabIndex = 1;
            this.CallbackInput.TextChanged += new System.EventHandler(this.CallbackInput_TextChanged);
            // 
            // labelCallback
            // 
            this.labelCallback.AutoSize = true;
            this.labelCallback.Location = new System.Drawing.Point(10, 12);
            this.labelCallback.Name = "labelCallback";
            this.labelCallback.Size = new System.Drawing.Size(79, 13);
            this.labelCallback.TabIndex = 6;
            this.labelCallback.Text = "Access-Token:";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(367, 7);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 7;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(407, 99);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(40, 13);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Status:";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.ForeColor = System.Drawing.Color.Red;
            this.Status.Location = new System.Drawing.Point(453, 99);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(70, 13);
            this.Status.TabIndex = 9;
            this.Status.Text = "Not logged in";
            // 
            // labelMessages
            // 
            this.labelMessages.AutoSize = true;
            this.labelMessages.Location = new System.Drawing.Point(12, 99);
            this.labelMessages.Name = "labelMessages";
            this.labelMessages.Size = new System.Drawing.Size(108, 13);
            this.labelMessages.TabIndex = 11;
            this.labelMessages.Text = "Messages displayed :";
            // 
            // messagesNumeric
            // 
            this.messagesNumeric.Location = new System.Drawing.Point(126, 97);
            this.messagesNumeric.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.messagesNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.messagesNumeric.Name = "messagesNumeric";
            this.messagesNumeric.Size = new System.Drawing.Size(63, 20);
            this.messagesNumeric.TabIndex = 10;
            this.messagesNumeric.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.messagesNumeric.ValueChanged += new System.EventHandler(this.messagesNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "User:";
            // 
            // channelInput
            // 
            this.channelInput.Enabled = false;
            this.channelInput.Location = new System.Drawing.Point(410, 70);
            this.channelInput.Name = "channelInput";
            this.channelInput.Size = new System.Drawing.Size(113, 20);
            this.channelInput.TabIndex = 13;
            this.channelInput.TextChanged += new System.EventHandler(this.channelInput_TextChanged);
            // 
            // labelChatMillis
            // 
            this.labelChatMillis.AutoSize = true;
            this.labelChatMillis.Location = new System.Drawing.Point(12, 73);
            this.labelChatMillis.Name = "labelChatMillis";
            this.labelChatMillis.Size = new System.Drawing.Size(188, 13);
            this.labelChatMillis.TabIndex = 15;
            this.labelChatMillis.Text = "Update Interval Chat Information (ms) :";
            // 
            // millisChat
            // 
            this.millisChat.Location = new System.Drawing.Point(214, 71);
            this.millisChat.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.millisChat.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.millisChat.Name = "millisChat";
            this.millisChat.Size = new System.Drawing.Size(63, 20);
            this.millisChat.TabIndex = 14;
            this.millisChat.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.millisChat.ValueChanged += new System.EventHandler(this.millisChat_ValueChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 134);
            this.Controls.Add(this.labelChatMillis);
            this.Controls.Add(this.millisChat);
            this.Controls.Add(this.channelInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMessages);
            this.Controls.Add(this.messagesNumeric);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.labelCallback);
            this.Controls.Add(this.CallbackInput);
            this.Controls.Add(this.GetKeyButton);
            this.Controls.Add(this.labelMillis);
            this.Controls.Add(this.millisNumeric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "ARX TwitchControl";
            ((System.ComponentModel.ISupportInitialize)(this.millisNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messagesNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.millisChat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown millisNumeric;
        private System.Windows.Forms.Label labelMillis;
        private System.Windows.Forms.Button GetKeyButton;
        private System.Windows.Forms.TextBox CallbackInput;
        private System.Windows.Forms.Label labelCallback;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label labelMessages;
        private System.Windows.Forms.NumericUpDown messagesNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox channelInput;
        private System.Windows.Forms.Label labelChatMillis;
        private System.Windows.Forms.NumericUpDown millisChat;
        private System.Windows.Forms.Timer timer2;
    }
}

