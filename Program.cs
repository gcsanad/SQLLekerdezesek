using MySql.Data.MySqlClient;

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



string SQLLekerdezesKategoriakraRendezetten = "SELECT DISTINCT * FROM `termékek` WHERE Ár > (SELECT Ár FROM termékek WHERE Ár = (SELECT MAX(Ár) FROM termékek WHERE Kategória LIKE 'winchester%' AND Gyártó LIKE 'seagate%')) AND Kategória LIKE 'winchester%' ORDER BY termékek.Ár ASC;";

MySqlCommand SQLparancs = new MySqlCommand(SQLLekerdezesKategoriakraRendezetten, SQLKapcsolat);
MySqlDataReader eredmenyOlvaso = SQLparancs.ExecuteReader();


while (eredmenyOlvaso.Read())
{
    string szoveg = "";
    szoveg +=" | " + eredmenyOlvaso.GetString("Cikkszám") + " | ";
    szoveg += eredmenyOlvaso.GetString("Kategória").PadRight(22) + " | ";
    szoveg += eredmenyOlvaso.GetString("Gyártó").PadRight(15) + " | ";
    szoveg += eredmenyOlvaso.GetString("Név").PadRight(74) + " | ";
    szoveg += eredmenyOlvaso.GetString("Ár").PadRight(7) + " FT" +" | ";
    szoveg += eredmenyOlvaso.GetString("Garidő").PadRight(2) + " | ";
    szoveg += eredmenyOlvaso.GetString("Készlet").PadRight(12) + " | ";
    szoveg += eredmenyOlvaso.GetString("Súly").PadRight(5) + " | ";
    Console.WriteLine(szoveg);
}
eredmenyOlvaso.Close();
SQLKapcsolat.Close();












/*
 * 1.FELADAT
 * 
string SQLLekerdezesKategoriakraRendezetten = "SELECT DISTINCT Gyártó FROM termékek GROUP BY Gyártó HAVING COUNT(Kategória = 'monitor') >= 40;";

MySqlCommand SQLparancs = new MySqlCommand(SQLLekerdezesKategoriakraRendezetten, SQLKapcsolat);
MySqlDataReader eredmenyOlvaso = SQLparancs.ExecuteReader();


while (eredmenyOlvaso.Read())
{
    Console.WriteLine(eredmenyOlvaso.GetString("Gyártó"));
}
eredmenyOlvaso.Close();
SQLKapcsolat.Close();
*/









