using MyQQ4Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Message;
//通知窗口
namespace MyQQ4Client
{
    public class NoticeForm : Form
    {
        private SqlUtils sqlUtils;
        public List<Msg> notices;
        private ListView listView1;

        public NoticeForm()
        {
            InitializeComponent();
            sqlUtils = new SqlUtils();
        }

        public NoticeForm(List<Msg> notices)
        {
            InitializeComponent();
            sqlUtils = new SqlUtils();
            //浅拷贝，直接赋值地址
            this.notices = notices;
           
            DisplayNotices();
        }

        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(273, 101);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.MultiSelect = false;
            // 
            // NoticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 154);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NoticeForm";
            this.Text = "通知";
            this.ResumeLayout(false);

        }

        private void DisplayNotices()
        {
            if (!notices.Any())
            {
                return;
            }
            else
            {
                foreach (Msg msg in notices)
                {
                    CreatItem(msg.content);
                }
            }
        }

        //为ListView添加Item
        private void CreatItem(string content)
        {
            ListViewItem item = new ListViewItem(content);
            listView1.Items.Add(item);
            
        }

       
        //Item点击事件
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            //获取选中的项目
            ListView.SelectedListViewItemCollection item =  listView1.SelectedItems;
            //MessageBox.Show("点击了1个item  " + item[0].Text);
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            string message = item[0].Text + "想添加你为好友";
            DialogResult result = MessageBox.Show(message, "确认添加", buttons);

            //如果同意则添加好友，拒绝则将这一项移除
            if (result == DialogResult.Yes)
            {
                //用正则表达式截取括号内的Id
                Regex regex = new Regex(@"\((.*?)\)");

                //获取匹配结果
                Match match = regex.Match(item[0].Text);
                int pid = int.Parse(match.Groups[1].Value);

                string res = sqlUtils.getSelfId(MainForm.myname);
                regex = new Regex(@"id:\s*(\d+)"); // 定义正则表达式
                match = regex.Match(res); // 匹配字符串
                if (match.Success)
                {
                    string idValue = match.Groups[1].Value; // 提取 sid 属性值
                    int sid = int.Parse(idValue); // 将字符串转换为整数类型的值
                    if (sqlUtils.AddFriend(pid, sid))
                    {
                        MessageBox.Show("添加成功");
                    }

                    for (int i = 0; i < notices.Count; i++)
                    {
                        if (item[0].Text == notices[i].content)
                        {
                            notices.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            else
            {
                for(int i = 0; i < notices.Count; i++)
                {
                    if (item[0].Text == notices[i].content)
                    {
                        notices.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }

    
}