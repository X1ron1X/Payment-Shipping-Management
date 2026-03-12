using address;
using AppService;
using DataService;
using System;
using System.Security.Principal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Payment_Shipping_System
{
    internal class Program
    {
        static Service App = new Service();
        static Data Data = new Data();
        static void Main(string[] args)
        {

            bool chose = addchoice();

            while (chose == true)
            {
                Console.WriteLine("[1] Payment Methods\n[2] Address");

                Console.Write("\nEnter(1/2): ");
                string opt1 = Console.ReadLine();

                if (opt1 == "1")
                {
                    addpayment();
                    addchoice();
                }
                else if (opt1 == "2")
                {
                    addaddress();
                    addchoice();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            }
        }

        static bool addchoice()
        {

            Console.Write("Do You Want to Add a ADDRESS(y/n): ");
            bool chose = false;
            string choice = Console.ReadLine();


            switch (choice)
            {

                case "y":
                    chose = true;
                    break;

                case "n":
                    chose = false;
                    break;

                default:

                    choice = Console.ReadLine();
                    break;
            }

            return chose;

        }

        static void addpayment()
        {
            Console.WriteLine("\nPAYMENT METHODS\n");
            Console.Write("\nCard Number: ");
            string cnum = Console.ReadLine();
            Console.Write("\nCard Holder Name: ");
            string chname = Console.ReadLine();
            Console.Write("\nExpiration Date(MM/YY): ");
            string edate = Console.ReadLine();
            Console.Write("\nCVV: ");
            string cvv = Console.ReadLine();
        }

        static void addaddress()
        {
            Console.WriteLine("\nADDRESS\n");
            Console.Write("\nFull Name: ");
            string fname = Console.ReadLine();
            Console.Write("\nFull ADDRESS\n(House No., Street, Barangay, City, Province, Region): ");
            string add = Console.ReadLine();
            Console.Write("\nPhone Number: ");
            string pnum = Console.ReadLine();
            Console.Write("\nPostal Code: ");
            string pcode = Console.ReadLine();

            ADD newAdd = new ADD { Name = fname, Address = add, PNumber = pnum, Pcode = pcode };

            Data.Add(newAdd);

            Console.WriteLine($"Successfully added user {newAdd.Name}");


        }
    }
}