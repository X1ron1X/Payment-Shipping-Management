using address;
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
        Data Data = new Data();
        public bool Address(ADD newadd)
        {

            var add = new ADD
            {
                Name = newadd.Name,
                Address = newadd.Address,
                PNumber = newadd.PNumber,
                Pcode = newadd.Pcode
            };
            Data.Add(newadd);
            return true;

        }

    }
}
