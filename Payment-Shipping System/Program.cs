using Models;
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
        static DBData dbData = new DBData();
        static void Main(string[] args)
        {

            bool chose = addchoice();

            while (chose)
            {
                Console.WriteLine("[1] Payment Methods\n[2] Address");

                Console.Write("\nEnter(1/2): ");
                string opt1 = Console.ReadLine();

                if (opt1 == "1")
                {
                    addpayment();
                    chose = addchoice();
                }
                else if (opt1 == "2")
                {
                    addaddress();
                    chose = addchoice();
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

                    Console.WriteLine("Invalid Input");
                    break;
            }

            return chose;

        }

        static void addpayment()
        {
            Console.WriteLine("\nPAYMENT METHODS\n[1] Card\n[2] Bank Account\nGcash");
            Console.Write("\nEnter (1-3): ");
            string PM = Console.ReadLine();

            switch (PM) { 

                case "1":
                    Console.WriteLine("\nCARD\n");
                    Console.Write("\nFull Name: ");
                    string Fname = Console.ReadLine();
                    Console.Write("\nCard Number: ");
                    string cnum = Console.ReadLine();
                    Console.Write("\nExpiration Date(YYYY): ");
                    string edate = Console.ReadLine();
                    Console.Write("\nCVV: ");
                    string cvv = Console.ReadLine();
                    Card newCard = new Card { Name = Fname, CNumber = cnum, EDate = edate, CVV = cvv };
                    App.AddPayment(newCard);
                    Console.WriteLine($"Successfully added user {newCard.Name}");
                    break;
                case "2":
                    Console.WriteLine("\nBANK ACCOUNT\n");
                    Console.Write("\nAccount Holder Name: ");
                    string ahname = Console.ReadLine();
                    Console.Write("\nAccount Number: ");
                    string anum = Console.ReadLine();
                    Console.Write("\nBank Name: ");
                    string bname = Console.ReadLine();
                    
                    Bank newBank = new Bank { Holder = ahname, BNumber = anum, BName = bname };
                    App.AddPayment(newBank);
                    Console.WriteLine($"Successfully added user {newBank.Holder }");
                    break;
                case "3":
                    Console.WriteLine("\nGCASH\n");
                    Console.Write("\nGCash Account Name: ");
                    string gname = Console.ReadLine();
                    Console.Write("\nGCash Account Number: ");
                    string gnum = Console.ReadLine();
                    
                    Gcash newGCASH = new Gcash { Name = gname, GNumber = gnum };
                    App.AddPayment(newGCASH);
                    Console.WriteLine($"Successfully added user {newGCASH.Name}");
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;

            }
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

            App.Address(newAdd);

            Console.WriteLine($"Successfully added user {newAdd.Name}");


        }
    }
}