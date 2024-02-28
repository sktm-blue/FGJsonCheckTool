using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Security.Policy;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FGJsonCheckTool
{

    public partial class Form1 : Form
    {
        // ��ʂ��J�����̓���
        public Form1()
        {
            InitializeComponent();

            // �ۑ������ݒ��ǂݍ���ŉ�ʂɔ��f
            fileNameTextBox.Text = ConfigurationManager.AppSettings.Get("dbfile");
            protocolTextBox.Text = ConfigurationManager.AppSettings.Get("protocol");
            hostTextBox.Text = ConfigurationManager.AppSettings.Get("host");
            didTextBox.Text = ConfigurationManager.AppSettings.Get("did");
            shortNameTextBox.Text = ConfigurationManager.AppSettings.Get("shortName");
            
            // �f�t�H���g�ݒ�
            if (protocolTextBox.Text.Length == 0) protocolTextBox.Text = "http";
            if (hostTextBox.Text.Length == 0) hostTextBox.Text = "localhost:3000";
        }

        // �u�Q��...�v�{�^���������̓���
        private void dbFileBrowseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                fileNameTextBox.Text = openFileDialog1.FileName;
            }
        }

        // �uURI�����v�{�^���������̓���
        private void generateUriButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (protocolTextBox.Text.Length == 0)
                {
                    throw new Exception("�v���g�R��������ł��B");
                }
                if (hostTextBox.Text.Length == 0)
                {
                    throw new Exception("�z�X�g������ł��B");
                }
                if (didTextBox.Text.Length == 0)
                {
                    throw new Exception("DID������ł��B");
                }
                if (shortNameTextBox.Text.Length == 0)
                {
                    throw new Exception("short name������ł��B");
                }
                uriTextBox.Text = buildUri();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // �u�u���E�U�ŊJ���v�{�^���������̓���
        private void openBrowserButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (uriTextBox.Text.Length == 0)
                {
                    throw new Exception("URI������ł��B");
                }

                // �K��̃u���E�U��URI���J��
                ProcessStartInfo pi = new ProcessStartInfo()
                {
                    FileName = uriTextBox.Text,
                    UseShellExecute = true,
                };
                Process.Start(pi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // �u�N���A�v�{�^���������̓���
        private void clearButton_Click(object sender, EventArgs e)
        {
            jsonTextBox.Clear();
            resultListView.Clear();
            cursorTextBox.Clear();
        }

        // �u��͂���v�{�^���������̓���
        private void analyzeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (jsonTextBox.Text.Length == 0)
                {
                    throw new Exception("JSON����͂��Ă��������B");
                }

                // �e�L�X�g�{�b�N�X����JSON��ǂݍ���
                string jsonStr = jsonTextBox.Text;

                // JSON�̃f�V���A���C�Y
                Data jsonData = new Data();
                jsonData = JsonSerializer.Deserialize<Data>(jsonStr);
                if (jsonData == null) 
                {
                    throw new Exception("JSON�𐳏�ɓǂݍ��߂܂���ł����B");
                }

                // cursor��\��
                cursorTextBox.Text = jsonData.cursor;

                // ���e��\��
                using (var connection = new SqliteConnection("Data Source=" + fileNameTextBox.Text))
                {
                    resultListView.Clear();

                    connection.Open();

                    // DB�ɃJ�����������݂��邩���ׂ�
                    bool textFlag = false;
                    bool langFlag = false;
                    bool imageCountFlag = false;
                    var command = connection.CreateCommand();
                    command.CommandText = "PRAGMA table_info('post')";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader.GetString(1);
                            if (columnName == "text") textFlag = true;
                            if (columnName == "lang1") langFlag = true;
                            if (columnName == "imageCount") imageCountFlag = true;
                        }
                    }
                    List<string> selectQueryList = new List<string>();
                    if (textFlag) selectQueryList.Add("text");
                    if (langFlag) selectQueryList.Add("lang1");
                    if (imageCountFlag) selectQueryList.Add("imageCount");
                    if (selectQueryList.Count == 0)
                    {
                        throw new Exception("�K�v�ȃJ����������܂���B");
                    }
                    string selectQuery = string.Join(",", selectQueryList);

                    // ���X�g�{�b�N�X�ɃJ�����ǉ�
                    resultListView.Columns.Clear();
                    if (textFlag) resultListView.Columns.Add("text", 600);
                    if (langFlag) resultListView.Columns.Add("lang1", 60);
                    if (imageCountFlag) resultListView.Columns.Add("imageCount", 60);

                    // ���X�g�{�b�N�X�̕\��
                    foreach (FeedItem feedItem in jsonData.feed)
                    {
                        // SELECT���\�z
                        var command2 = connection.CreateCommand();
                        command2.CommandText = "SELECT " + selectQuery + " FROM post WHERE uri = \"" + feedItem.post + "\";";

                        // SQL�����s���A�e�L�X�g�{�b�N�X�ɏo��
                        using (var reader = command2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                List<string> itemList = new List<string>();
                                int readIndex = 0;
                                if (textFlag) itemList.Add(reader.GetString(readIndex++));
                                if (langFlag) itemList.Add(reader.GetString(readIndex++));
                                if (imageCountFlag) itemList.Add(reader.GetString(readIndex++));
                                resultListView.Items.Add(new ListViewItem(itemList.ToArray()));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // �ucursor��t����URI�����v�{�^���������̓���
        private void generateUriWithCursorButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (protocolTextBox.Text.Length == 0)
                {
                    throw new Exception("�v���g�R��������ł��B");
                }
                if (hostTextBox.Text.Length == 0)
                {
                    throw new Exception("�z�X�g������ł��B");
                }
                if (didTextBox.Text.Length == 0)
                {
                    throw new Exception("DID������ł��B");
                }
                if (shortNameTextBox.Text.Length == 0)
                {
                    throw new Exception("short name������ł��B");
                }
                if (cursorTextBox.Text.Length == 0)
                {
                    throw new Exception("cursor������ł��B");
                }
                uriTextBox.Text = buildUri(cursorTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ��ʂ���鎞�̓���
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // �ݒ�̕ۑ�
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                string[] keyArray = ["dbfile", "protocol", "host", "did", "shortName"];
                string[] valueArray = [fileNameTextBox.Text, protocolTextBox.Text, hostTextBox.Text, didTextBox.Text, shortNameTextBox.Text];
                for (int i = 0; i < keyArray.Length; i++)
                {
                    if (settings[keyArray[i]] == null)
                    {
                        settings.Add(keyArray[i], valueArray[i]);
                    }
                    else
                    {
                        settings[keyArray[i]].Value = valueArray[i];
                    }
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }

        }

        // URI���\�z����֐�
        private string buildUri(string cursor = "")
        {
            string uri = protocolTextBox.Text + "://";
            uri += hostTextBox.Text;
            uri += "/xrpc/app.bsky.feed.getFeedSkeleton?feed=at://";
            uri += didTextBox.Text;
            uri += "/app.bsky.feed.generator/";
            uri += shortNameTextBox.Text;
            if (cursor.Length > 0)
            {
                uri += "&cursor=";
                uri += cursor;
            }
            return uri;
        }

    }

    class Data
    {
        public string cursor { get; set; }
        public FeedItem[] feed { get; set; }
    }

    class FeedItem
    {
        public string post { get; set; }
    }

}
