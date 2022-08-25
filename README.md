# 電話番号管理システム

## 概要
  社員を取得、登録、検索、修正、削除できる機能を持つロジッククラスを今回の研修で作成する

## 前回からの引継ぎ

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


### 初期処理について
- **データの流れ**<br>
SQLServer → (DAO) → Entity → DTO → Model

- **誰が何してるか**<br>
1. DAO: SQLServerから元のデータを取ってくる
2. Logic: <br>
  2-1. DAOへ上記の処理をするように指示をする<br>
  2-2. DAOからもらったデータをEntityに入れる<br>
  2-3. EntityのデータをDTOに入れる<br>

