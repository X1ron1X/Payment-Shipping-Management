using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Data.SqlClient.Internal.SqlClientEventSource;

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

        public ADD? GetByaid(Guid aid)
        {
            return dummyAdd.FirstOrDefault(t => t.AID == aid);
        }

        public Card? GetBycid(Guid cid)
        {
            return dummyCard.FirstOrDefault(t => t.CID == cid);
        }

        public Bank? GetBybid(Guid bid)
        {
            return dummyBank.FirstOrDefault(t => t.BID == bid);
        }

        public Gcash? GetBygid(Guid gid)
        {
            return dummyGcash.FirstOrDefault(t => t.GID == gid);
        }

        public void UpAdd(ADD add)
        {
            var existing = GetByaid(add.AID);
            if (existing != null)
            {
                existing.Name = add.Name;
                existing.Address = add.Address;
                existing.PNumber = add.PNumber;
                existing.Pcode = add.Pcode;
            }
        }
        public void UpCard(Card card)
        {
            var existing = GetBycid(card.CID);
            if (existing != null)
            {
                existing.Name = card.Name;
                existing.CNumber = card.CNumber;
                existing.EDate = card.EDate;
                existing.CVV = card.CVV;
            }
        }
        public void UpBank(Bank bank)
        {
            var existing = GetBybid(bank.BID);
            if (existing != null)
            {
                existing.Holder = bank.Holder;
                existing.BNumber = bank.BNumber;
                existing.BName = bank.BName;
            }
        }
        public void UpGcash(Gcash gcash)
        {
            var existing = GetBygid(gcash.GID);
            if (existing != null)
            {
                existing.Name = gcash.Name;
                existing.GNumber = gcash.GNumber;
            }
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
    }
}