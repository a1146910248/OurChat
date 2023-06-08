using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Message;
//using AddFriendForm;

namespace MyQQ4Client
{
    static class Program
    {
        static Socket clientSocket = null;
        static IPAddress ip = null;
        static IPEndPoint point = null;

        static MainForm form = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new MainForm(bConnectClick, bSendClick,bAddFriendClick,bNoticiClick);

            /*//测试浅拷贝
            Msg msg = new Msg();
            msg.type = MsgType.Notice;
            msg.content = "nihao(321)";
            form.notices.Add(msg);
            msg = new Msg();
            msg.type = MsgType.Notice;
            msg.content = "nihao(123)";
            form.notices.Add(msg);*/
            
            Application.Run(form);

        }

        static EventHandler bConnectClick = SetConnection;
        static EventHandler bSendClick = SendText;
        static EventHandler bAddFriendClick = AddFriend;
        //static EventHandler bNoticiClick = Notice;
        static EventHandler bNoticiClick = Notice;
        static void SetConnection(object sender, EventArgs e)
        {
            ip = IPAddress.Parse(form.GetIPText());
            point = new IPEndPoint(ip, form.GetPort());

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //进行连接
                clientSocket.Connect(point);
                form.SetConnectionStatusLabel(true, point.ToString());
                form.SetButtonSendEnabled(true);
                form.Println($"连接 {point} 的服务器。");

                //不停的接收服务器端发送的消息
                Thread thread = new Thread(Receive);
                thread.IsBackground = true;
                //连接成功发送自己Id给服务器
                SendMsg(MsgType.ConnectMessage, form.sqlUtils.getSelfId(MainForm.myname));
                thread.Start(clientSocket);

            }
            catch (Exception ex)
            {
                form.Println("错误：" + ex.Message);
            }
        }
        static void Receive(object so)
        {
            Socket send = so as Socket;
            while (true)
            {
                try
                {
                    //获取发送过来的消息
                    byte[] buf = new byte[1024 * 1024 * 2];
                    int len = send.Receive(buf);
                    if (len == 0) break;
                    //反序列化
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new BinaryFormatter();
                    using (System.IO.MemoryStream ms = new MemoryStream(buf, 0, len))
                    {
                        Msg msg = (Msg)formatter.Deserialize(ms);

                        switch (msg.type)
                        {
                            //文本消息 
                            case MsgType.Text:
                                form.Println(msg.content);
                                break;
                            //通知消息
                            case MsgType.Notice:
                                form.notices.Add(msg);
                                //刷新通知显示数量
                                form.noticeLable.Text = "通知 " + form.notices.Count;
                                break;
                            //检查在线消息,收到不回复，服务器处理
                            case MsgType.CheckOnline:
                                GlobalVariables.isOnline = msg.content;
                                break;
                            //在线检查返回信息
                            default: break;
                        }
                    }
                }
                catch (Exception e)
                {
                    form.SetConnectionStatusLabel(false);
                    form.SetButtonSendEnabled(false);
                    form.Println($"服务器已中断连接：{e.Message}");
                    break;
                }
            }
        }

        //消息发送
        public static void SendMsg(MsgType type, string content)
        {
            Msg msg = new Msg();
            msg.type = type;
            msg.content = content;
            //序列化
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, msg);
                byte[] data = ms.ToArray();

                // 使用 Socket 发送msg class
                clientSocket.Send(data);
            }
        }

        //发送文本
        static void SendText(object sender, EventArgs e)
        {
            MsgType type = MsgType.Text;
            string content = form.GetMsgText();
            if (content == "") return;
            SendMsg(type, content);
        
            form.ClearMsgText();
        }

        //添加好友
        static void AddFriend(object sender, EventArgs e)
        {
            //打开输入信息窗口
            AddFriendForm fAddFriend = new AddFriendForm();
            fAddFriend.Show();
        }

        //通知
        static void Notice(object sender, EventArgs e)
        {

            //打开通知窗口
            NoticeForm fNotice = new NoticeForm(form.notices);
            fNotice.Show();
            fNotice.FormClosing += (Object t,FormClosingEventArgs s) =>
            {
                if (form.notices.Count > 0)
                {
                    //刷新通知显示数量
                    form.noticeLable.Text = "通知 " + form.notices.Count;
                }
            };
        }

        //检查在线信息发送
        public static void SendCheckOnline(string uid)
        {
            //缺少根据uid查询对方ip地址的方法
            MsgType type = MsgType.CheckOnline;
            string content = uid;
            SendMsg(type, content);
        }
    }
}
