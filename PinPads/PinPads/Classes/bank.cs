using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinPads
{
    public class Bank
    {
        int id;
        string title;
        public void Set(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
    }
}
