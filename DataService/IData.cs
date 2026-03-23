using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataService
{
     public interface IData
        {
            void InsertAddress(ADD add);
            void InsertCard(Card card);
            void InsertBank(Bank bank);
            void InsertGcash(Gcash gcash);
            List<ADD> GetAddresses();
            List<Card> GetCards();
            List<Bank> GetBanks();
            List<Gcash> GetGcash();
        }
}
