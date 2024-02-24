using System.Configuration;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;

namespace FGJsonCheckTool
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fileNameTextBox.Text = ConfigurationManager.AppSettings.Get("dbfile");
        }

        // 「解析する」ボタン押下時の動作
        private void button1_Click(object sender, EventArgs e)
        {
            // テキストボックスからJSONを読み込む
            string jsonStr = jsonTextBox.Text;

            // JSONのデシリアライズ
            Data jsonData = new Data();
            jsonData = JsonSerializer.Deserialize<Data>(jsonStr);

            // cursorを表示
            outputTextBox.Text = "cursor = " + jsonData.cursor + "\r\n";
            // postを表示(テスト用)
            //foreach (FeedItem feedItem in jsonData.feed)
            //{
            //    textBox2.Text += "post = " + feedItem.post + "\r\n";
            //}

            // 投稿を表示
            using (var connection = new SqliteConnection("Data Source=" + fileNameTextBox.Text))
            {
                connection.Open();

                foreach (FeedItem feedItem in jsonData.feed)
                {
                    // SELECT文構築
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                        SELECT text
                        FROM post
                        WHERE uri = $uri
                        ";
                    command.Parameters.AddWithValue("$uri", feedItem.post);

                    // SQLを実行し、テキストボックスに出力
                    outputTextBox.Text += "----------\r\n";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string text = reader.GetString(0);
                            outputTextBox.Text += text + "\r\n";
                        }
                    }
                }



            }
        }

        // 「参照...」ボタン押下時の動作
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                fileNameTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // 設定の保存
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                string key = "dbfile";
                if (settings[key] == null)
                {
                    settings.Add(key, fileNameTextBox.Text);
                }
                else
                {
                    settings[key].Value = fileNameTextBox.Text;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }

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
