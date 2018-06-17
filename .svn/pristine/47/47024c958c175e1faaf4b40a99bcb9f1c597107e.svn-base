using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 标题处理
{
    public partial class HistoryWordsForm : Form
    {
        static string extension = Application.StartupPath;
        public HistoryWordsForm()
        {
            InitializeComponent();
        }

        private void HistoryWordsForm_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(extension + "\\HisToryReplaceword.txt", Encoding.GetEncoding("gb2312"));
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            catch//没有读取到文件
            {
                textBox1.Text = "没有找到历史文件！";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messbutton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("             确定要保存修改吗", "保存修改", messbutton);
            if (dr == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(extension + "\\HisToryReplaceword.txt", FileMode.Create))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312")))
                        {
                            sw.Write(textBox1.Text + "|");
                            sw.Close();
                        }
                        fs.Close();
                    }
                }
                catch
                {
                    using (FileStream fs = new FileStream(extension + "\\HisToryReplaceword.txt", FileMode.Create))//新建一个文件
                    {
                        using (StreamWriter newFile = new StreamWriter(fs, Encoding.GetEncoding("gb2312")))
                        {
                            newFile.Write(textBox1.Text + "|");
                            newFile.Close();
                        }
                        fs.Close();
                    }
                }
            }
            else { }

        }
    }
}
