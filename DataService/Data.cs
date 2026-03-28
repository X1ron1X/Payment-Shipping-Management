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

        public ADD? GetByaid(Guid aid)
        {
            return _db.GetByaid(aid);
        }

        public Card? GetBycid(Guid cid)
        {
            return _db.GetBycid(cid);
        }

        public Bank? GetBybid(Guid bid)
        {
            return _db.GetBybid(bid);
        }

        public Gcash? GetBygid(Guid gid)
        {
            return _db.GetBygid(gid);
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

        public void UpAdd(ADD add)
        {
            _db.UpAdd(add);
        }

        public void UpCard(Card card)
        {
            _db.UpCard(card);
        }

        public void UpBank(Bank bank)
        {
            _db.UpBank(bank);
        }

        public void UpGcash(Gcash gcash)
        {
            _db.UpGcash(gcash);
        }
    }
}