using System.Drawing;
using System.Windows.Forms;

namespace MyQQ4Client
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxSendee = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddFriend = new System.Windows.Forms.Button();
            this.noticeLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(473, 20);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(67, 15);
            this.labelStatus.TabIndex = 17;
            this.labelStatus.Text = "尚未连接";
            // 
            // textBoxSendee
            // 
            this.textBoxSendee.Location = new System.Drawing.Point(21, 394);
            this.textBoxSendee.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSendee.Name = "textBoxSendee";
            this.textBoxSendee.Size = new System.Drawing.Size(532, 25);
            this.textBoxSendee.TabIndex = 16;
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(561, 394);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(100, 29);
            this.buttonSend.TabIndex = 15;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(365, 16);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(100, 29);
            this.buttonConnect.TabIndex = 14;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMsg.Location = new System.Drawing.Point(20, 52);
            this.textBoxMsg.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.ReadOnly = true;
            this.textBoxMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMsg.Size = new System.Drawing.Size(444, 333);
            this.textBoxMsg.TabIndex = 13;
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(284, 16);
            this.numericUpDownPort.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(73, 25);
            this.numericUpDownPort.TabIndex = 12;
            this.numericUpDownPort.Value = new decimal(new int[] {
            6666,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "端口";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(92, 16);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIP.MaxLength = 15;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(132, 25);
            this.textBoxIP.TabIndex = 10;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP 地址";
            // 
            // buttonAddFriend
            // 
            this.buttonAddFriend.Location = new System.Drawing.Point(561, 129);
            this.buttonAddFriend.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddFriend.Name = "buttonAddFriend";
            this.buttonAddFriend.Size = new System.Drawing.Size(100, 29);
            this.buttonAddFriend.TabIndex = 18;
            this.buttonAddFriend.Text = "添加好友";
            this.buttonAddFriend.UseVisualStyleBackColor = true;
            // 
            // noticeLable
            // 
            this.noticeLable.AutoSize = true;
            this.noticeLable.Location = new System.Drawing.Point(591, 91);
            this.noticeLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noticeLable.Name = "noticeLable";
            this.noticeLable.Size = new System.Drawing.Size(37, 15);
            this.noticeLable.TabIndex = 19;
            this.noticeLable.Text = "通知";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 439);
            this.Controls.Add(this.buttonAddFriend);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxSendee);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noticeLable);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "耳卯   --客户端";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxSendee;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddFriend;
        public System.Windows.Forms.Label noticeLable;
    }
}

