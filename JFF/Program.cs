using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFF
{
    class Program
    {
        static Random gen = new Random();
        static Army player = new Army();
        static Map worldMap = new Map();
        static Town curTown;
        static int turn;

        static void Main(string[] args)
        {
            turn = 0;
            Console.Write("Name your army: ");
            player.Name = Console.ReadLine();
            player.soldiers = GetSoldiers(5).ToList();

            while (true)
            {
                nextTown();
                Console.WriteLine(player.PrintStatus());
                Console.Read();
                turn++;
            }
        }

        static void nextTown()
        {
            if (gen.Next(20) == 1)
                encounter();

            curTown = worldMap.Towns[turn % 20];
            Console.WriteLine(worldMap.printTown(curTown));

            Console.Read();
        }

        static void encounter()
        {
            Console.WriteLine("You have encountered an enemy!");
        }

        static Soldier[] GetSoldiers(int num)
        {
            Soldier[] soldiers = new Soldier[num];
            for (int i = 0; i < num; i++)
            {
                soldiers[i] = new Soldier(gen.Next());
            }
            return soldiers;
        }
    }
}
