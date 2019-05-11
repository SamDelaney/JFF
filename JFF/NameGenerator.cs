using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFF
{
    static class NameGenerator
    {
        static char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
        static char[] stops = { 'b', 'c', 'd', 'g', 'j', 'k', 'm', 'n', 'p', 'q', 't', 'x' };
        static char[] cont = { 'f', 'h', 'l', 'r', 's', 'v', 'w', 'z' };
        static Random gen = new Random();

        public static string GenerateFullName(int seed, bool isMale)
        {
            Random gen = new Random(seed);
            return GenerateName() + " " + GenerateName();
        }

        public static string GenerateName()
        {
            string name = "";

            //determine number of syllables
            int sylCountSeed = gen.Next(10);
            int syllableCount = 0;
            for (int i = 0; i < sylCountSeed; i += 4)
                syllableCount++;

            //create syllables
            for (int i = 0; i < syllableCount + 1; i++)
            {
                if (name.Length > 0)
                    name += makeSyllable(name[name.Length - 1]);
                else
                    name = makeSyllable('a'); //vowels do not presently affect the production of a syllable
            }

            // ensure the name is at least 3 characters long
            while (name.Length < 3)
                name += makeSyllable(name[name.Length - 1]);

            // capitalize first letter
            char[] nameArr = name.ToCharArray();
            nameArr[0] = char.ToUpper(name[0]);
            name = new string(nameArr);

            return name;
        }

        private static string makeSyllable(char prev)
        {
            char[] coda = stops.Concat(cont).ToArray();
            char[] onset = coda;
            if (stops.Contains(prev))
                onset = cont;
            else if (cont.Contains(prev))
                onset = stops;

            string syl = "";
            syl += getCons(onset);
            syl += getVowel();
            syl += getCons(coda);

            return syl;
        }

        private static string getCons(char[] charSet)
        {
            int i = gen.Next(charSet.Length + 1);
            if (i >= charSet.Length)
                return "";
            return charSet[i].ToString();
        }

        private static string getVowel()
        {
            int i = gen.Next(vowels.Length);
            return vowels[i].ToString();
        }
    }
}
