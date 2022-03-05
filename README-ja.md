# Unity-LogTranslation
unityのコンソールログを翻訳するエディタ拡張  
(Editor extensions to translate unity console logs)

## 利用手順

## ①「LogTranslation」ファイルをダウンロード
## ② 利用したいUnityプロジェクトのAssetsフォルダ配下に配置
## ③ Deepl API で登録を行い、「認証キー」を取得
https://www.deepl.com/ja/pro/change-plan#developer

## ④上部のタブに追加された「LogTranslation/Setting」をクリック
![image](https://user-images.githubusercontent.com/84212805/156880496-e75344c9-4050-48fe-a328-af67e4ba91ad.png)

## ⑤ ③で取得した「認証キー」の入力と「翻訳先言語」を選択し、「決定」を押下
![image](https://user-images.githubusercontent.com/84212805/156880684-c6c5b3ac-20ba-4522-a423-664f58ff560c.png)

(設定の保存ファイルは、対象のプロジェクトフォルダ配下の「LogTranslationSettingSave/SettingValue.dat」に作成される)

## ⑥ Unityの再起動

## ⑦ ログに翻訳結果が出力されるようになる (通常のコメントログは対象外)
![image](https://user-images.githubusercontent.com/84212805/156881009-d82feae9-86e3-4bd0-92c4-90b46bcd1793.png)
