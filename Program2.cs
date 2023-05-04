using MySql.Data.MySqlClient;

Console.WriteLine("Kérem a kategóriát!");
String kategoria = Console.ReadLine();

string kapcsolatLeiro = "datasource=127.0.0.1;port=3306;database=hardver;username=root;password=;charset=utf8;";
MySqlConnection SQLKapcsolat = new MySqlConnection(kapcsolatLeiro);

try
{
    SQLKapcsolat.Open();
}
catch (MySqlException hiba)
{
    Console.WriteLine(hiba.Message);
    Environment.Exit(1);
}



string SQLLekerdezes = "SELECT Gyártó, COUNT(*) AS darabSzam, MAX(Ár) AS maxAr, AVG(Ár) AS Atlag FROM termékek" +
                        $"WHERE kategória = '{kategoria}";

MySqlCommand SQLparancs = new MySqlCommand(SQLLekerdezes, SQLKapcsolat);
MySqlDataReader eredmenyOlvaso = SQLparancs.ExecuteReader();


while (eredmenyOlvaso.Read())
{
    Console.WriteLine(eredmenyOlvaso.GetString("Gyártó").PadRight(30,'.'));
    Console.WriteLine(eredmenyOlvaso.GetString("darabSzam").PadLeft(4, '_')+" db");
    Console.WriteLine(eredmenyOlvaso.GetString("maxAr").PadLeft(20)+" FT");
    string atlagAr = $"{eredmenyOlvaso.GetDouble("Atlag")}";
    Console.WriteLine(atlagAr.PadLeft(15)+"Ft");

}
eredmenyOlvaso.Close();
SQLKapcsolat.Close();