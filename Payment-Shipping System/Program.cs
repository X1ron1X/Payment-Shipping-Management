using System;

namespace Payment_Shipping_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ADDRESS");

            Console.WriteLine("Full Name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Phone Number: ");
            string pnum = Console.ReadLine();
            Console.WriteLine("Region: ");
            string reg = Console.ReadLine();
            Console.WriteLine("Province: ");
            string prov = Console.ReadLine();
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            Console.WriteLine("Barangay: ");
            string brgy = Console.ReadLine();
            Console.WriteLine("Postal Code: ");
            string pcode = Console.ReadLine();
            Console.WriteLine("Street Name, Building, House No.: ");
            string sbh = Console.ReadLine();
        }
    }
}
