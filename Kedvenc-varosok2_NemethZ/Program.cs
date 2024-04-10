using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;   //ezt betölteni

class Program
{
    static void Main(string[] args)
    {
        string connectionString, sqlStatement;
        MySqlConnection dbConnection;
        MySqlCommand sqlCommand;
        MySqlDataReader sqlReader;

        connectionString = "server=localhost;userid=root;password=;database=mo_telepulesek";
        dbConnection = new MySqlConnection(connectionString);
        dbConnection.Open();


        /*Hozzuk létre a lekérdezés parancsát kezelő `MySqlCommand` objektumot.
         *A parancs a `kvarosok` tábla teljes tartalmát kérdezze le.*/
        sqlStatement = "SELECT * FROM kvarosok;";
        sqlCommand = new MySqlCommand(sqlStatement, dbConnection);
        
        sqlReader = sqlCommand.ExecuteReader();

        /*ez addig fut amíg a read() metódus igaz értéket ad vissza*/
        while (sqlReader.Read())
        {
            /*soronként írja ki*/
            Console.WriteLine(sqlReader.GetString(0));      //string mert szöveg
            Console.WriteLine(sqlReader.GetString(1));      //string mert szöveg
            Console.WriteLine(sqlReader.GetInt32(2));       //mert ez évszám
            Console.WriteLine("");
            /*összefűzve ugyanaz egy kiírásba:*/
            Console.WriteLine("Név: " + sqlReader.GetString(0) + ", megye: " + sqlReader.GetString(1) + ", hozzáadás éve: " + sqlReader.GetInt32(2));
            Console.WriteLine("");
        }


        /*Adatok kiíratása táblázatos formában*/
        Console.WriteLine("\nAdatok táblázatos formában:");
        Console.WriteLine(sqlReader.GetName(0) + "\t" + sqlReader.GetName(1) + "\t" + sqlReader.GetName(2));

        while (sqlReader.Read())
        {
            Console.WriteLine(sqlReader.GetString(0) + "\t" + sqlReader.GetString(1) + "\t" + sqlReader.GetInt32(2));
        }


    dbConnection.Close();

        Console.ReadKey();
    }
}
