using Models;
using DataService;
using System;
using System.Collections.Generic;

namespace AppService
{
    public class Service
    {
        Data data = new Data(new DBData());
        //InMemoData inmemodata= new InMemoData();
        JsonData jd = new JsonData();

        //public Service() { 
        //DBData dbdata = new DBData();
        //} 

        public bool Address(ADD newadd)
        {
            var add = new ADD
            {
                AID = Guid.NewGuid(),
                Name = newadd.Name,
                Address = newadd.Address,
                PNumber = newadd.PNumber,
                Pcode = newadd.Pcode
            };
            //inmemodata.InsertAddress(add);
            jd.InsertAddress(add);
            data.AddAddress(newadd);
            return true;

        }


        public bool AddPayment(Card card)
        {
            if (card == null) return false;
            //inmemodata.InsertCard(card);
            jd.InsertCard(card);
            data.AddCard(card);
            return true;
        }

        public bool AddPayment(Bank bank)
        {
            if (bank == null) return false;
            //inmemodata.InsertBank(bank);
            jd.InsertBank(bank);
            data.AddBank(bank);
            return true;
        }

        public bool AddPayment(Gcash gcash)
        {
            if (gcash == null) return false;
            //inmemodata.InsertGcash(add);
            jd.InsertGcash(gcash);
            data.AddGcash(gcash);
            return true;
        }

        public bool UpAdd(ADD upAdd)
        {
            if (upAdd == null) return false;
            jd.UpAdd(upAdd);
            data.UpAdd(upAdd);
            return true;
        }

        public bool UpCard(Card upCard)
        {
            if (upCard == null) return false;
            jd.UpCard(upCard);
            data.UpCard(upCard);
            return true;
        }

        public bool UpBank(Bank upBank)
        {
            if (upBank == null) return false;
            jd.UpBank(upBank);
            data.UpBank(upBank);
            return true;
        }

        public bool UpGcash(Gcash upGcash)
        {
            if (upGcash == null) return false;
            jd.UpGcash(upGcash);
            data.UpGcash(upGcash);
            return true;
        }

        public List<ADD> GetAddresses()
        {
            //return inmemodata.GetAddresses();
            return jd.GetAddresses();
            return data.GetAddress();
        }

        public List<Card> GetCards()
        {
            //return inmemodata.GetCards();
            return jd.GetCards();
            return data.GetCards();
        }

        public List<Bank> GetBanks()
        {
            //return inmemodata.GetBanks();
            return jd.GetBanks();
            return data.GetBanks();
        }

        public List<Gcash> GetGcash()
        {
            //return inmemodata.GetGcash();
            return jd.GetGcash();
            return data.GetGcash();
        }

    }
}
