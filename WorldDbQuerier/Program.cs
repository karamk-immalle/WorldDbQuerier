using System;
using MySql.Data.MySqlClient;

namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.3";

        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                switch (args[0])
                {
                    case "-v":
                        Console.WriteLine("versie {0}", version);
                        break;
                    default:
                        Console.WriteLine("onbekende argument");
                        break;                           
                }
            }
            else
            {
                Console.WriteLine("hello world");
            }

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=immapwd;";

            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "SELECT count(Country.name) from world.Country";

            
            //cmd2.Connection = con;
            //cmd2.CommandText = "SELECT * FROM world.country";
            //MySqlDataReader rdr = cmd2.ExecuteReader();
            //while (rdr.Read())
            //{
            //    string city = (string)rdr["name"];


            //    Console.WriteLine(city);
            //}

            con.Open();
            //cmd.ExecuteScalar();

            


            Console.WriteLine("Wat wilt u zien?");
            Console.WriteLine("1. Het aantal landen aanwezig in de database.");
            Console.WriteLine("2. Een lijst met alle landen aanwezig in de database.");
            string keuze = Console.ReadLine();
            if (keuze == "1")
            {
                Console.WriteLine(Convert.ToInt32(cmd1.ExecuteScalar()));
            }
            else if(keuze == "2")
            {
                SimpleRead();
            }

            

        }

        public static void SimpleRead()
        {
            MySqlDataReader rdr = null;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=immapwd;";

            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM world.country");

            con.Open();

            rdr = cmd2.ExecuteReader();

            while (rdr.Read())
            {
                string city = (string)rdr["city"];

                Console.WriteLine(city);
            }
        }
    }
}
