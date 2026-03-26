using Models;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppService
{
    public class Service
    {
        Data data = new Data(new DBData());
        InMemoData inmemodata= new InMemoData();

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
            data.AddAddress(newadd);
            return true;

        }


        public bool AddPayment(Card card)
        {
            if (card == null) return false;
            //inmemodata.InsertCard(add);
            data.AddCard(card);
            return true;
        }

        public bool AddPayment(Bank bank)
        {
            if (bank == null) return false;
            //inmemodata.InsertBank(add);
            data.AddBank(bank);
            return true;
        }

        public bool AddPayment(Gcash gcash)
        {
            if (gcash == null) return false;
            //inmemodata.InsertGcash(add);
            data.AddGcash(gcash);
            return true;
        }

        public bool UpAdd(ADD upAdd)
        {
            if (upAdd == null) return false;

            data.UpAdd(upAdd);
            return true;
        }

        public List<ADD> GetAddresses()
        {
            //return inmemodata.GetAddresses();
            return data.GetAddress();
        }

        public List<Card> GetCards()
        {
            //return inmemodata.GetCards();
            return data.GetCards();
        }

        public List<Bank> GetBanks()
        {
            //return inmemodata.GetBanks();
            return data.GetBanks();
        }

        public List<Gcash> GetGcash()
        {
            //return inmemodata.GetGcash();
            return data.GetGcash();
        }

    }
}
