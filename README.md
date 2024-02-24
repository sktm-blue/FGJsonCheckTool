# FGJsonCheckTool
feed-generatorにリクエストを送って返ってきたJSONをチェックするツールです。
![FGJsonCheckTool_image](https://github.com/sktm-blue/FGJsonCheckTool/assets/161000035/1ec83a7b-1daa-49b0-b83e-9e1789bfb8a0)

## 機能
JSONで列挙されているURIをDBに問い合わせ、投稿のテキストを表示します。

## 使い方
1. feed-generatorで生成されたDBファイルをWindows環境に準備します。
2. このツールを起動し、[参照...]ボタンを押してDBファイルを選択します。
3. https://{FEEDGEN_HOSTNAME}/xrpc/app.bsky.feed.getFeedSkeleton?feed=at://{FEEDGEN_PUBLISHER_DID}/app.bsky.feed.generator/{algos/*.tsに記述したshortname}にアクセスして表示されたJSONを上部のテキストボックスにコピペします。
4. [解析する]ボタンを押します。投稿のテキストが下部のテキストボックスに表示されます。

## feed-generatorとは
Bluesky公式が公開しているフィードジェネレーター(タイムライン製造機)です。  
https://github.com/bluesky-social/feed-generator  
  
feed-generatorの使用法については以下のサイトを参考にさせて頂いています。  
feed-generatorでBlueskyのカスタムフィードを作ろう  
https://blog.estampie.work/archives/2972  
feed-generatorを読む  
https://scrapbox.io/Bluesky/feed-generator%E3%82%92%E8%AA%AD%E3%82%80

## 開発環境
* Visual Studio Community 2022
* .NET 8
* C#

## 使用パッケージ
* Microsoft.Data.Sqlite.Core
* SQLitePCLRaw.bundle_e_sqlite3  
ビルドできない場合は上記2つをNuGetパッケージマネージャーからインストール

## 作成者
さかとも(Bluesky : https://bsky.app/profile/sktm.blue)
