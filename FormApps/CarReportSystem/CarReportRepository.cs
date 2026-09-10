using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;
using System.IO;
using Microsoft.Data.Sqlite;

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
                Mekar =(CarReport.MakerGroup)reader.GetInt32(3),
                CarName = reader.GetString(4),
                Report =reader.GetString(5),
                Picture = reader.IsDBNull(6)
                             ? null : BytesToImage(reader.GetFieldValue<byte[]>(6))
            });
        }
        return reports;
    }


    // ImageをSQLiteへ保存できるbyte[]へ変換する
    private static byte[]? ImageToBytes(Image? image) {
        if (image is null) return null;

        using var stream = new MemoryStream();
        // DBへはPNG形式で保存
        image.Save(stream, ImageFormat.Png);
        return stream.ToArray();
    }

    // SQLiteのBLOB（byte[]）をImageへ変換する
    private static Image BytesToImage(byte[] data) {
        using var stream = new MemoryStream(data);
        using var image = Image.FromStream(stream);
        // MemoryStream破棄後も利用できるようBitmapとしてコピーする。
        return new Bitmap(image);
    }



    //商品を一件追加するCreate（Insert）に相当する
    //戻り値として自動採番されたIdを探す
    public int Add(CarReport report) {
        //接続オブジェクトを生成
        using var connection = Database.GetConnection();

        //DBを開く
        connection.Open();

        //SQLを実行するためのコマンドオブジェクトを作る
        using var command = connection.CreateCommand();

        command.CommandText =
             """
            INSERT INTO CarReports
            (Date, Author, Maker, CarName, Report, Picture)
            VALUES
            ($date, $author, $maker, $carName, $report, $picture);

            SELECT last_insert_rowid();
            """;

        command.Parameters.AddWithValue("$date", report.Date.ToString("yyyy-MM-dd",CultureInfo.InvariantCulture));
        command.Parameters.AddWithValue("$author", report.Author);
        command.Parameters.AddWithValue("$maker", report.Mekar);
        command.Parameters.AddWithValue("$carName",report.CarName);
        command.Parameters.AddWithValue("$report", report.Report);

        byte[]? pictureData = ImageToBytes(report.Picture);

        var pictureParameter = command.Parameters.Add("$picture", SqliteType.Blob);
        if(pictureData is not null) {
            pictureParameter.Value = pictureData;
        }else {
            pictureParameter.Value = DBNull.Value;
        }


        //一つの値返すSQLを実行する
        var result = command.ExecuteScalar();

        if (result is null)
            throw new InvalidOperationException("登録したカーレポートのIDを取得できませんでした。");

        //SQLiteのINTEGERはlongとして返るため、intへ変換する。
        return Convert.ToInt32((long)result);
    }

    public void Update(CarReport report) {
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
        command.Parameters.AddWithValue("$date", report.Date.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("$author", report.Author);
        command.Parameters.AddWithValue("$maker", report.Mekar);
        command.Parameters.AddWithValue("$carName", report.CarName);
        command.Parameters.AddWithValue("$report", report.Report);
        command.Parameters.AddWithValue("$picture",report.Picture != null? (object)ImageToBytes(report.Picture) : DBNull.Value);
        command.Parameters.AddWithValue("$id", report.Id);
        command.ExecuteNonQuery();
    }

    public void Delete(int id) {
        using var Connection = Database.GetConnection();
        Connection.Open();

        using var command = Connection.CreateCommand();
        command.CommandText =
            """
            DELETE FROM CarReports
            WHERE Id = $id;
            """;

        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

}
