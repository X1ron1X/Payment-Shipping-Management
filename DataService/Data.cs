using System.Security.Principal;
using Models;

namespace DataService
{
    public class Data
    {
        public List<ADD> dummyAdd = new List<ADD>();
        public List<Card> dummyCard = new List<Card>();
        public List<Bank> dummyBank = new List<Bank>();
        public List<Gcash> dummyGcash = new List<Gcash>();

        public Data()
        {
            ADD address = new ADD { Name = "Ronelito", Address = "1556, Kaimito st., brgy. San Antonio, Binan City, Laguna, Calabarzon", PNumber = "09XXXXXXXXX", Pcode = "4024" };
            Card card = new Card { Name = "Ronelito T. Llaguno", CNumber = "123456789", EDate = "2030", CVV = "1234" };
            Bank bank = new Bank { Name = "BDO", BNumber = "94725739206", Holder = "Ronelito T. Llaguno" };
            Gcash gcash = new Gcash { Name = "Ronelito T. Llaguno", GNumber = "09XXXXXXXXX" };

            dummyAdd.Add(address);
            dummyCard.Add(card);
            dummyBank.Add(bank);
            dummyGcash.Add(gcash);
        }

        public void Add(ADD add)
        {
            dummyAdd.Add(add);
        }

        public void AddCard(Card card)
        {
            dummyCard.Add(card);
        }

        public void AddBank(Bank bank)
        {
            dummyBank.Add(bank);
        }

        public void AddGcash(Gcash gcash)
        {
            dummyGcash.Add(gcash);
        }


        public List<ADD> GetAddress()
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
