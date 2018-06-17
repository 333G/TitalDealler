using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 标题处理
{
    public partial class AddWayForm : Form
    {
        public AddWayForm()
        {
            InitializeComponent();

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void confimbutton_Click(object sender, EventArgs e)
        {
            int Ordertype = 1;//默认为1，顺序
            int LocationType = 5;
            int rate = 0;
            if (radioButton5.Checked)
            {
                Ordertype = 3;//随机顺序。3
            }
            else if (radioButton4.Checked)
            {
                Ordertype = 9;//随机插入到标题中，9
            }
            if (radioButton3.Checked)
            {
                LocationType = 7;
                rate = Convert.ToInt32(textBox1.Text);
                if (rate > 10 || rate < 1)
                {
                    MessageBox.Show("输入的值必须在1-10之间！请重新输入！");
                }
                else
                {
                    int type = Ordertype * LocationType;//传递给住窗口值
                    Form1 f1 = (Form1)this.Owner;// 将本窗体的拥有者强制设为Form1类的实例f1
                    f1.GetAddType(type);
                    f1.GetRate(rate);
                    this.Close();
                }
            }
            else
            {
                int type = Ordertype * LocationType;//传递给住窗口值
                Form1 f1 = (Form1)this.Owner;// 将本窗体的拥有者强制设为Form1类的实例f1
                f1.GetAddType(type);
                f1.GetRate(rate);
                this.Close();
            }
        }
        private void Enable(object sender, EventArgs e)
        {
            if (textBox1.Enabled == true)
                textBox1.Enabled = false;
            else
                textBox1.Enabled = true;
        }
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)this.Owner;// 将本窗体的拥有者强制设为Form1类的实例f1
            f1.GetAddType(0);//返回0
            this.Close();
        }


    }
}
