using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.IO;
using SelecToExcel.Models;
using SelecToExcel.Common;

namespace SelecToExcel
{
    public partial class Form_Main : Form
    {
        private const int HISTORY_MAX = 10;
        private ToolSettingModel app;
        public Form_Main()
        {
            InitializeComponent();
            Initialize();
            appConfigRoad();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            app = new ToolSettingModel();
            foreach (Define.DatabaseType item in Enum.GetValues(typeof(Define.DatabaseType)))
            {
                this.comboBox_dbType.Items.Add(Define.GetDbTypeString(item));
                if (item == app.DbType)
                {
                    this.comboBox_dbType.SelectedIndex = (int)item;
                }
            }

            // 外部SQL 無ければフォルダ作成
            if (!Directory.Exists(Define.UserOutSqlDirFullPath))
            {
                Directory.CreateDirectory(Define.UserOutSqlDirFullPath);
            }
            // 外部CDBS 無ければフォルダ作成
            if (!Directory.Exists(Define.UserOutCdbsDirFullPath))
            {
                Directory.CreateDirectory(Define.UserOutCdbsDirFullPath);
            }

            // 外部SQLファイル読み込み
            foreach (var item in Bis.GetFileList(Define.UserOutSqlDirFullPath, "*.sql"))
            {
                this.comboBox_sqlFileList.Items.Add(Path.GetFileName(item));
            }
            // 外部cdbsファイル読み込み
            foreach (var item in Bis.GetFileList(Define.UserOutCdbsDirFullPath, "*.cdbs"))
            {
                this.comboBox_cdbsFileList.Items.Add(Path.GetFileName(item));
            }
        }


        /// <summary>
        /// 時間ない　てきとう
        /// エラー制御とかそのうち頑張る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_execute_Click(object sender, EventArgs e)
        {
            try
            {
                toggleForm(false);
                appConfigSave();

                // SQL文の設定
                string sql = string.Empty;
                if (this.radioButton_sql_input.Checked)
                {
                    sql = this.textBox_sql.Text;
                }
                else
                {
                    // 選択されてなければ終了
                    if (this.comboBox_sqlFileList.SelectedIndex == -1)
                    {
                        windowEnabled("実行するSQLを選択してください");
                        return;
                    }
                    sql = Bis.GetFileText(Path.Combine(Define.UserOutSqlDirFullPath, this.comboBox_sqlFileList.Text));
                }

                // 接続文字列の設定
                string connectionString = string.Empty;
                if (this.radioButton_connStr_input.Checked)
                {
                    connectionString = this.comboBox_connectStr.Text;
                }
                else
                {
                    // 選択されてなければ終了
                    if (this.comboBox_cdbsFileList.SelectedIndex == -1)
                    {
                        windowEnabled("接続文字列を選択してください");
                        return;
                    }
                    connectionString = Bis.GetFileText(Path.Combine(Define.UserOutCdbsDirFullPath, this.comboBox_cdbsFileList.Text));

                }

                // Excel出力用のフォルダ作成
                if (!Directory.Exists(Path.GetDirectoryName(this.textBox_excelFullPath.Text)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(this.textBox_excelFullPath.Text));
                }

                ///// DBよりデータ出力
                Define.ErrorCode errorCode = Define.ErrorCode.Success;
                try
                {
                    errorCode = Bis.ExecuteDbToFile(app.DbType, connectionString, sql, this.textBox_excelFullPath.Text);
                    // 出力成功時
                    if (errorCode == Define.ErrorCode.Success)
                    {
                        if (this.checkBox_isOpenExcel.Checked)
                        {
                            System.Diagnostics.Process.Start(this.textBox_excelFullPath.Text);
                        }
                        else
                        {
                            windowEnabled(Define.ErrorMessage(errorCode));
                        }
                    }
                }
                catch (STEException ex)
                {
                    windowEnabled(ex.ErrorMassage + "\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                    return;
                }
                catch (Exception ex)
                {
                    windowEnabled(ex.Message + "\r\n" + ex.StackTrace);
                    return;
                }
            }
            catch (STEException ex)
            {
                windowEnabled(ex.ErrorMassage + "\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                return;
            }
            catch (Exception ex)
            {
                windowEnabled(ex.Message + "\r\n" + ex.StackTrace);
                return;
            }

            windowEnabled();
            return;
        }

        private void toggleForm(bool _enabled)
        {
            this.Enabled = _enabled;
        }

        /// <summary>
        /// Windowを実行状態にする　メッセージがあれば表示
        /// </summary>
        /// <param name="_message"></param>
        private void windowEnabled(string _message = null)
        {
            if (!string.IsNullOrEmpty(_message))
            {
                MessageBox.Show(_message);
            }
            toggleForm(true);
            return;
        }

        /// <summary>
        /// app.configに設定値保存
        /// </summary>
        private void appConfigSave()
        {
            app = ToolSettingModel.Load();
            app.ExcelFullPath = this.textBox_excelFullPath.Text;
            app.SqlString = this.textBox_sql.Text;
            app.DbType = (this.comboBox_dbType.SelectedIndex == -1 ? Define.DatabaseType.SqlServer : (Define.DatabaseType)this.comboBox_dbType.SelectedIndex);
            app.SqlType = (this.radioButton_sql_input.Checked ? Define.ExecuteSqlType.Input : Define.ExecuteSqlType.OutFile);
            app.ConnectionType = (this.radioButton_connStr_input.Checked ? Define.ExecuteConnType.Input : Define.ExecuteConnType.OutFile);
            app.IsOpenExcel = this.checkBox_isOpenExcel.Checked;

            #region 接続文字列履歴
            // 履歴内に同じものが含んでいれば、削除する（先頭に持ってくるため）
            if (app.ConnectionStringHistory.Contains(this.comboBox_connectStr.Text))
            {
                app.ConnectionStringHistory.Remove(this.comboBox_connectStr.Text);
            }
            // 接続文字列履歴が10件あれば、最後のものを削除する
            else if (app.ConnectionStringHistory.Count >= HISTORY_MAX)
            {
                app.ConnectionStringHistory.RemoveRange(HISTORY_MAX - 1, (app.ConnectionStringHistory.Count - HISTORY_MAX + 1));
            }
            // 接続文字列を一番上にする
            app.ConnectionStringHistory.Insert(0, this.comboBox_connectStr.Text);
            #endregion

            app.Save();
        }

        /// <summary>
        /// app.configから設定値読み込み
        /// </summary>
        private void appConfigRoad()
        {
            app = ToolSettingModel.Load();
            this.textBox_excelFullPath.Text = app.ExcelFullPath;
            this.textBox_sql.Text = app.SqlString.Replace("\n", "\r\n").Replace("\r\r", "\r");
            this.checkBox_isOpenExcel.Checked = app.IsOpenExcel;

            if (app.SqlType == Define.ExecuteSqlType.Input)
            {
                this.radioButton_sql_input.Checked = true;
            }
            else
            {
                this.radioButton_sql_out.Checked = true;
            }

            if (app.ConnectionType == Define.ExecuteConnType.Input)
            {
                this.radioButton_connStr_input.Checked = true;
            }
            else
            {
                this.radioButton_connStr_output.Checked = true;
            }

            this.comboBox_connectStr.Items.AddRange(app.ConnectionStringHistory.ToArray());
            if (this.comboBox_connectStr.Items.Count > 0)
            {
                this.comboBox_connectStr.SelectedIndex = 0;
            }
        }

        private void button_excelSansyo_Click(object sender, EventArgs e)
        {
            string excelFile = this.textBox_excelFullPath.Text;
            //OpenFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめに表示されるフォルダを指定する
            if (string.IsNullOrEmpty(excelFile))
            {
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(excelFile)))
                {
                    sfd.InitialDirectory = Path.GetDirectoryName(excelFile);
                }
                else
                {
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                }
            }
            catch
            {
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            sfd.Filter = getDialogFilterString();
            sfd.FilterIndex = 0;
            sfd.Title = "ファイルの保存先";
            sfd.RestoreDirectory = true;
            sfd.CheckFileExists = false;
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                this.textBox_excelFullPath.Text = sfd.FileName;
            }
        }

        private string getDialogFilterString()
        {
            StringBuilder result = new StringBuilder();
            foreach (Define.OutFileType item in Enum.GetValues(typeof(Define.OutFileType)))
            {
                if (result.Length != 0) { result.Append("|"); }
                result.Append(Define.GetOutFileTypeString(item) + "ファイル");
                result.Append(" (*" + Define.GetOutFileTypeExt(item) + ")");
                result.Append("|*" + Define.GetOutFileTypeExt(item));
            }

            return result.ToString();
        }

        private void outSqlKanri_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "アプリケーション終了後、以下のフォルダに遷移します\r\n"
                + Define.UserOutSqlDirFullPath
                + "\r\n\r\nそのフォルダ内にSQLファイルを配置し、アプリケーションを再起動してください\r\n"
                + "SQLファイルが一覧で表示されます"
            );
        }

        private void textBox_sql_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                textBox_sql.SelectAll();
        }

        private void ToolStripMenuItem_exitTool_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripMenuItem_openHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Define.MYPAGE_HELP_URL);
            }
            catch
            {
                windowEnabled("ヘルプを開くことができませんでした。以下のURLを入力してください。\r\n"
                    + Define.MYPAGE_HELP_URL);
            }
        }
    }
}
