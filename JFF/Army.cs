using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFF
{
    class Army
    {
        public string Name;
        public List<Soldier> soldiers = new List<Soldier>();

        public string PrintStatus()
        {
            string output = Name;
            foreach(Soldier s in soldiers)
            {
                output += "\n" + s.printStats();
            }
            return output;
        }
    }
}
