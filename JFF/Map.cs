using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFF
{
    class Map
    {
        Random gen;
        public List<Town> Towns;
        public Map()
        {
            Towns = new List<Town>();
            gen = new Random();
            for (int i = 0; i < 20; i++)
            {
                Towns.Add(new Town(NameGenerator.GenerateName()));
                for (int j = 1; j < 6; j++)
                {
                    int seed = gen.Next(5);
                    if (seed == 0 && i - j >= 0)
                    {
                        Towns[i].Connections.Add(i - j);
                        Towns[i - j].Connections.Add(i);
                    }
                }
            }

            //ensure no towns are isolated
            for (int i = 0; i < 20; i++)
            {
                if (Towns[i].Connections.Count() == 0)
                {                    
                    while (true)
                    {
                        int newFriend = gen.Next(20);
                        if (newFriend != i)
                        {
                            Towns[i].Connections.Add(newFriend);
                            Towns[newFriend].Connections.Add(i);
                            break;
                        }
                    }
                }
            }
        }

        public string printTown(Town town)
        {
            string output = town.Name;
            output += "\nNearby Towns:";
            for (int i = 0; i < town.Connections.Count; i++)
            {
                output += String.Format("\n{0}) {1}", i + 1, Towns[town.Connections[i]].Name);
            }

            return output;
        }
    }
}
