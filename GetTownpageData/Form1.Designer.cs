namespace GetTownpageData
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_exec = new System.Windows.Forms.Button();
            this.textBox_keyword = new System.Windows.Forms.TextBox();
            this.textBox_area = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_procStatus = new System.Windows.Forms.Label();
            this.textBox_IndustryCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_subgenre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_output = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label_output_error1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_exec
            // 
            this.button_exec.Location = new System.Drawing.Point(38, 639);
            this.button_exec.Name = "button_exec";
            this.button_exec.Size = new System.Drawing.Size(1282, 86);
            this.button_exec.TabIndex = 0;
            this.button_exec.Text = "データ取得";
            this.button_exec.UseVisualStyleBackColor = true;
            this.button_exec.Click += new System.EventHandler(this.button_exec_Click);
            // 
            // textBox_keyword
            // 
            this.textBox_keyword.Location = new System.Drawing.Point(873, 233);
            this.textBox_keyword.Name = "textBox_keyword";
            this.textBox_keyword.Size = new System.Drawing.Size(447, 31);
            this.textBox_keyword.TabIndex = 1;
            // 
            // textBox_area
            // 
            this.textBox_area.Location = new System.Drawing.Point(242, 369);
            this.textBox_area.Name = "textBox_area";
            this.textBox_area.Size = new System.Drawing.Size(447, 31);
            this.textBox_area.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(733, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "キーワード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "エリアコード";
            // 
            // label_procStatus
            // 
            this.label_procStatus.AutoSize = true;
            this.label_procStatus.Location = new System.Drawing.Point(162, 753);
            this.label_procStatus.Name = "label_procStatus";
            this.label_procStatus.Size = new System.Drawing.Size(100, 24);
            this.label_procStatus.TabIndex = 5;
            this.label_procStatus.Text = "スタンバイ";
            // 
            // textBox_IndustryCode
            // 
            this.textBox_IndustryCode.Location = new System.Drawing.Point(242, 232);
            this.textBox_IndustryCode.Name = "textBox_IndustryCode";
            this.textBox_IndustryCode.Size = new System.Drawing.Size(447, 31);
            this.textBox_IndustryCode.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "業種コード";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(31, 49);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(143, 28);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "業種コード";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(236, 49);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(136, 28);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "キーワード";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(91, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 101);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "業種/キーワード";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox_subgenre
            // 
            this.textBox_subgenre.Location = new System.Drawing.Point(961, 85);
            this.textBox_subgenre.Name = "textBox_subgenre";
            this.textBox_subgenre.Size = new System.Drawing.Size(67, 31);
            this.textBox_subgenre.TabIndex = 9;
            this.textBox_subgenre.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1128, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "サブジャンルコード";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 753);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "処理状態：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "検索条件1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "検索条件2";
            // 
            // textBox_output
            // 
            this.textBox_output.Location = new System.Drawing.Point(94, 497);
            this.textBox_output.Multiline = true;
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.Size = new System.Drawing.Size(1096, 76);
            this.textBox_output.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 444);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 24);
            this.label8.TabIndex = 10;
            this.label8.Text = "出力先";
            // 
            // button_output
            // 
            this.button_output.Location = new System.Drawing.Point(1190, 497);
            this.button_output.Name = "button_output";
            this.button_output.Size = new System.Drawing.Size(130, 76);
            this.button_output.TabIndex = 12;
            this.button_output.Text = "出力先";
            this.button_output.UseVisualStyleBackColor = true;
            this.button_output.Click += new System.EventHandler(this.button_output_Click);
            // 
            // label_output_error1
            // 
            this.label_output_error1.AutoSize = true;
            this.label_output_error1.ForeColor = System.Drawing.Color.Coral;
            this.label_output_error1.Location = new System.Drawing.Point(87, 576);
            this.label_output_error1.Name = "label_output_error1";
            this.label_output_error1.Size = new System.Drawing.Size(299, 24);
            this.label_output_error1.TabIndex = 10;
            this.label_output_error1.Text = "出力先のパスが存在しません。";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(873, 369);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 13;
            this.textBox1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(733, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 24);
            this.label9.TabIndex = 3;
            this.label9.Text = "詳細エエリアコード";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 848);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_output);
            this.Controls.Add(this.textBox_output);
            this.Controls.Add(this.label_output_error1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_subgenre);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_IndustryCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_procStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_area);
            this.Controls.Add(this.textBox_keyword);
            this.Controls.Add(this.button_exec);
            this.Name = "Form1";
            this.Text = "タウンページデータ取得";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_exec;
        private System.Windows.Forms.TextBox textBox_keyword;
        private System.Windows.Forms.TextBox textBox_area;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_procStatus;
        private System.Windows.Forms.TextBox textBox_IndustryCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_subgenre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_output;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_output;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label_output_error1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
    }
}

