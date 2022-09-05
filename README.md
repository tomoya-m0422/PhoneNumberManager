# 電話番号管理システム

## 概要
  社員を取得、登録、検索、修正、削除できる機能を持つロジッククラスを今回の研修で作成する

## 前回からの引継ぎ
- DIのせいでpostmanが動かなかったらしい
- 検索機能は完成
- SQL文の向上(EditDaoは完了)を行う
- Editに関して入力値をEntityやDTOに変換していないので行う
- 今週中にはフロントに入りたい(テストあるけど...)

## 今後の予定
- 可能であればDepartment,Companyの新規登録機能も付けてみる
- DepartmentTBの見直し(Companyと紐づけるか)

## 作成するAPI
- **一覧取得API** <br>
  社員名、所属部門、メモを引数として受け取り、それらを含む社員をPersonテーブルから検索し、Personクラスのリストにして返却する。
  引数をnullにした場合は、その項目の条件を無視して検索する。
- **詳細取得API** <br>
  社員番号を引数で受け取り、該当する社員をPersonテーブルから取得し、Personクラスに格納して返却する。
- **新規登録API** <br>
  入力した項目をPersonクラスで受け取り、SQL ServerのPersonテーブルに登録する。
- **修正API** <br>
　Personクラスを引数で受け取り、Personテーブルの該当する社員を更新する。
- **削除API** <br>
  社員番号を引数っとして受け取り、該当する社員をPersonから削除する。

## Angular使いかた<br>
- cdでフォルダまで移動
- npm run start
- GoogleどうのこうのはNo
- なんやかんやで動き出す

### 初期処理について(一覧取得API)
- **データの流れ**<br>
SQLServer → (DAO) → Entity → DTO → Model

- **誰が何してるか**<br>
1. DAO: SQLServerから元のデータを取ってくる
2. Logic: <br>
  2-1. DAOへ上記の処理をするように指示をする<br>
  2-2. DAOからもらったデータをEntityに入れる<br>
  2-3. EntityのデータをDTOに入れる<br>
3. Service:<br>
  3-1. Logicに上記の処理をするように指示<br>
  3-2. DTOのデータを返す(?)<br>
4. Controller:<br>
  4-1. Serviceに上記の処理をするように指示<br>
  4-2. DTOのデータをModelに入れる<br>

