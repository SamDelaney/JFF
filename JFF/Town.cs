using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFF
{
    class Town
    {
        public string Name;
        public List<int> Connections;

        private List<Soldier> inhabitants;
        private int turnVisited;

        public Town(string pname)
        {
            Name = pname;
            Connections = new List<int>();

            inhabitants = new List<Soldier>();
            turnVisited = 0;
        }

        public Soldier[] GetSoldiers(int curTurn)
        {
            Random gen = new Random();
            for (int i = 0; i < curTurn - turnVisited; i++)
            {
                if (gen.Next() % 3 == 0)
                    inhabitants.Add(new Soldier(gen.Next()));
            }

            turnVisited = curTurn;

            return inhabitants.ToArray();
        }

        public Soldier[] TakeSoldiers()
        {
            Soldier[] newSoldiers = inhabitants.ToArray();
            inhabitants = new List<Soldier>();
            return newSoldiers;
        }
    }
}
