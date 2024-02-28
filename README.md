# FGJsonCheckTool
feed-generatorにリクエストを送って返ってきたJSONをチェックするツールです。
![FGJsonCheckTool-v1 0 1-ss](https://github.com/sktm-blue/FGJsonCheckTool/assets/161000035/5fe04e98-ed4c-407f-a8b4-eceefaf260f7)

## 機能
JSONで列挙されているURIをDBに問い合わせ、投稿のテキストなどの情報を表示します。

## 前提条件
2024/2/24時点の公式feed-generatorでは投稿の本文等の詳細情報をDBに格納していません。
DBにtextカラムを作り、そこに本文を格納するよう実装することで本ツールを使用できます。
作成者のDBに合わせlang1,imageCountというカラムも読み込みますが、それらはなくても動作します。

## 使い方
1. feed-generatorで生成されたDBファイルをWindows環境に準備します。
2. このツールを起動し、[参照...]ボタンを押してDBファイルを選択します。
3. 以下の情報を入力して[URI生成]ボタンを押します。
   - [プロトコル]欄に「http」か「https」
   - [ホスト]欄に「localhost:3000」かfeed-generatorが稼働しているホスト名
   - [DID]欄にfeed-generatorの.envファイルに記述したFEEDGEN_PUBLISHER_DID
   - [shortname]欄にalgos/*.tsに記述したshortname
4. URI欄にURIが表示されたら[ブラウザを開く]ボタンを押します。
5. feed-generatorが正常に動作していればJSONが表示されるため、中央のテキストボックスにコピペします。
6. [解析する]ボタンを押します。投稿の一覧が下部のリストビューに表示されます。
またその後[cursorを付けてURI生成]ボタンを押すと、次の投稿一覧を取得するためのURIが生成されます。

## feed-generatorとは
Bluesky公式が公開しているフィードジェネレーター(タイムライン製造機)です。  
https://github.com/bluesky-social/feed-generator  
  
feed-generatorの使用法については以下のサイトを参考にさせて頂いています。  
feed-generatorでBlueskyのカスタムフィードを作ろう  
https://blog.estampie.work/archives/2972  
feed-generatorを読む  
https://scrapbox.io/Bluesky/feed-generator%E3%82%92%E8%AA%AD%E3%82%80

## 開発環境
- Visual Studio Community 2022
- .NET 8
- C#

## 使用パッケージ
- Microsoft.Data.Sqlite.Core
- SQLitePCLRaw.bundle_e_sqlite3

## 更新履歴
- 1.0.1(2024/02/28) 
  - 解析結果をリストビューで表示するよう変更
  - URI生成機能追加
  - URIを規定のブラウザで開く機能追加
- 1.0.0(2024/02/24)
  - 初版

## 作成者
さかとも(Bluesky : https://bsky.app/profile/sktm.blue)
