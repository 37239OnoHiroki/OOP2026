using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarReportSystem;

public class CarReportRepository 
    {
    //全商品を取得するRead（SELECT）を担当する
    public List<CarReport> GetAll() {

        var reports = new List<CarReport>();

        using var connection = Database.GetConnection();
        connection.Open();

        //SQLを実行するためのコマンドオブジェクトを作る
        using var command = connection.CreateCommand();

        //Productsテーブルを作るSQL
        command.CommandText =
            """
            SELECT Id, Date, Author, Maker, CarName, Report, Picture
            FROM CarReports
            ORDER BY Id;
            """;
        //SELECTを実行し、複数行の検索結果を読み取る
        using var reader = command.ExecuteReader();

        while (reader.Read()) {
            reports.Add(new CarReport {
                Id = reader.GetInt32(0), 
                Date = DateTime.ParseExact(
                    reader.GetString(1),
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture),

                Author = reader.GetString(2),
                //
                Makar =(CarReport.MakerGroup)reader.GetInt32(3),
                CarName = reader.GetString(4),
                Report =reader.GetString(5),
                Picture = reader.IsDBNull(6)
                             ? null : BytesToImage(reader.GetFieldValue<byte[]>(6))
            });
        }
        return reports;
    }

    //商品を一件追加するCreate（Insert）に相当する
    //戻り値として自動採番されたIdを探す
    public int Add(CarReport carReport) {
        //接続オブジェクトを生成
        using var connection = Database.GetConnection();

        //DBを開く
        connection.Open();

        //SQLを実行するためのコマンドオブジェクトを作る
        using var command = connection.CreateCommand();

        command.CommandText =
             """
            INSERT INTO Products CarReports
            (Date, Author, Maker, CarName, Report, Picture)
            VALUES
            ($date, $author, $maker, $carName, $report, $picture)

            SELECT last_insert_rowid();
            """;
        //一つの値返すSQLを実行する
        var result = command.ExecuteScalar();

        if (result is null)
            throw new InvalidOperationException("登録した商品のIDを取得できませんでした。");

        //SQLiteのINTEGERはlongとして返るため、intへ変換する。
        return Convert.ToInt32((long)result);
    }

    public void Update(CarReport product) {
        //接続オブジェクトを生成
        using var connection = Database.GetConnection();
        connection.Open();
        using var command = connection.CreateCommand();

        command.CommandText =
             """
            UPDATE CarReports
            SET Date = $date, Author = $author, Maker = $maker,
            CarName = $carName, Report = $report, Picture = $picture
 
            WHERE Id = $id;
            """;
        //変更件数が０なら対象が存在しない
        if (command.ExecuteNonQuery() == 0)
            throw new InvalidOperationException("修正対象の商品が見つかりませんでした。");
    }

    public void Delete(int id) {
        using var Connection = Database.GetConnection();
        Connection.Open();

        using var command = Connection.CreateCommand();
        command.CommandText =
            """
            DELETE FROM Products
            WHERE Id = $id;
            """;

        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }
}
