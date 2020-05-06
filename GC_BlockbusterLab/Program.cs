using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace GC_BlockbusterLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blockbuster.");
            Blockbuster lastAlaskanBlockbuster = new Blockbuster();
            lastAlaskanBlockbuster.CheckOut();
        }
    }
}
