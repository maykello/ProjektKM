namespace projektstatki
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Statki statki = new Statki();
            statki.GenerujStatki();           
            statki.WyswietlPlansze();
            //Statki statki2 = new Statki();
            //statki2.GenerujStatki();
            //statki2.WyswietlPlansze();

            gracz.User(statki);
        }
    }
}
