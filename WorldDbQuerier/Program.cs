using System;
using MySql.Data.MySqlClient;

namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.3";
        static int exit = 0;

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
            while(exit == 0)
            {
                Console.WriteLine("Wat wilt u zien?");
                Console.WriteLine("1. Het aantal landen aanwezig in de database.");
                Console.WriteLine("2. Een lijst met alle landen aanwezig in de database.");
                Console.WriteLine("3. exit");

                switch(Console.ReadLine())
                {
                    case "1":
                        Count();
                        break;
                    case "2":
                        Readr();
                        break;
                    case "3":
                        exit = 1;
                        break;

                }
            }
           
            //Console.WriteLine("Wat wilt u zien?");
            //Console.WriteLine("1. Het aantal landen aanwezig in de database.");
            //Console.WriteLine("2. Een lijst met alle landen aanwezig in de database.");
            //string keuze = Console.ReadLine();
            //if (keuze == "1")
            //{
            //    Count();
            //}
            //else if(keuze == "2")
            //{
            //    Readr();
            //}

            

        }

        static void Count()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=immapwd;";

            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "SELECT count(Country.name) from world.Country";




            con.Open();


            Console.WriteLine(Convert.ToString(cmd1.ExecuteScalar()));
        }

        static void Readr()
        {
            MySqlConnection conn = new MySqlConnection();

            conn.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=immapwd;";

            conn.Open();

            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select * from world.Country";

            MySqlDataReader rdr = cmd2.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[1]);
            }
        }

        }
    }

