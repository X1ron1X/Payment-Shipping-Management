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
        // InMemoData inmemodata= new InMemoData();

        //public Service() { 
        //DBData dbdata = new DBData();
        //} 

        public bool Address(ADD newadd)
        {
            var add = new ADD
            {
                Name = newadd.Name,
                Address = newadd.Address,
                PNumber = newadd.PNumber,
                Pcode = newadd.Pcode
            };
            data.AddAddress(newadd);
            return true;

        }

        
        public bool AddPayment(Card card)
        {
            if (card == null) return false;
            
            data.AddCard(card);
            return true;
        }

        public bool AddPayment(Bank bank)
        {
            if (bank == null) return false;
            data.AddBank(bank);
            return true;
        }

        public bool AddPayment(Gcash gcash)
        {
            if (gcash == null) return false;
            data.AddGcash(gcash);
            return true;
        }

    }
}
