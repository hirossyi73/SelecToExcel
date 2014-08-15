﻿namespace SelecToExcel
{
    partial class Form_Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_exitTool = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_option = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_openHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_ = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_cdbsFileList = new System.Windows.Forms.ComboBox();
            this.radioButton_connStr_output = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_connStr_input = new System.Windows.Forms.RadioButton();
            this.comboBox_connectStr = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox_dbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_sqlFileList = new System.Windows.Forms.ComboBox();
            this.radioButton_sql_out = new System.Windows.Forms.RadioButton();
            this.textBox_sql = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton_sql_input = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBox_isOpenExcel = new System.Windows.Forms.CheckBox();
            this.button_excelSansyo = new System.Windows.Forms.Button();
            this.textBox_excelFullPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_execute = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel_.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_menu,
            this.ToolStripMenuItem_option});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(712, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_menu
            // 
            this.ToolStripMenuItem_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_exitTool});
            this.ToolStripMenuItem_menu.Name = "ToolStripMenuItem_menu";
            this.ToolStripMenuItem_menu.Size = new System.Drawing.Size(82, 27);
            this.ToolStripMenuItem_menu.Text = "メニュー";
            // 
            // ToolStripMenuItem_exitTool
            // 
            this.ToolStripMenuItem_exitTool.Name = "ToolStripMenuItem_exitTool";
            this.ToolStripMenuItem_exitTool.Size = new System.Drawing.Size(170, 28);
            this.ToolStripMenuItem_exitTool.Text = "ツールの終了";
            this.ToolStripMenuItem_exitTool.Click += new System.EventHandler(this.ToolStripMenuItem_exitTool_Click);
            // 
            // ToolStripMenuItem_option
            // 
            this.ToolStripMenuItem_option.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_openHelp});
            this.ToolStripMenuItem_option.Name = "ToolStripMenuItem_option";
            this.ToolStripMenuItem_option.Size = new System.Drawing.Size(97, 27);
            this.ToolStripMenuItem_option.Text = "オプション";
            // 
            // ToolStripMenuItem_openHelp
            // 
            this.ToolStripMenuItem_openHelp.Name = "ToolStripMenuItem_openHelp";
            this.ToolStripMenuItem_openHelp.Size = new System.Drawing.Size(275, 28);
            this.ToolStripMenuItem_openHelp.Text = "ヘルプを開く（外部サイト）";
            this.ToolStripMenuItem_openHelp.Click += new System.EventHandler(this.ToolStripMenuItem_openHelp_Click);
            // 
            // panel_
            // 
            this.panel_.Controls.Add(this.label3);
            this.panel_.Controls.Add(this.comboBox_cdbsFileList);
            this.panel_.Controls.Add(this.radioButton_connStr_output);
            this.panel_.Controls.Add(this.label2);
            this.panel_.Controls.Add(this.radioButton_connStr_input);
            this.panel_.Controls.Add(this.comboBox_connectStr);
            this.panel_.Location = new System.Drawing.Point(0, 102);
            this.panel_.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_.Name = "panel_";
            this.panel_.Size = new System.Drawing.Size(712, 131);
            this.panel_.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "└";
            // 
            // comboBox_cdbsFileList
            // 
            this.comboBox_cdbsFileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cdbsFileList.FormattingEnabled = true;
            this.comboBox_cdbsFileList.Location = new System.Drawing.Point(53, 95);
            this.comboBox_cdbsFileList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_cdbsFileList.Name = "comboBox_cdbsFileList";
            this.comboBox_cdbsFileList.Size = new System.Drawing.Size(603, 23);
            this.comboBox_cdbsFileList.TabIndex = 5;
            // 
            // radioButton_connStr_output
            // 
            this.radioButton_connStr_output.AutoSize = true;
            this.radioButton_connStr_output.Location = new System.Drawing.Point(25, 68);
            this.radioButton_connStr_output.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_connStr_output.Name = "radioButton_connStr_output";
            this.radioButton_connStr_output.Size = new System.Drawing.Size(371, 19);
            this.radioButton_connStr_output.TabIndex = 4;
            this.radioButton_connStr_output.Text = "以下の外部接続文字列ファイル（.cdbs）でDBに接続する：";
            this.radioButton_connStr_output.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "└";
            // 
            // radioButton_connStr_input
            // 
            this.radioButton_connStr_input.AutoSize = true;
            this.radioButton_connStr_input.Checked = true;
            this.radioButton_connStr_input.Location = new System.Drawing.Point(27, 4);
            this.radioButton_connStr_input.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_connStr_input.Name = "radioButton_connStr_input";
            this.radioButton_connStr_input.Size = new System.Drawing.Size(251, 19);
            this.radioButton_connStr_input.TabIndex = 2;
            this.radioButton_connStr_input.TabStop = true;
            this.radioButton_connStr_input.Text = "以下の接続文字列でDBに接続する：";
            this.radioButton_connStr_input.UseVisualStyleBackColor = true;
            // 
            // comboBox_connectStr
            // 
            this.comboBox_connectStr.FormattingEnabled = true;
            this.comboBox_connectStr.Location = new System.Drawing.Point(53, 31);
            this.comboBox_connectStr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_connectStr.Name = "comboBox_connectStr";
            this.comboBox_connectStr.Size = new System.Drawing.Size(603, 23);
            this.comboBox_connectStr.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox_dbType);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 61);
            this.panel2.TabIndex = 4;
            // 
            // comboBox_dbType
            // 
            this.comboBox_dbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_dbType.FormattingEnabled = true;
            this.comboBox_dbType.Location = new System.Drawing.Point(100, 8);
            this.comboBox_dbType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_dbType.Name = "comboBox_dbType";
            this.comboBox_dbType.Size = new System.Drawing.Size(328, 23);
            this.comboBox_dbType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "DB種類：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.comboBox_sqlFileList);
            this.panel3.Controls.Add(this.radioButton_sql_out);
            this.panel3.Controls.Add(this.textBox_sql);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.radioButton_sql_input);
            this.panel3.Location = new System.Drawing.Point(0, 285);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(712, 336);
            this.panel3.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 294);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "└";
            // 
            // comboBox_sqlFileList
            // 
            this.comboBox_sqlFileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sqlFileList.FormattingEnabled = true;
            this.comboBox_sqlFileList.Location = new System.Drawing.Point(55, 294);
            this.comboBox_sqlFileList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_sqlFileList.Name = "comboBox_sqlFileList";
            this.comboBox_sqlFileList.Size = new System.Drawing.Size(601, 23);
            this.comboBox_sqlFileList.TabIndex = 9;
            // 
            // radioButton_sql_out
            // 
            this.radioButton_sql_out.AutoSize = true;
            this.radioButton_sql_out.Location = new System.Drawing.Point(27, 266);
            this.radioButton_sql_out.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_sql_out.Name = "radioButton_sql_out";
            this.radioButton_sql_out.Size = new System.Drawing.Size(284, 19);
            this.radioButton_sql_out.TabIndex = 8;
            this.radioButton_sql_out.Text = "以下の外部SQLファイル（.sql）を実行する ：";
            this.radioButton_sql_out.UseVisualStyleBackColor = true;
            // 
            // textBox_sql
            // 
            this.textBox_sql.Location = new System.Drawing.Point(55, 25);
            this.textBox_sql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_sql.Multiline = true;
            this.textBox_sql.Name = "textBox_sql";
            this.textBox_sql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_sql.Size = new System.Drawing.Size(601, 215);
            this.textBox_sql.TabIndex = 7;
            this.textBox_sql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_sql_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "└";
            // 
            // radioButton_sql_input
            // 
            this.radioButton_sql_input.AutoSize = true;
            this.radioButton_sql_input.Checked = true;
            this.radioButton_sql_input.Location = new System.Drawing.Point(27, 5);
            this.radioButton_sql_input.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_sql_input.Name = "radioButton_sql_input";
            this.radioButton_sql_input.Size = new System.Drawing.Size(176, 19);
            this.radioButton_sql_input.TabIndex = 6;
            this.radioButton_sql_input.TabStop = true;
            this.radioButton_sql_input.Text = "以下のSQLを実行する ：";
            this.radioButton_sql_input.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBox_isOpenExcel);
            this.panel4.Controls.Add(this.button_excelSansyo);
            this.panel4.Controls.Add(this.textBox_excelFullPath);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(0, 655);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(712, 162);
            this.panel4.TabIndex = 6;
            // 
            // checkBox_isOpenExcel
            // 
            this.checkBox_isOpenExcel.AutoSize = true;
            this.checkBox_isOpenExcel.Location = new System.Drawing.Point(24, 124);
            this.checkBox_isOpenExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_isOpenExcel.Name = "checkBox_isOpenExcel";
            this.checkBox_isOpenExcel.Size = new System.Drawing.Size(192, 19);
            this.checkBox_isOpenExcel.TabIndex = 12;
            this.checkBox_isOpenExcel.Text = "作成したExcelを自動で開く";
            this.checkBox_isOpenExcel.UseVisualStyleBackColor = true;
            // 
            // button_excelSansyo
            // 
            this.button_excelSansyo.Location = new System.Drawing.Point(559, 65);
            this.button_excelSansyo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_excelSansyo.Name = "button_excelSansyo";
            this.button_excelSansyo.Size = new System.Drawing.Size(96, 29);
            this.button_excelSansyo.TabIndex = 11;
            this.button_excelSansyo.Text = "参照";
            this.button_excelSansyo.UseVisualStyleBackColor = true;
            this.button_excelSansyo.Click += new System.EventHandler(this.button_excelSansyo_Click);
            // 
            // textBox_excelFullPath
            // 
            this.textBox_excelFullPath.Location = new System.Drawing.Point(24, 68);
            this.textBox_excelFullPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_excelFullPath.Name = "textBox_excelFullPath";
            this.textBox_excelFullPath.Size = new System.Drawing.Size(525, 22);
            this.textBox_excelFullPath.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Excel出力先（～.xlsxで指定）：";
            // 
            // button_execute
            // 
            this.button_execute.Location = new System.Drawing.Point(52, 825);
            this.button_execute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_execute.Name = "button_execute";
            this.button_execute.Size = new System.Drawing.Size(603, 49);
            this.button_execute.TabIndex = 13;
            this.button_execute.Text = "出力";
            this.button_execute.UseVisualStyleBackColor = true;
            this.button_execute.Click += new System.EventHandler(this.button_execute_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(712, 889);
            this.Controls.Add(this.button_execute);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.Text = "SelecToExcel　α";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_.ResumeLayout(false);
            this.panel_.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_menu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_exitTool;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_option;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_openHelp;
        private System.Windows.Forms.Panel panel_;
        private System.Windows.Forms.ComboBox comboBox_connectStr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_cdbsFileList;
        private System.Windows.Forms.RadioButton radioButton_connStr_output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_connStr_input;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox_dbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox_sql;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton_sql_input;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_sqlFileList;
        private System.Windows.Forms.RadioButton radioButton_sql_out;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBox_isOpenExcel;
        private System.Windows.Forms.Button button_excelSansyo;
        private System.Windows.Forms.TextBox textBox_excelFullPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_execute;
    }
}
