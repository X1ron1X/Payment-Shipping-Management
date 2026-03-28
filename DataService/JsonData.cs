using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataService
{
    public class JsonData : IData
    {
        private List<ADD> add = new List<ADD>();
        private List<Bank> bank = new List<Bank>();
        private List<Card> card = new List<Card>();
        private List<Gcash> gcash = new List<Gcash>();

        private string _jsonFileName;

        public JsonData()
        {

            PopulateDataJsonFileAdd();
            PopulateDataJsonFilePay();
        }

        private void PopulateDataJsonFileAdd()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Address.json";
            PopulateAddress();
        }

        private void PopulateDataJsonFilePay()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Payment.json";
            PopulateCard();
            PopulateGcash();
            PopulateBank();
        }
        private void PopulateCard()
        {
            RetrieveCard();
            if (card.Count <= 0)
            {
                card.Add(new Card
                {
                    CID = Guid.NewGuid(),
                    Name = "Ronelito T. Llaguno",
                    CNumber = "123456789",
                    EDate = "2030",
                    CVV = "123"
                });
                SaveDataCard();
            }
        }

        private void PopulateGcash()
        {
            RetrieveGcash();
            if (gcash.Count <= 0)
            {
                gcash.Add(new Gcash
                {
                    GID = Guid.NewGuid(),
                    Name = "Ronelito T. Llaguno",
                    GNumber = "09XXXXXXXXX"
                });
                SaveDataGcash();
            }
        }

        private void PopulateBank()
        {
            RetrieveBank();
            if (bank.Count <= 0)
            {
                bank.Add(new Bank
                {
                    BID = Guid.NewGuid(),
                    Holder = "Ronelito T. Llaguno",
                    BNumber = "1234567890",
                    BName = "BDO"
                });
                SaveDataBank();
            }
        }

        private void PopulateAddress()
        {
            RetrieveAdd();

            if (add.Count <= 0)
            {
                add.Add(new ADD
                {
                    AID = Guid.NewGuid(),
                    Name = "admin",
                    Address = "1556, Kaimito st., brgy. San Antonio, Binan City, Laguna, Calabarzon",
                    PNumber = "09914687722",
                    Pcode = "4024"
                });

                SaveDataAdd();
            }
        }

        private void SaveDataAdd()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<ADD>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , add);
            }
        }

        private void SaveDataCard()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Card>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , card);
            }
        }

        private void SaveDataBank()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Bank>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , bank);
            }
        }

        private void SaveDataGcash()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Gcash>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , gcash);
            }
        }

        private void RetrieveAdd()
        {
            using (var jsonFileReader = File.OpenText(this._jsonFileName))
            {
                this.add = JsonSerializer.Deserialize<List<ADD>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        private void RetrieveCard()
        {
            using (var jsonFileReader = File.OpenText(this._jsonFileName))
            {
                this.card = JsonSerializer.Deserialize<List<Card>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        private void RetrieveBank()
        {
            using (var jsonFileReader = File.OpenText(this._jsonFileName))
            {
                this.bank = JsonSerializer.Deserialize<List<Bank>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        private void RetrieveGcash()
        {
            using (var jsonFileReader = File.OpenText(this._jsonFileName))
            {
                this.gcash = JsonSerializer.Deserialize<List<Gcash>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        public void InsertAddress(ADD adds)
        {
            add.Add(adds);
            SaveDataAdd();
        }

        public void InsertCard(Card cards)
        {
            card.Add(cards);
            SaveDataCard();
        }

        public void InsertBank(Bank banks)
        {
            bank.Add(banks);
            SaveDataBank();
        }

        public void InsertGcash(Gcash cash)
        {
            gcash.Add(cash);
            SaveDataGcash();
        }

        public List<ADD> GetAddresses()
        {
            RetrieveAdd();
            return add;
        }

        public List<Card> GetCards()
        {
            RetrieveCard();
            return card;
        }

        public List<Bank> GetBanks()
        {
            RetrieveBank();
            return bank;
        }
        public List<Gcash> GetGcash()
        {
            RetrieveGcash();
            return gcash;
        }

        public ADD? GetByaid(Guid id)
        {
            RetrieveAdd();
            return add.Where(x => x.AID == id).FirstOrDefault();
        }

        public Card? GetBycid(Guid id)
        {
            RetrieveCard();
            return card.Where(x => x.CID == id).FirstOrDefault();
        }

        public Bank? GetBybid(Guid id)
        {
            RetrieveBank();
            return bank.Where(x => x.BID == id).FirstOrDefault();
        }

        public Gcash? GetBygid(Guid id)
        {
            RetrieveGcash();
            return gcash.Where(x => x.GID == id).FirstOrDefault();
        }

        public void UpAdd(ADD adds)
        {
            RetrieveAdd();

            var existingAccount = add.FirstOrDefault(x => x.AID == adds.AID);

            if (existingAccount != null)
            {
                existingAccount.Name = adds.Name;
                existingAccount.Address = adds.Address;
                existingAccount.PNumber = adds.PNumber;
                existingAccount.Pcode = adds.Pcode;
            }

            SaveDataAdd();
        }

        public void UpCard(Card cards)
        {
            RetrieveCard();

            var existingAccount = card.FirstOrDefault(x => x.CID == cards.CID);

            if (existingAccount != null)
            {
                existingAccount.Name = cards.Name;
                existingAccount.CNumber = cards.CNumber;
                existingAccount.EDate = cards.EDate;
                existingAccount.CVV = cards.CVV;
            }

            SaveDataCard();
        }

        public void UpBank(Bank banks)
        {
            RetrieveBank();

            var existingAccount = bank.FirstOrDefault(x => x.BID == banks.BID);

            if (existingAccount != null)
            {
                existingAccount.Holder = banks.Holder;
                existingAccount.BNumber = banks.BNumber;
                existingAccount.BName = banks.BName;
            }

            SaveDataBank();
        }

        public void UpGcash(Gcash cash)
        {
            RetrieveGcash();

            var existingAccount = gcash.FirstOrDefault(x => x.GID == cash.GID);

            if (existingAccount != null)
            {
                existingAccount.Name = cash.Name;
                existingAccount.GNumber = cash.GNumber;
            }

            SaveDataGcash();
        }
    }
}
