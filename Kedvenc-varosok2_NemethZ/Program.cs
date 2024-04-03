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

        connectionString = "server=localhost;userid=root;password=;database=mo_telepulesek";
        dbConnection = new MySqlConnection(connectionString);
        dbConnection.Open();


        /*Hozzuk létre a lekérdezés parancsát kezelő `MySqlCommand` objektumot.
         *A parancs a `kvarosok` tábla teljes tartalmát kérdezze le.*/
        sqlStatement = "SELECT * FROM kvarosok;";
        sqlCommand = new MySqlCommand(sqlStatement, dbConnection);


        Console.ReadKey();
    }
}
