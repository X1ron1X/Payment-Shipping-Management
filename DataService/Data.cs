using Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class Data
    {
        IData _db;
        public Data(IData iData)
        {
            _db = iData;
        }

        public void AddAddress(ADD add)
        {
            _db.InsertAddress(add);
        }

        public void AddCard(Card card)
        {
            _db.InsertCard(card);
        }

        public void AddBank(Bank bank)
        {
            _db.InsertBank(bank);
        }

        public void AddGcash(Gcash gcash)
        {
            _db.InsertGcash(gcash);
        }

        public List<ADD> GetAddress()
        {
            return _db.GetAddresses();
        }

        public List<Card> GetCards()
        {
            return _db.GetCards();
        }

        public List<Bank> GetBanks()
        {
            return _db.GetBanks();
        }

        public List<Gcash> GetGcash()
        {
            return _db.GetGcash();
        }

        public void Add(ADD add)
        {
            throw new NotImplementedException();
        }
    }
}