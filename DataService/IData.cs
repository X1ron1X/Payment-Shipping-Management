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
        ADD? GetByaid(Guid aid);
        Card? GetBycid(Guid cid);
        Bank? GetBybid(Guid bid);
        Gcash? GetBygid(Guid gid);
        void UpAdd(ADD add);
        void UpCard(Card card);
        void UpBank(Bank bank);
        void UpGcash(Gcash gcash);
        List<ADD> GetAddresses();
        List<Card> GetCards();
        List<Bank> GetBanks();
        List<Gcash> GetGcash();
        }
}
