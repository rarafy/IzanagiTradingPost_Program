# 新トレード板
<img src="https://user-images.githubusercontent.com/33755507/90413278-389c7180-e0e9-11ea-8e55-3077c0e63137.PNG" width="320px">

クライアント → [新トレード板（クライアント）](https://github.com/rarafy/IzanagiTradingPost)

## 概要
イザナギオンラインのトレード用アプリ「新トレード板」のプログラムです。

オープンソースではありますが、既に公開されているプログラムを無理に改変・クラッキング等はせず、変更してほしい部分はプログラムを送ってください（無用な混乱を避けるため）。


## 必要なプログラム
- Unity Editor（2019.3.11f1）
  - Unity Hub（※普通にUnityをインストールすれば既定でついてくるはずです。）

### 注意点
Unity Editorのバージョンは **必ず2019.3.11f1** にしてください。

最新版(2020.x.x)では動作しないことがあります。


## 開発環境
- OS：Windows 10 Pro
- CPU：Intel Xeon CPU E5-1650 v4 @3.60GHz
- メモリ：KingSton 16GB Module - DDR4 2400MHz Server Premier x2
- GPU：NVIDIA Quadro M2000

Windows搭載のパソコンなら問題なく動作すると思います。

<br><br>

## ドキュメント
計37枚。

- 基本設計・・・A,B1～B4 計5枚

- プログラム・・・C1～D2 計9枚

- 追加機能～単体・結合テスト・・・D3～D16 計12枚

- 追加機能～総合テスト・・・E1～E6 計6枚

- アップデート・・・E7,F1～F3 計4枚

<br>

### 基本設計(要件定義)
<img src="https://user-images.githubusercontent.com/33755507/91378900-783b2a00-e85c-11ea-933b-6503713baf82.jpg" width="320px"><img src="https://user-images.githubusercontent.com/33755507/91378902-78d3c080-e85c-11ea-9f20-c7701c1ad492.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378903-796c5700-e85c-11ea-93a2-fc4b2d8377fb.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378907-796c5700-e85c-11ea-84f6-ef1b1d50b050.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378911-7a04ed80-e85c-11ea-942e-aeb43d594845.jpg" width="320px">

※補足①

自分だけ分かれば良いので雑ですが、実際の仕事では要求定義書・要件定義書というのが有って、
さらに、要件定義はエンドユーザー用の"業務要件"とプログラマ用の"システム要件"に分けられます。

<br>

※補足②

今回の場合、

- 問題点
  - Lobiはログがすぐに流れてしまう。また、相場感がつかみにくい。
  - 露店広場は欲しいアイテムを探すのが困難。

ということなので、

- 解決方法
  - アイテムは一覧表示
  - 検索機能を付ける
  - ソート機能を付ける
  
ことで問題の解消を図っています。

<br>

### プログラム(製造)
<img src="https://user-images.githubusercontent.com/33755507/91378914-7a9d8400-e85c-11ea-8d00-ddb9886b51b5.jpg" width="320px"><img src="https://user-images.githubusercontent.com/33755507/91378916-7b361a80-e85c-11ea-9820-419f140ab8fd.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378918-7bceb100-e85c-11ea-84ec-a63619daea20.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378846-678ab400-e85c-11ea-9bc2-01fd99cad86f.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378851-68bbe100-e85c-11ea-8c07-5f4fda5f1c52.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378853-69547780-e85c-11ea-85ac-4e3addaadbb9.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378855-69ed0e00-e85c-11ea-8eda-830cf66dcd65.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378859-6a85a480-e85c-11ea-86d6-62a83a7b9d33.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378860-6b1e3b00-e85c-11ea-91fb-462c9170b02b.jpg" width="320px">

### 追加機能(単体・結合テスト)
<img src="https://user-images.githubusercontent.com/33755507/91378863-6bb6d180-e85c-11ea-8fbf-febd9fb94b72.jpg" width="320px"><img src="https://user-images.githubusercontent.com/33755507/91378865-6c4f6800-e85c-11ea-8b3d-7644bfbe1a4d.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378867-6ce7fe80-e85c-11ea-8897-7402c4afbffe.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378869-6d809500-e85c-11ea-940b-9428934aba6e.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378870-6e192b80-e85c-11ea-99cb-e047f1e5d80c.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378871-6eb1c200-e85c-11ea-8253-2799f08a89fd.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378872-6f4a5880-e85c-11ea-80d8-39fcca73b3b1.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378874-6fe2ef00-e85c-11ea-8838-e087ba990498.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378875-6fe2ef00-e85c-11ea-9567-50cc5ba8e341.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378876-707b8580-e85c-11ea-95d5-f2be5208c5a0.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378877-71141c00-e85c-11ea-956b-f46aae983939.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378880-71acb280-e85c-11ea-9a30-f57a50e7312b.jpg" width="320px">

### 追加機能(総合テスト)
<img src="https://user-images.githubusercontent.com/33755507/91378881-72454900-e85c-11ea-8868-b173401bc3ac.jpg" width="320px"><img src="https://user-images.githubusercontent.com/33755507/91378882-72dddf80-e85c-11ea-92e4-e70f80086c9b.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378883-73767600-e85c-11ea-81bd-ff23fdbcb279.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378884-740f0c80-e85c-11ea-978a-3b7318d171e4.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378886-74a7a300-e85c-11ea-9f7e-82e673c54a69.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378889-75403980-e85c-11ea-9e9f-97410a00d0fa.jpg" width="320px">

### アップデート(保守作業)
<img src="https://user-images.githubusercontent.com/33755507/91378892-75d8d000-e85c-11ea-9d28-485042508c74.jpg" width="320px"><img src="https://user-images.githubusercontent.com/33755507/91378894-75d8d000-e85c-11ea-97cd-63a192eab352.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378896-76716680-e85c-11ea-9710-8f968f51b73a.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378897-7709fd00-e85c-11ea-95da-e2ea5f8a8a36.jpg" width="320px">
<img src="https://user-images.githubusercontent.com/33755507/91378898-77a29380-e85c-11ea-800b-d1db2e497488.jpg" width="320px">




