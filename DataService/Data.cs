using System.Security.Principal;
using address;

namespace DataService
{
    public class Data
    {
        public List<ADD> dummyAdd = new List<ADD>();

        public Data()
        {
            ADD address = new ADD { Name = "Ronelito", Address = "1556, Kaimito st., brgy. San Antonio, Binan City, Laguna, Calabarzon", PNumber = "09914687722", Pcode = "4024" };


            dummyAdd.Add(address);


        }

        public void Add(ADD add)
        {
            dummyAdd.Add(add);
        }

        public List<ADD> GetAddress()
        {
            return dummyAdd;
        }


    }
}
