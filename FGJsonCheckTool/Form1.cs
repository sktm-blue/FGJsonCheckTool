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
        // 画面を開く時の動作
        public Form1()
        {
            InitializeComponent();

            // 保存した設定を読み込んで画面に反映
            fileNameTextBox.Text = ConfigurationManager.AppSettings.Get("dbfile");
            protocolTextBox.Text = ConfigurationManager.AppSettings.Get("protocol");
            hostTextBox.Text = ConfigurationManager.AppSettings.Get("host");
            didTextBox.Text = ConfigurationManager.AppSettings.Get("did");
            shortNameTextBox.Text = ConfigurationManager.AppSettings.Get("shortName");
            
            // デフォルト設定
            if (protocolTextBox.Text.Length == 0) protocolTextBox.Text = "http";
            if (hostTextBox.Text.Length == 0) hostTextBox.Text = "localhost:3000";
        }

        // 「参照...」ボタン押下時の動作
        private void dbFileBrowseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                fileNameTextBox.Text = openFileDialog1.FileName;
            }
        }

        // 「URI生成」ボタン押下時の動作
        private void generateUriButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (protocolTextBox.Text.Length == 0)
                {
                    throw new Exception("プロトコル欄が空です。");
                }
                if (hostTextBox.Text.Length == 0)
                {
                    throw new Exception("ホスト欄が空です。");
                }
                if (didTextBox.Text.Length == 0)
                {
                    throw new Exception("DID欄が空です。");
                }
                if (shortNameTextBox.Text.Length == 0)
                {
                    throw new Exception("short name欄が空です。");
                }
                uriTextBox.Text = buildUri();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 「ブラウザで開く」ボタン押下時の動作
        private void openBrowserButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (uriTextBox.Text.Length == 0)
                {
                    throw new Exception("URI欄が空です。");
                }

                // 規定のブラウザでURIを開く
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

        // 「クリア」ボタン押下時の動作
        private void clearButton_Click(object sender, EventArgs e)
        {
            jsonTextBox.Clear();
            resultListView.Clear();
            cursorTextBox.Clear();
        }

        // 「解析する」ボタン押下時の動作
        private void analyzeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (jsonTextBox.Text.Length == 0)
                {
                    throw new Exception("JSONを入力してください。");
                }

                // テキストボックスからJSONを読み込む
                string jsonStr = jsonTextBox.Text;

                // JSONのデシリアライズ
                Data jsonData = new Data();
                jsonData = JsonSerializer.Deserialize<Data>(jsonStr);
                if (jsonData == null) 
                {
                    throw new Exception("JSONを正常に読み込めませんでした。");
                }

                // cursorを表示
                cursorTextBox.Text = jsonData.cursor;

                // 投稿を表示
                using (var connection = new SqliteConnection("Data Source=" + fileNameTextBox.Text))
                {
                    resultListView.Clear();

                    connection.Open();

                    // DBにカラム名が存在するか調べる
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
                        throw new Exception("必要なカラムがありません。");
                    }
                    string selectQuery = string.Join(",", selectQueryList);

                    // リストボックスにカラム追加
                    resultListView.Columns.Clear();
                    if (textFlag) resultListView.Columns.Add("text", 600);
                    if (langFlag) resultListView.Columns.Add("lang1", 60);
                    if (imageCountFlag) resultListView.Columns.Add("imageCount", 60);

                    // リストボックスの表示
                    foreach (FeedItem feedItem in jsonData.feed)
                    {
                        // SELECT文構築
                        var command2 = connection.CreateCommand();
                        command2.CommandText = "SELECT " + selectQuery + " FROM post WHERE uri = \"" + feedItem.post + "\";";

                        // SQLを実行し、テキストボックスに出力
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

        // 「cursorを付けてURI生成」ボタン押下時の動作
        private void generateUriWithCursorButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (protocolTextBox.Text.Length == 0)
                {
                    throw new Exception("プロトコル欄が空です。");
                }
                if (hostTextBox.Text.Length == 0)
                {
                    throw new Exception("ホスト欄が空です。");
                }
                if (didTextBox.Text.Length == 0)
                {
                    throw new Exception("DID欄が空です。");
                }
                if (shortNameTextBox.Text.Length == 0)
                {
                    throw new Exception("short name欄が空です。");
                }
                if (cursorTextBox.Text.Length == 0)
                {
                    throw new Exception("cursor欄が空です。");
                }
                uriTextBox.Text = buildUri(cursorTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 画面を閉じる時の動作
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // 設定の保存
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

        // URIを構築する関数
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
