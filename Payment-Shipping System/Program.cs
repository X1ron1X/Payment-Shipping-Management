using System;

namespace Payment_Shipping_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Do You Want to Add a ADDRESS(y/n): ");
            bool chose = false;
            string choice = Console.ReadLine();

            

            Console.WriteLine("ADDRESS");

            Console.Write("\nFull Name: ");
            string fname = Console.ReadLine();
            Console.Write("\nPhone Number: ");
            string pnum = Console.ReadLine();
            Console.Write("\nRegion: ");
            string reg = Console.ReadLine();
            Console.Write("\nProvince: ");
            string prov = Console.ReadLine();
            Console.Write("\nCity: ");
            string city = Console.ReadLine();
            Console.Write("\nBarangay: ");
            string brgy = Console.ReadLine();
            Console.Write("\nPostal Code: ");
            string pcode = Console.ReadLine();
            Console.Write("\nStreet Name, Building, House No.: ");
            string sbh = Console.ReadLine();
        }

        static bool addchoice(bool chose, string choice){

            

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
    }
}
