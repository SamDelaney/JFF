using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFF
{
    class Soldier
    {
        static double[] maleChances = { 800, 990, 997, 1000 };
        static double[] femaleChances = { 350, 700, 900, 1000 };

        string Name;
        double Health;
        bool isMale;
        public SoldierType Type;

        struct Combat
        {
            int Power;
            double Consistency;
            double Experience;
        }

        public Soldier(int seed)
        {
            Random gen = new Random(seed);

            isMale = gen.Next() % 300 != 0; //one in 300 soldiers are female

            initializeType(isMale, seed);

            Name = NameGenerator.GenerateFullName(seed, isMale);
        }

        private void initializeType(bool isMale, int seed)
        {
            double[] chances = maleChances;
            if (!isMale) 
                chances = femaleChances; //female soldiers are far less likely to be melee
            int i = 0;
            for (int threshold = 0; Math.Abs(seed * 23 % 1000) > threshold; i++)
                threshold = (int)chances[i];

            Type = (SoldierType)Math.Abs(i - 1);
        }

        public string printStats()
        {
            string Gender = "";
            if (!isMale)
                Gender= "Female";
            else
                Gender += "Male";

            return String.Format("{0, -25} {1, -10} {2, -10}", Name, Gender, Type);
        }

    }

    enum Notoriety
    {
        Novice,
        Veteran,
        Hero,
        Juggernaut,
        Legend,
        Myth,
        Demigod
    }

    enum SoldierType
    {
        Melee,
        Ranged,
        Mage,
        Assassin
    }
}
