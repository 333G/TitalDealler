using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using ToolGood.Words;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Win32;
using JiebaNet.Segmenter;

namespace 标题处理
{
    public partial class Form1 : Form
    {
        public static int time_count = 0;//计时器时间，暂时没有用
        private static int AddType = 0;//与子窗口转递信息用的值,插入关键字的方式
        private static int Rate = 0;//与子窗口转递信息用的值，每个标题是否插入关键字的概率
        private static List<string> TitleStrList=new List<string> ();//用List来存储标题，List内容要与textbox的内容保持一致
        public Form1()
        {
            InitializeComponent();
        }

        private void SaveTextChanged(object sender, EventArgs e)
        {
            string[] SplitStr = MaintextBox.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);//去掉空项
            TitleStrList = new List<string>();
            for (int i = 0; i < SplitStr.Count(); i++)
            {
                string NewItem = SplitStr[i].Replace("\r", "");
                TitleStrList.Add(NewItem);
            }
        }
        private void OneKeyClearEnWords_Click(object sender, EventArgs e)//清除标题的字母
        {
            string InsertStr = MaintextBox.Text;
            int index = MaintextBox.GetFirstCharIndexOfCurrentLine();//得到当前行第一个字符的索引
            int line = GetTextboxLine(index);
            string strRemoved = Regex.Replace(InsertStr, "[a - b]", "", RegexOptions.IgnoreCase);
            strRemoved = Regex.Replace(strRemoved, "[d-l]", "", RegexOptions.IgnoreCase);
            strRemoved = Regex.Replace(strRemoved, "[n-z]", "", RegexOptions.IgnoreCase);
            strRemoved = Regex.Replace(InsertStr, "[A - B]", "", RegexOptions.IgnoreCase);
            strRemoved = Regex.Replace(strRemoved, "[D-L]", "", RegexOptions.IgnoreCase);
            InsertStr = Regex.Replace(strRemoved, "[N-Z]", "", RegexOptions.IgnoreCase);
            WordsSearch iwords = new WordsSearch();
            string keywords = "c|C";
            iwords.SetKeywords(keywords.Split('|'));
            List<WordsSearchResult> LocationresultList= iwords.FindAll(InsertStr);
            for (int i = 0; i < LocationresultList.Count(); i++)
            {
                int n = LocationresultList[i].Start;
                if (!(InsertStr.Substring(n+1,1) == "m" || InsertStr.Substring(n+1,1) == "M"))
                {
                    InsertStr= InsertStr.Remove(n, 1);
                    InsertStr= InsertStr.Insert(n, "*");
                }
            }
            InsertStr.Replace("*", "");
            MaintextBox.Text = InsertStr;
            MaintextBox.SelectionStart = getnewindex(line);
            MaintextBox.SelectionLength = 0;
            MaintextBox.ScrollToCaret();//到指定行
            MaintextBox.Focus();
        }

        private void OneKeyClearNum_Click(object sender, EventArgs e)//清除标题中的数字
        {
            string InsertStr = MaintextBox.Text;
            int index = MaintextBox.GetFirstCharIndexOfCurrentLine();//得到当前行第一个字符的索引
            int line = GetTextboxLine(index);
            string ChangedStr = Regex.Replace(InsertStr, @"\d", "");
            //StringSearch iwords = new StringSearch();
            //string keywords = "0|1|2|3|4|5|6|7|8|9";
            //iwords.SetKeywords(keywords.Split('|'));
            //string ChangedStr = iwords.Replace(InsertStr, ' ');
            //ChangedStr = ChangedStr.Replace("\r\n", "");
            MaintextBox.Text = ChangedStr;
            MaintextBox.SelectionStart = getnewindex(line);
            MaintextBox.SelectionLength = 0;
            MaintextBox.ScrollToCaret();//到指定行
            MaintextBox.Focus();
            //SaveChange(ChangedStr);
        }

        private void OneKeyClearPunctuation_Click(object sender, EventArgs e)
        {
            string InsertStr = MaintextBox.Text;
            int index = MaintextBox.GetFirstCharIndexOfCurrentLine();//得到当前行第一个字符的索引
            int line = GetTextboxLine(index);
            StringSearch iwords = new StringSearch();
            //string keywords = "!|@|#|$|%|^|&|*|(|)|、|“|”|+|……|！|#|￥|（|）| |【|】|[|]|{|}|/|.|。|~|～";
            string[] keyword = { "!","@" ,"#", "$", "%" ,"^", "&", "*", "(", ")","、","“", "”", "+", "……", "！", "#", ":","￥", "（", "）", "【", "】", "[", "]", "{", "}", "/" ,"\\+",".", "。", "~", "～","|","\"" };
            iwords.SetKeywords(keyword);
            string ChangedStr = iwords.Replace(InsertStr, ' ');
            //ChangedStr = ChangedStr.Replace("\r\n", "");
            ChangedStr = ChangedStr.Replace(" ", "");
            MaintextBox.Text = ChangedStr;//改变txtbox内容
            MaintextBox.SelectionStart = getnewindex(line);
            MaintextBox.SelectionLength = 0;
            MaintextBox.ScrollToCaret();//到指定行
            MaintextBox.Focus();
            //SaveChange(ChangedStr);
        }

        private void OneKeyAddKeyWords_Click(object sender, EventArgs e)
        {
            AddWayForm adddwayform= new AddWayForm();
            // this.Visible = false;
            int index = MaintextBox.GetFirstCharIndexOfCurrentLine();//得到当前行第一个字符的索引
            int line = GetTextboxLine(index);
            //int line = MaintextBox.GetLineFromCharIndex(index) + 1;//得到当前行的行号,从0开始，习惯是从1开始，所以+1.
            adddwayform.ShowDialog(this);
            string keyword_1 = KeyWordsOne.Text;
            string keyword_2 = KeyWordsTwo.Text;
            string keyword_3 = KeyWordThree.Text;
            int addway = 1;//默认从前添加
            if (AddType != 0)
            {
                if (checkBox3.Checked)//从后添加
                {
                    addway = 3;
                }
                if (radioButton1.Checked)//如果大于三十就删除最后几个
                {
                    addway = addway * 3;
                }
                else if (radioButton2.Checked)//如果大于三十就不添加（要先判断）【如果原标题28字符以上就一个都不加】
                {
                    addway = addway * 5;
                }//3（前，删除最后几个），5（前，大于三十不添加），9(后，删除最后几个)，15（后，大于三十不添加）
                GetAddstr(addway, keyword_1, keyword_2, keyword_3);
                AddType = 0;//重置值
                MaintextBox.Text = FormatStr(TitleStrList);//显示到textbox
                MaintextBox.SelectionStart = getnewindex(line);
                MaintextBox.SelectionLength = 0;
                MaintextBox.ScrollToCaret();//到指定行
                MaintextBox.Focus();
            }
            else
            {

            }
        }

        //添加关键字的逻辑方法
        private void GetAddstr(int addway, string kword1, string kword2, string kword3)
        {

            if (AddType == 5)//关键字顺序排序，顺序添加
            {
                for (int i = 0; i < TitleStrList.Count(); i++)
                {
                    TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword1, kword2, kword3);//修改List
                }
            }
            else if (AddType == 15)//关键字随机排序 顺序添加
            {
                Random ran = new Random();
                for (int i = 0; i < TitleStrList.Count(); i++)
                {
                    int RandKey = ran.Next(0, 5);//在0-5中产生1个随机数
                    if (RandKey == 0)
                    {
                        TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword1, kword2, kword3);//修改List
                    }
                    else if (RandKey == 1)
                    {
                        TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword1, kword3, kword2);
                    }
                    else if (RandKey == 2)
                    {
                        TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword2, kword1, kword3);
                    }
                    else if (RandKey == 3)
                    {
                        TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword2, kword3, kword1);
                    }
                    else if (RandKey == 4)
                    {
                        TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword3, kword1, kword2);
                    }
                    else if (RandKey == 5)
                    {
                        TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword3, kword2, kword1);
                    }
                    //Thread.Sleep(1);
                }

            }
            else if (AddType == 7)//关键字顺序排序，随机添加
            {
                int[] randary = GetRandAry(TitleStrList.Count(), 0);
                for (int i = 0; i < TitleStrList.Count(); i++)
                {
                    if (randary.Contains(i+1))
                        TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword1, kword2, kword3);//随机添加关键字
                    if (i == TitleStrList.Count() - 1)
                    {
                        if(randary.Contains(i))
                            TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword1, kword2, kword3);//随机添加关键字
                    }
                }
            }
            else if (AddType == 21)//关键字随机排序，随机添加
            {
                int[] randary = GetRandAry(TitleStrList.Count(), 0);
                for (int i = 0; i < TitleStrList.Count(); i++)
                {
                    if (randary.Contains(i+1))
                    {
                        Random randway = new Random();
                        int RandKey = randway.Next(0, 5);//在0-5中产生1个随机数
                        if (RandKey == 0)
                        {
                            TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword1, kword2, kword3);//修改List
                        }
                        else if (RandKey == 1)
                        {
                            TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword1, kword3, kword2);
                        }
                        else if (RandKey == 2)
                        {
                            TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword2, kword1, kword3);
                        }
                        else if (RandKey == 3)
                        {
                            TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword2, kword3, kword1);
                        }
                        else if (RandKey == 4)
                        {
                            TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword3, kword1, kword2);
                        }
                        else if (RandKey == 5)
                        {
                            TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword3, kword2, kword1);
                        }
                    }
                    if (i == TitleStrList.Count() - 1)
                    {
                        if (randary.Contains(i))
                            TitleStrList[i] = AddByWay(addway, TitleStrList[i], kword1, kword2, kword3);//随机添加关键字
                    }
                }
            }
            else if (AddType == 45)//每个标题都添加，关键字随机插入标题中
            {
                for (int i = 0; i < TitleStrList.Count(); i++)
                {
                    TitleStrList[i] = SplitStrWord(TitleStrList[i], kword1, kword2, kword3);//随机添加关键字
                }
                deletemorethan30();//删除超过30的，不管别的功能按钮选择
            }
            else if (AddType == 63)//随机标题添加，关键字随机插入标题中
            {
                int[] randary = GetRandAry(TitleStrList.Count(), 0);
                for (int i = 0; i < TitleStrList.Count(); i++)
                {
                    if (randary.Contains(i))
                        TitleStrList[i] = SplitStrWord(TitleStrList[i], kword1, kword2, kword3);//随机添加关键字
                }
                deletemorethan30();//删除超过30的，不管别的功能按钮选择
            }
        }

        private bool IsContainsKeyword(string TitleStr, string keyword)
        {
            StringSearch isearch = new StringSearch();
            string[] keywords = { keyword };
            isearch.SetKeywords(keywords );
            if (isearch.ContainsAny(TitleStr))
                return true;
            return false;
        }
        private void deletemorethan30()
        {
            for (int i = 0; i < TitleStrList.Count(); i++)
            {
                if (TitleStrList[i].Length > 30)
                {
                    TitleStrList[i] = TitleStrList[i].Substring(0, 30);
                }
            }
            FormatStr(TitleStrList);
        }
        private string SplitStrWord( string InnerStr, string kword1, string kword2, string kword3)//随机插入队列的方法
        {
            JiebaSegmenter newsegment = new JiebaSegmenter();//如果报错，吧Resources文件夹放在exe的同目录中
            var words = newsegment.Cut(InnerStr);
            string Cutstring = string.Join("/ ", words);
            string[] SplitedWordsAry = Cutstring.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);//去掉空项
            int[] randary = GetRandAry(SplitedWordsAry.Count(), 3);
            List<string> NewStrList = new List<string>();

            for (int i = 0; i < SplitedWordsAry.Count(); i++)
            {
                if (!randary.Contains(i +1))
                {
                    NewStrList.Add(SplitedWordsAry[i]);
                }
                else if (randary[0] == i+1)
                {
                    if (checkBox1.Checked)
                    {
                        if (!SplitedWordsAry[i].Contains(kword1))
                            NewStrList.Add(kword1);
                        NewStrList.Add(SplitedWordsAry[i]);
                    }
                    else
                    {
                        NewStrList.Add(kword1);
                        NewStrList.Add(SplitedWordsAry[i]);
                    }
                }
                else if (randary[1] == i+1)
                {
                    if (checkBox1.Checked)
                    {
                        if (!SplitedWordsAry[i].Contains(kword2))
                            NewStrList.Add(kword2);
                        NewStrList.Add(SplitedWordsAry[i]);
                    }
                    else
                    {
                        NewStrList.Add(kword2);
                        NewStrList.Add(SplitedWordsAry[i]);
                    }
                }
                else if (randary[2] == i+1)
                {
                    if (checkBox1.Checked)
                    {
                        if (!SplitedWordsAry[i].Contains(kword3))
                        {
                            NewStrList.Add(SplitedWordsAry[i]);
                            NewStrList.Add(kword3);
                        }
                    }
                    else
                    {
                        NewStrList.Add(SplitedWordsAry[i]);
                        NewStrList.Add(kword3);
                    }
                }
            }

            string AddkeywordsStr = null;
            for (int i = 0; i < NewStrList.Count(); i++)
            {
                AddkeywordsStr += NewStrList[i];
            }
            return AddkeywordsStr.Replace(" ", "");
        }

        private int[] GetRandAry(int Count ,decimal AddCount)//获取随机数列表
        {
            long tick=DateTime.Now.Ticks;
            Random ran= new Random(GetRandomSeed()* (int)(tick & 0xffffffffL)|(int)(tick>>32));
            if (AddCount==0)
                AddCount = Math.Ceiling(Convert.ToDecimal(Convert.ToDecimal(Rate) / 10) * Count);//计算添加个数
            int[] RandAry = new int[Convert.ToInt32(AddCount)];
            if (Count < AddCount)
            {
                for (int i = 0; i< AddCount; i++)
                {
                    RandAry[i] = i;
                }
            }
            else
            {
                for (int i = 0; i < AddCount; i++)
                {
                    int randkey = ran.Next(0, Count);//产生1个随机数
                    if (RandAry.Contains(randkey))
                        i--;
                    else
                        RandAry[i] = randkey;//产生添加个数个不同的随机数
                }
            }
            return
                RandAry;
        }
        private string AddByWay(int addway,string titlestr,string kword1,string kword2,string kword3)
        {
           string AddStr = kword1 + kword2 + kword3;
            if (addway == 3 || addway == 9)//删除最后几个
            {
                if (AddStr.Length + titlestr.Length > 30)
                {
                    int RemoveLength = (AddStr.Length + titlestr.Length) - 30;
                    string DealedStr = titlestr.Substring(0, titlestr.Length - RemoveLength);
                    if (addway == 3)
                        return AddFromHead(DealedStr, kword1, kword2, kword3);
                    return AddFromTail(DealedStr, kword1, kword2, kword3);
                }
                if (addway == 3)
                    return AddFromHead(titlestr, kword1, kword2, kword3);
                return AddFromTail(titlestr, kword1, kword2, kword3);
            }
            else //大于30不添加
            {
                if (titlestr.Length > 28)
                    return titlestr;//大于28字符的原值返回
                if (titlestr.Length + kword1.Length > 30)
                    return titlestr;
                if (titlestr.Length + kword1.Length + kword2.Length > 30)
                {
                    if (addway == 5)
                        return AddFromHead(titlestr, kword1, "", "");
                    return AddFromTail(titlestr, kword1, "", "");
                }
                if (titlestr.Length + AddStr.Length > 30)
                {
                    if (addway == 5)
                        return AddFromHead(titlestr, kword1, kword2, "");
                    return AddFromTail(titlestr, kword1, kword2, "");
                }
                if (addway == 5)
                    return AddFromHead(titlestr, kword1, kword2, kword3);
                return AddFromTail(titlestr, kword1, kword2, kword3);
            }
        }
        private string AddFromHead(string itemstr, string kword1, string kword2, string kword3)//从前添加关键词，检测原标题是否包含关键字，如果包含，不添加
        {
            string tmpstr = "";
            if (checkBox1.Checked)
            {
                if (!IsContainsKeyword(itemstr, kword1))
                    tmpstr += kword1;
                if (!IsContainsKeyword(itemstr, kword2))
                    tmpstr += kword2;
                if (!IsContainsKeyword(itemstr, kword3))
                    tmpstr += kword3;
                return tmpstr + itemstr;
            }
            else
                return kword1 + kword2 + kword3 + itemstr;
        }
        private string AddFromTail(string itemstr, string kword1, string kword2, string kword3)//从后添加关键词，检测原标题是否包含关键字，如果包含，不添加
        {
            string tmpstr = "";
            if (checkBox1.Checked)
            {
                if (!IsContainsKeyword(itemstr, kword1))
                    tmpstr += kword1;
                if (!IsContainsKeyword(itemstr, kword2))
                    tmpstr += kword2;
                if (!IsContainsKeyword(itemstr, kword3))
                    tmpstr += kword3;
                return itemstr + tmpstr;
            }
            else
                return itemstr + kword1 + kword2 + kword3;
        }
        private void CheckHistoryWords_Click(object sender, EventArgs e)
        {
            HistoryWordsForm historywordsform = new HistoryWordsForm();
           // this.Visible = false;
            historywordsform.ShowDialog();
           // this.Visible = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DeleteMoreThen30_Click(object sender, EventArgs e)
        {
            int index = MaintextBox.GetFirstCharIndexOfCurrentLine();//得到当前行第一个字符的索引
            int line = GetTextboxLine(index);
            //int line = MaintextBox.GetLineFromCharIndex(index) + 1;//得到当前行的行号,从0开始，习惯是从1开始，所以+1.
            deletemorethan30();
            MaintextBox.Text = FormatStr(TitleStrList);
            //MaintextBox.Select(index, 0);
            MaintextBox.SelectionStart = getnewindex(line);
            MaintextBox.SelectionLength = 0;
            MaintextBox.ScrollToCaret();
            MaintextBox.Focus();
        }

        private int GetTextboxLine(int index)
        {
            int line = 0;
            int length = 0;
            for (int i = 0; i < TitleStrList.Count(); i++)
            {
                if (length + TitleStrList[i].Length < index)
                    length += TitleStrList[i].Length;
                else
                {
                    line = i + 1;
                    break;
                }

            }
            return line;
        }

        private int getnewindex (int line)
        {
            int newindex = 0;
            for (int i = 0; i < line; i++)
            {
                newindex += TitleStrList[i].Length;

            }
            return newindex;
        }
        private void Insert_Click(object sender, EventArgs e)//在这里写导入文件的代码
        {
            TitleStrList = new List<string>();
            OpenFileDialog Opennewfile = new OpenFileDialog();
            Opennewfile.Filter= "文本文件(*.txt)|*.txt|Word文档(*.doc;*.docx)|*.doc;*.docx";
            string InsertStr=null;
            if (Opennewfile.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的路径
                string extension = Path.GetFullPath(Opennewfile.FileName);
                string doctype = extension.Substring(extension.Length - 4, 4);
                //r如果读取的是txt文件
                string InsertLine = string.Empty;
                if (doctype==".txt"||doctype==".TXT")
                {
                    StreamReader sr = new StreamReader(extension, Encoding.GetEncoding("gb2312"));
                    while ((InsertLine = sr.ReadLine()) != null)
                    {
                        TitleStrList.Add(InsertLine.Trim());//逐行读取标题放入list
                    }
                    sr.Close();
                    MaintextBox.Text = FormatStr(TitleStrList);
                }
                else//剩下的word文件
                {
                    try
                    {
                        Word.Application WordApp = new Word.Application();
                        Word.Document doc = null;
                        object unknow = Type.Missing;
                        WordApp.Visible = false;
                        object filepath = extension;
                        doc = WordApp.Documents.Open(ref filepath,
                             ref unknow, ref unknow, ref unknow, ref unknow,
                             ref unknow, ref unknow, ref unknow, ref unknow,
                             ref unknow, ref unknow, ref unknow, ref unknow,
                             ref unknow, ref unknow, ref unknow);
                        InsertStr = doc.Content.Text;
                        //MaintextBox.Text = InsertStr;
                        //int i = 0;
                        //while ((InsertLine = doc.Sentences[i].Text.Trim()) != null)
                        //{
                        //    TitleStrList.Add(InsertLine);
                        //    i++;
                        //}
                        string Appextension = Application.StartupPath;
                        doc.Close(ref unknow, ref unknow, ref unknow);
                        WordApp.Quit();
                        using (FileStream fs = new FileStream(Appextension + "\\doccache.txt", FileMode.Create))
                        {
                            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312")))
                            {
                                sw.Write(InsertStr);
                                sw.Close();
                            }
                            fs.Close();
                        }
                        StreamReader sr = new StreamReader(Appextension + "\\doccache.txt", Encoding.GetEncoding("gb2312"));
                        while ((InsertLine = sr.ReadLine()) != null)
                        {
                            TitleStrList.Add(InsertLine.Trim());//逐行读取标题放入list
                        }
                        sr.Close();
                        MaintextBox.Text = FormatStr(TitleStrList);
                    }
                    catch(Exception ex)
                    {
                        InsertStr = "出现错误！请检查文件。" + ex;
                        MaintextBox.Text = InsertStr;
                    }
                }
            }
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            MaintextBox.Text = null;
            TitleStrList =null;
        }

        private void OneKeyCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(MaintextBox.Text);
                toolTip1.Show("复制到粘贴板成功!", MaintextBox);
            }
            catch(Exception ex)
            {
                ToolTip tooltip = new ToolTip();
                tooltip.Show("出现错误，请重试" + ex, MaintextBox);

            }
        }
        private void Hidetooltip(object sender, EventArgs e)
        {
           toolTip1.Hide(MaintextBox);
        }
        private void OneKeyReplace_Click(object sender, EventArgs e)
        {
            StringSearch iwords = new StringSearch();
            string ChangeText = ChangeWordBox.Text;
            int index = MaintextBox.GetFirstCharIndexOfCurrentLine();//得到当前行第一个字符的索引
            int line = GetTextboxLine(index);
            string ReplacedText = ReplaceBox.Text;
            if (ChangeText != "")
            {
                for (int i = 0; i < TitleStrList.Count(); i++)
                {
                    string basestr = TitleStrList[i];
                    TitleStrList[i] = basestr.Replace(ChangeText, ReplacedText);
                }
                MaintextBox.Text = FormatStr(TitleStrList);//显示到textbox
                string extension = System.Windows.Forms.Application.StartupPath;
                //把关键字写入历史纪录
                try
                {
                    StreamReader sr = new StreamReader(extension + "\\HisToryReplaceword.txt", Encoding.GetEncoding("gb2312"));
                    string KeyWordsStr = sr.ReadToEnd();
                    sr.Close();
                    using (FileStream fs = new FileStream(extension + "\\HisToryReplaceword.txt", FileMode.Open))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312")))
                        {
                            sw.Write(ChangeText + "|");
                            sw.Write(KeyWordsStr);
                            sw.Close();
                        }
                        fs.Close();
                    }
                }
                catch//没有读取到文件
                {
                    using (FileStream fs = new FileStream(extension + "\\HisToryReplaceword.txt", FileMode.Create))//新建一个文件
                    {
                        using (StreamWriter newFile = new StreamWriter(fs, Encoding.GetEncoding("gb2312")))
                        {
                            newFile.Write(ChangeText + "|");
                            newFile.Close();
                        }
                        fs.Close();
                    }
                }
            }
            else { }
            MaintextBox.SelectionStart = getnewindex(line);
            MaintextBox.SelectionLength = 0;
            MaintextBox.ScrollToCaret();//到指定行
            MaintextBox.Focus();
        }

        private void DirtyWordsBase_Click(object sender, EventArgs e)
        {
            WordsBaseForm wordsbasefrom = new WordsBaseForm();
           // this.Visible=false;
            wordsbasefrom.ShowDialog();
           // this.Visible = true;
        }

        private void DeleteDirtyWordsBase_Click(object sender, EventArgs e)
        {
            string extension = Application.StartupPath;
            int index = MaintextBox.GetFirstCharIndexOfCurrentLine();//得到当前行第一个字符的索引
            int line = GetTextboxLine(index);
            //int line = MaintextBox.GetLineFromCharIndex(index) + 1;//得到当前行的行号,从0开始，习惯是从1开始，所以+1.
            string DeleteWordsStr = null;
            try
            {
                StreamReader sr = new StreamReader(extension + "\\品牌词库.txt", Encoding.GetEncoding("gb2312"));
                DeleteWordsStr = sr.ReadToEnd();
                sr.Close();
            }
            catch(Exception ex)//没有读取到文件
            {
                MessageBox.Show("没有找到品牌词库文件！请先在可执行文件路径下导入【品牌词库.txt】 文件！" + ex);
            }
            if (DeleteWordsStr != null && DeleteWordsStr != "")
            {
                StringSearch iwords = new StringSearch();
                iwords.SetKeywords(DeleteWordsStr.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                for(int i = 0; i < TitleStrList.Count(); i++)
                {
                    string DeletedStr = iwords.Replace(TitleStrList[i], ' ');
                    TitleStrList[i] = DeletedStr.Replace(" ","");
                }
                MaintextBox.Text = FormatStr(TitleStrList);
                MessageBox.Show("删除完成！");
            }
            MaintextBox.SelectionStart = getnewindex(line);
            MaintextBox.SelectionLength = 0;
            MaintextBox.ScrollToCaret();//到指定行
            MaintextBox.Focus();
        }

        private string FormatStr(List<string> InsertStrList)
        {
            string FormattedStr;
            try
            {

                if (InsertStrList.Count > 1)
                {
                    string FinalStr = InsertStrList[0];
                    for (int i = 1; i < InsertStrList.Count(); i++)
                    {
                        FinalStr += "\r\n" + InsertStrList[i];
                    }
                    FormattedStr = FinalStr;
                }
                else
                {
                    FormattedStr = InsertStrList[0];
                }
            }
            catch (Exception ex)
            {
                FormattedStr = "没有检测到标题文件，请导入后重试！" + "\r\n" + ex;
            }
            return FormattedStr;
        }

        //private void SaveChange(string InsertStr)
        //{
        //    string[] SplitStr = InsertStr.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);//去掉空项
        //    for (int i = 0; i < SplitStr.Count(); i++)
        //    {
        //        string NewItem = SplitStr[i].Replace("\r", "");
        //        TitleStrList[i] = NewItem;
        //    }
        //}
        public void GetAddType(int type)
        {
            AddType = type;
        }
        public void GetRate(int rate)
        {
            Rate = rate;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //System.DateTime dt = new DateTime();
            //if (dt.Date > Convert.ToDateTime("2017-9-16"))
            //{
            //    MessageBox.Show("试用期已过");
            //    Thread.Sleep(5000);
            //    Application.Exit();
            //}
            //else
            //{
            //    MessageBox.Show("你还有" + (Convert.ToDateTime("2017-9-16") - dt.Date).ToString() + "天时间可以使用");
            //    Thread.Sleep(5000);
            //}

            //RegistryKey RootKey, RegKey;

            ////项名为：HKEY_CURRENT_USER / Software
            //RootKey = Registry.CurrentUser.OpenSubKey("Software", true);

            ////打开子项：HKEY_CURRENT_USER / Software / MyRegDataApp
            //if ((RegKey = RootKey.OpenSubKey("MyRegDataApp", true)) == null)
            //{
            //    RootKey.CreateSubKey("MyRegDataApp");//不存在，则创建子项
            //    RegKey = RootKey.OpenSubKey("MyRegDataApp", true);
            //    RegKey.SetValue("UseTime", (object)9);    //创建键值，存储可使用次数
            //    MessageBox.Show("您可以免费使用本软件10次！", "感谢您首次使用");
            //    return;
            //}

            //try
            //{
            //    object usetime = RegKey.GetValue("UseTime");//读取键值，可使用次数
            //    MessageBox.Show("你还可以使用本软件 :" + usetime.ToString() + "次！", "确认", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    int newtime = Int32.Parse(usetime.ToString()) - 1;

            //    if (newtime < 0)
            //    {
            //        if (MessageBox.Show("继续使用，请购买本软件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            //        {
            //            Application.Exit();
            //        }
            //    }
            //    else
            //    {
            //        RegKey.SetValue("UseTime", (object)newtime);//更新键值，可使用次数减1
            //    }
            //}
            //catch
            //{
            //    RegKey.SetValue("UseTime", (object)10);    //创建键值，存储可使用次数
            //    MessageBox.Show("您可以免费使用本软件10次！", "感谢您首次使用");
            //    return;
            //}

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否关闭程序", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                e.Cancel = true;
            else
                Environment.Exit(0);
        }

        static int GetRandomSeed()//产生更加随机的随机数种子
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }


    }

}
