﻿namespace 标题处理
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MaintextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.KeyWordsOne = new System.Windows.Forms.TextBox();
            this.KeyWordsTwo = new System.Windows.Forms.TextBox();
            this.KeyWordThree = new System.Windows.Forms.TextBox();
            this.ChangeWordBox = new System.Windows.Forms.TextBox();
            this.ReplaceBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            //
            // MaintextBox
            //
            this.MaintextBox.Font = new System.Drawing.Font("宋体", 12.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaintextBox.Location = new System.Drawing.Point(22, 12);
            this.MaintextBox.Multiline = true;
            this.MaintextBox.Name = "MaintextBox";
            this.MaintextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MaintextBox.Size = new System.Drawing.Size(682, 534);
            this.MaintextBox.TabIndex = 0;
            this.MaintextBox.TextChanged += new System.EventHandler(this.SaveTextChanged);
            this.MaintextBox.MouseLeave += new System.EventHandler(this.Hidetooltip);
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(769, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "一键清除英文字母（慎用）";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OneKeyClearEnWords_Click);
            //
            // button2
            //
            this.button2.Location = new System.Drawing.Point(769, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "一键清除【/等符号以及空格符";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OneKeyClearPunctuation_Click);
            //
            // button3
            //
            this.button3.Location = new System.Drawing.Point(734, 266);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(270, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "一键添加营销关键字";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OneKeyAddKeyWords_Click);
            //
            // button4
            //
            this.button4.Location = new System.Drawing.Point(780, 563);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(224, 62);
            this.button4.TabIndex = 4;
            this.button4.Text = "一键替换关键字";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OneKeyReplace_Click);
            //
            // button5
            //
            this.button5.Location = new System.Drawing.Point(72, 569);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "导入标题文档";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Insert_Click);
            //
            // button6
            //
            this.button6.Location = new System.Drawing.Point(265, 569);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 50);
            this.button6.TabIndex = 5;
            this.button6.Text = "清空数据";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ClearAll_Click);
            //
            // button7
            //
            this.button7.Location = new System.Drawing.Point(465, 569);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(150, 50);
            this.button7.TabIndex = 6;
            this.button7.Text = "一键复制到剪贴板";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.OneKeyCopy_Click);
            //
            // KeyWordsOne
            //
            this.KeyWordsOne.Location = new System.Drawing.Point(842, 159);
            this.KeyWordsOne.Name = "KeyWordsOne";
            this.KeyWordsOne.Size = new System.Drawing.Size(162, 25);
            this.KeyWordsOne.TabIndex = 7;
            //
            // KeyWordsTwo
            //
            this.KeyWordsTwo.Location = new System.Drawing.Point(842, 191);
            this.KeyWordsTwo.Name = "KeyWordsTwo";
            this.KeyWordsTwo.Size = new System.Drawing.Size(162, 25);
            this.KeyWordsTwo.TabIndex = 8;
            //
            // KeyWordThree
            //
            this.KeyWordThree.Location = new System.Drawing.Point(842, 222);
            this.KeyWordThree.Name = "KeyWordThree";
            this.KeyWordThree.Size = new System.Drawing.Size(162, 25);
            this.KeyWordThree.TabIndex = 9;
            //
            // ChangeWordBox
            //
            this.ChangeWordBox.Location = new System.Drawing.Point(869, 477);
            this.ChangeWordBox.Name = "ChangeWordBox";
            this.ChangeWordBox.Size = new System.Drawing.Size(135, 25);
            this.ChangeWordBox.TabIndex = 10;
            //
            // ReplaceBox
            //
            this.ReplaceBox.Location = new System.Drawing.Point(869, 521);
            this.ReplaceBox.Name = "ReplaceBox";
            this.ReplaceBox.Size = new System.Drawing.Size(135, 25);
            this.ReplaceBox.TabIndex = 11;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(731, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "营销关键字1：";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(731, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "营销关键字2：";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(731, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "营销关键字3：";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(742, 480);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "需要替换的字：";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(787, 524);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "替换为：";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(1025, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "此处不删除cm，m单位字母";
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("华文细黑", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(1018, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "此处添加三个字以下关键字";
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("华文细黑", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(1018, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "超过三个字可能导致标题溢出";
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("华文细黑", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(1018, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "而无法上传";
            //
            // button8
            //
            this.button8.Location = new System.Drawing.Point(1056, 524);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(150, 40);
            this.button8.TabIndex = 25;
            this.button8.Text = "品牌词库";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.DirtyWordsBase_Click);
            //
            // button9
            //
            this.button9.Location = new System.Drawing.Point(769, 69);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(250, 35);
            this.button9.TabIndex = 26;
            this.button9.Text = "一键清除数字";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.OneKeyClearNum_Click);
            //
            // label10
            //
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(1095, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 28);
            this.label10.TabIndex = 27;
            this.label10.Text = "慎用";
            //
            // button10
            //
            this.button10.Location = new System.Drawing.Point(1056, 579);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(150, 40);
            this.button10.TabIndex = 28;
            this.button10.Text = "一键删除品牌词库";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.DeleteDirtyWordsBase_Click);
            //
            // button11
            //
            this.button11.Location = new System.Drawing.Point(1056, 469);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(150, 37);
            this.button11.TabIndex = 29;
            this.button11.Text = "查看历史替换字";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.CheckHistoryWords_Click);
            //
            // button12
            //
            this.button12.Location = new System.Drawing.Point(745, 428);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(259, 33);
            this.button12.TabIndex = 30;
            this.button12.Text = "删除超过30字的最后面几个字";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.DeleteMoreThen30_Click);
            //
            // checkBox3
            //
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(762, 403);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(254, 19);
            this.checkBox3.TabIndex = 17;
            this.checkBox3.Text = "从后添加关键字（默认从前添加）";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(756, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 79);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            //
            // radioButton2
            //
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 54);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(224, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "标题满30字不添加营销关键字";
            this.radioButton2.UseVisualStyleBackColor = true;
            //
            // radioButton1
            //
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(269, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "标题满30字自动清除最后几位关键字";
            this.radioButton1.UseVisualStyleBackColor = true;
            //
            // checkBox1
            //
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(1028, 403);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 19);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "重复词不添加";
            this.checkBox1.UseVisualStyleBackColor = true;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 652);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.ReplaceBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ChangeWordBox);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyWordThree);
            this.Controls.Add(this.KeyWordsTwo);
            this.Controls.Add(this.KeyWordsOne);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MaintextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   大牛标题助手";
            this.toolTip1.SetToolTip(this, "                                        ");
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseLeave += new System.EventHandler(this.Hidetooltip);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MaintextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox KeyWordsOne;
        private System.Windows.Forms.TextBox KeyWordsTwo;
        private System.Windows.Forms.TextBox KeyWordThree;
        private System.Windows.Forms.TextBox ChangeWordBox;
        private System.Windows.Forms.TextBox ReplaceBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

