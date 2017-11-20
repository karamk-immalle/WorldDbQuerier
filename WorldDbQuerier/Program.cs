using System;
using MySql.Data.MySqlClient;

namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.4";
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
                Console.WriteLine("3. Zoek een land.");
                Console.WriteLine("4. exit");

                switch(Console.ReadLine())
                {
                    case "1":
                        Count();
                        break;
                    case "2":
                        Readr();
                        break;
                    case "3":
                        Search();
                        break;
                    case "4":
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
            string sql = "SELECT count(Country.name) from world.Country";
            MySqlCommand cmd1 = new MySqlCommand(sql, con);
            con.Open();
            Console.WriteLine(Convert.ToString(cmd1.ExecuteScalar()));
        }

        static void Readr()
        {
            MySqlConnection conn = new MySqlConnection();

            conn.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=immapwd;";

            conn.Open();
            string sql = "select * from world.Country";
            MySqlCommand cmd2 = new MySqlCommand(sql,conn);
            

            MySqlDataReader rdr = cmd2.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[1]);
            }
        }

        static void Search()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=immapwd;";
            con.Open();
            Console.WriteLine("Please enter the name of the country:");
            string country = Console.ReadLine();
            string sql = "SELECT * FROM world.Country where name = @Name";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@Name";
            param.Value = country;

            cmd.Parameters.Add(param);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("  ");
                Console.WriteLine(rdr["Code"] + ", " + rdr["Name"] + ", " + rdr["Continent"] + ", " + rdr["Region"] + ", " + rdr["SurfaceArea"] + ", " + rdr["IndepYear"] + ", " + rdr["Population"] + ", " + rdr["LifeExpectancy"] + ", " + rdr["GNP"] + ", " + rdr["GNPOld"] + ", " + rdr["LocalName"] + ", " + rdr["GovernmentForm"] + ", " + rdr["HeadOfState"] + ", " + rdr["Capital"] + ", " + rdr["Code2"] + ".");
                Console.WriteLine("  ");
            }

        }

        }
    }

