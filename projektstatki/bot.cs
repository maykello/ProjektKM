using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektstatki
{
    internal class bot
    {
        public int x;
        public int y;
        public static void RozstawStatki()
        {
            Random random = new Random();
            bot bot = new bot();
            bot.x = random.Next(0, 10);
            bot.y = random.Next(0, 10);
        }

        public static void Zestrzel()
        {
            Random random = new Random();
            bot bot = new bot();
            bot.x = random.Next(0, 10);
            bot.y = random.Next(0, 10);
        }
    }
}
