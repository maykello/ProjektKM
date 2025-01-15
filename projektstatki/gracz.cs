using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektstatki
{
    internal class gracz
    {
        public int x;
        public int y;
        public static void User(Statki statki)
        {
            gracz gracz = new gracz();
            gracz.x = 0;
            gracz.y = 0;
            do
            {
                Console.Write("X:");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Y:");
                int y = int.Parse(Console.ReadLine());

                if (statki.plansza[x,y] == 'S')
                {
                    statki.plansza[x,y] = 'X';
                    Console.WriteLine("Trafiony");
                }
                else
                {
                    statki.plansza[x, y] = 'O';
                    Console.WriteLine("Pudło");
                }
                statki.WyswietlPlansze();
            } while (true);
        }
    }
}
