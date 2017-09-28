﻿using System;

namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.1";

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
        }
    }
}
