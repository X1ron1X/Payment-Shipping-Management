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

            bool chose = runchoice();

            while (chose)
            {
                Console.WriteLine("[1] Add\n[2] View\n[3] Update");

                Console.Write("\nEnter(1-4): ");
                string opt1 = Console.ReadLine();

                if (opt1 == "1")
                {
                    addchoice();
                    chose = runchoice();
                }
                else if (opt1 == "2")
                {
                    viewchoice();
                    chose = runchoice();
                }
                else if (opt1 == "3")
                {
                    updatechoice();
                    chose = runchoice();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            }
        }

        static void addchoice()
        {
            Console.WriteLine("[1] Add Payment Methods\n[2] Add Address");
            Console.Write("\nEnter(1/2): ");
            string opt1 = Console.ReadLine();
            if (opt1 == "1")
            {
                Console.WriteLine("\nPAYMENT METHODS\n");
                addpayment();
            }
            else if (opt1 == "2")
            {
                Console.WriteLine("\nADDRESS\n");
                addaddress();
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        static void updatechoice()
        {
            Console.WriteLine("[1] Update Payment Methods\n[2] Update Address");
            Console.Write("\nEnter(1/2): ");
            string opt1 = Console.ReadLine();
            if (opt1 == "1")
            {
                Console.WriteLine("\nPAYMENT METHODS\n");
                UpdatePayment();
            }
            else if (opt1 == "2")
            {
                Console.WriteLine("\nADDRESS\n");
                UpdateAddress();
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        static void viewchoice()
        {
            Console.WriteLine("[1] View Payment Methods\n[2] View Address");
            Console.Write("\nEnter(1/2): ");
            string opt1 = Console.ReadLine();
            if (opt1 == "1")
            {
                Console.WriteLine("\nPAYMENT METHODS\n");
                ViewCards();
                ViewBanks();
                ViewGcash();
            }
            else if (opt1 == "2")
            {
                Console.WriteLine("\nADDRESS\n");
                Viewaddresses();
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        static bool runchoice()
        {

            Console.Write("Do You Want to Run the Program(y/n): ");
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
            Console.WriteLine("\nPAYMENT METHODS\n[1] Card\n[2] Bank Account\n[3] Gcash");
            Console.Write("\nEnter (1-3): ");
            string PM = Console.ReadLine();

            switch (PM)
            {

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
                    Console.WriteLine($"Successfully added user {newBank.Holder}");
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

        static void Viewaddresses()
        {
            int n = 1;
            var adds = App.GetAddresses();

            Console.WriteLine("\nADDRESS\n");

            if (adds.Count == 0)
            {
                Console.WriteLine("No Registered Address");
                return;
            }
            foreach (var add in adds)
            {
                Console.WriteLine($"{n}. \nName: {add.Name}\nAddress: {add.Address}\nPhone Number: {add.PNumber}\nPostal Code: {add.Pcode}");
                n++;
            }
        }

        static void ViewCards()
        {
            int n = 1;
            var cards = App.GetCards();

            Console.WriteLine("\nCARDS\n");

            if (cards.Count == 0)
            {
                Console.WriteLine("No Registered Card");
                return;
            }
            foreach (var card in cards)
            {
                Console.WriteLine($"{n}. \nName: {card.Name}\nCard Number: {card.CNumber}\nExpiration: {card.EDate}\nCVV: {card.CVV}");
                n++;
            }
        }

        static void ViewBanks()
        {
            int n = 1;
            var Banks = App.GetBanks();

            Console.WriteLine("\nBANKS\n");

            if (Banks.Count == 0)
            {
                Console.WriteLine("No Registered Bank Account");
                return;
            }
            foreach (var Bank in Banks)
            {
                Console.WriteLine($"{n}. \nName: {Bank.Holder}\nBank Number: {Bank.BNumber}\nBank Name: {Bank.BName}");
                n++;
            }
        }

        static void ViewGcash()
        {
            int n = 1;
            var gcash = App.GetGcash();

            Console.WriteLine("\nGCASH\n");

            if (gcash.Count == 0)
            {
                Console.WriteLine("No Registered Gcash Account");
                return;
            }
            foreach (var Gcash in gcash)
            {
                Console.WriteLine($"{n}. \nName: {Gcash.Name}\nGcash Number: {Gcash.GNumber}");
                n++;
            }
        }

        static void UpdatePayment()
        {
            Console.WriteLine("\nPAYMENT METHODS\n[1] Card\n[2] Bank Account\n[3] Gcash");
            Console.Write("\nEnter (1-3): ");
            string PM = Console.ReadLine();
            switch (PM)
            {
                case "1":
                    Console.WriteLine("\nCARD\n");
                    UpdateCard();
                    break;
                case "2":
                    Console.WriteLine("\nBANK ACCOUNT\n");
                    UpdateBank();
                    break;
                case "3":
                    Console.WriteLine("\nGCASH\n");
                    UpdateGcash();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        static void UpdateAddress()
        {
            var addresses = App.GetAddresses();

            if (addresses.Count == 0)
            {
                Console.WriteLine("No Address to update.");
                return;
            }

            Console.WriteLine("\nSelect Address to Update:\n");

            for (int i = 0; i < addresses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {addresses[i].Name}");
            }

            Console.Write("\nEnter number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 1 || choice > addresses.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }
            var selected = addresses[choice - 1];

            Console.WriteLine("\nEnter new details:\n");

            Console.Write("New Name: ");
            selected.Name = Console.ReadLine();

            Console.Write("New Address: ");
            selected.Address = Console.ReadLine();

            Console.Write("New Phone Number: ");
            selected.PNumber = Console.ReadLine();

            Console.Write("New Postal Code: ");
            selected.Pcode = Console.ReadLine();
            App.UpAdd(selected);

            Console.WriteLine("\nAddress updated successfully!");
        }

        static void UpdateCard()
        {
            var cards = App.GetCards();

            if (cards.Count == 0)
            {
                Console.WriteLine("No Card to update.");
                return;
            }

            Console.WriteLine("\nSelect Card to Update:\n");

            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cards[i].Name}");
            }

            Console.Write("\nEnter number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 1 || choice > cards.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }
            var selected = cards[choice - 1];

            Console.WriteLine("\nEnter new details:\n");

            Console.Write("New Name: ");
            selected.Name = Console.ReadLine();

            Console.Write("New Card Number: ");
            selected.CNumber = Console.ReadLine();

            Console.Write("New Expiration: ");
            selected.EDate = Console.ReadLine();

            Console.Write("New CVV: ");
            selected.CVV = Console.ReadLine();
            App.UpCard(selected);

            Console.WriteLine("\nCard updated successfully!");
        }

        static void UpdateBank()
        {
            var banks = App.GetBanks();

            if (banks.Count == 0)
            {
                Console.WriteLine("No Bank to update.");
                return;
            }

            Console.WriteLine("\nSelect Bank to Update:\n");

            for (int i = 0; i < banks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {banks[i].Holder}");
            }

            Console.Write("\nEnter number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 1 || choice > banks.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }
            var selected = banks[choice - 1];

            Console.WriteLine("\nEnter new details:\n");

            Console.Write("New Name: ");
            selected.Holder = Console.ReadLine();

            Console.Write("New Bank Number: ");
            selected.BNumber = Console.ReadLine();

            Console.Write("New Bank Name: ");
            selected.BName = Console.ReadLine();
            App.UpBank(selected);

            Console.WriteLine("\nBank updated successfully!");
        }

        static void UpdateGcash()
        {
            var gcash = App.GetGcash();

            if (gcash.Count == 0)
            {
                Console.WriteLine("No Gcash to update.");
                return;
            }

            Console.WriteLine("\nSelect Gcash to Update:\n");

            for (int i = 0; i < gcash.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {gcash[i].Name}");
            }

            Console.Write("\nEnter number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 1 || choice > gcash.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }
            var selected = gcash[choice - 1];

            Console.WriteLine("\nEnter new details:\n");

            Console.Write("New Name: ");
            selected.Name = Console.ReadLine();

            Console.Write("New Gcash Number: ");
            selected.GNumber = Console.ReadLine();
            App.UpGcash(selected);

            Console.WriteLine("\nGcash updated successfully!");
        }
    }
}