using Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace DataService
{
    public class InMemoData : IData
    {
        public List<ADD> dummyAdd = new List<ADD>();
        public List<Card> dummyCard = new List<Card>();
        public List<Bank> dummyBank = new List<Bank>();
        public List<Gcash> dummyGcash = new List<Gcash>();

        public InMemoData()
        {
            ADD address = new ADD { Name = "Ronelito", Address = "1556, Kaimito st., brgy. San Antonio, Binan City, Laguna, Calabarzon", PNumber = "09XXXXXXXXX", Pcode = "4024" };
            Card card = new Card { Name = "Ronelito T. Llaguno", CNumber = "123456789", EDate = "2030", CVV = "1234" };
            Bank bank = new Bank { Holder = "Ronelito T. Llaguno", BNumber = "94725739206", BName = "BDO" };
            Gcash gcash = new Gcash { Name = "Ronelito T. Llaguno", GNumber = "09XXXXXXXXX" };

            dummyAdd.Add(address);
            dummyCard.Add(card);
            dummyBank.Add(bank);
            dummyGcash.Add(gcash);
        }

        public void InsertAddress(ADD add)
        {
            dummyAdd.Add(add);
        }

        public void InsertCard(Card card)
        {
            dummyCard.Add(card);
        }

        public void InsertBank(Bank bank)
        {
            dummyBank.Add(bank);
        }

        public void InsertGcash(Gcash gcash)
        {
            dummyGcash.Add(gcash);
        }


        public List<ADD> GetAddresses()
        {
            return dummyAdd;
        }

        public List<Card> GetCards()
        {
            return dummyCard;
        }

        public List<Bank> GetBanks()
        {
            return dummyBank;
        }

        public List<Gcash> GetGcash()
        {
            return dummyGcash;
        }

        public ADD? GetById(Guid aid)
        {
            throw new NotImplementedException();
        }

        public void UpAdd(ADD add)
        {
            throw new NotImplementedException();
        }
    }
}