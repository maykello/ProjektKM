using System;
using System.Collections.Generic;

public class Statki
{
    public const int ROZMIAR_PLANSZY = 10;
    public char[,] plansza;
    private List<Statek> statki;


    public Statki()
    {
        plansza = new char[ROZMIAR_PLANSZY, ROZMIAR_PLANSZY];
        statki = new List<Statek>();
        // Inicjalizacja planszy kropkami
        for (int i = 0; i < ROZMIAR_PLANSZY; i++)
        {
            for (int j = 0; j < ROZMIAR_PLANSZY; j++)
            {
                plansza[i, j] = '.';
            }
        }
    }

    public void GenerujStatki()
    {
        GenerujStatek(4, 1); // Jeden czteromasztowiec
        GenerujStatek(3, 2); // Dwa trzynasztwce
        GenerujStatek(2, 3); // Trzy dwumasztowce
        GenerujStatek(1, 4); // Cztery jednomasztowce
    }


    private bool GenerujStatek(int rozmiar, int ilosc)
    {
        for (int i = 0; i < ilosc; i++)
        {
            bool umieszczony = false;
            while (!umieszczony)
            {
                int x = new Random().Next(ROZMIAR_PLANSZY);
                int y = new Random().Next(ROZMIAR_PLANSZY);
                bool orientacja = new Random().Next(2) == 0; // true - poziomo, false - pionowo

                if (MoznaUmiescicStatek(x, y, rozmiar, orientacja))
                {
                    UmiescStatek(x, y, rozmiar, orientacja);
                    statki.Add(new Statek(x, y, rozmiar, orientacja));
                    umieszczony = true;
                }
            }
        }
        return true;
    }

    private bool MoznaUmiescicStatek(int x, int y, int rozmiar, bool poziomo)
    {
        if (poziomo)
        {
            if (x + rozmiar > ROZMIAR_PLANSZY) return false;
            for (int i = x; i < x + rozmiar; i++)
            {
                if (y >= ROZMIAR_PLANSZY || plansza[i, y] != '.' || SprawdzenieSasiedztwa(i, y)) return false;
                if (i > 0 && y > 0 && plansza[i - 1, y - 1] != '.') return false;
                if (i > 0 && plansza[i - 1, y] != '.') return false;
                if (i > 0 && y < ROZMIAR_PLANSZY - 1 && plansza[i - 1, y + 1] != '.') return false;
                if (y > 0 && plansza[i, y - 1] != '.') return false;
                if (y < ROZMIAR_PLANSZY - 1 && plansza[i, y + 1] != '.') return false;
                if (i < ROZMIAR_PLANSZY - 1 && y > 0 && plansza[i + 1, y - 1] != '.') return false;
                if (i < ROZMIAR_PLANSZY - 1 && plansza[i + 1, y] != '.') return false;
                if (i < ROZMIAR_PLANSZY - 1 && y < ROZMIAR_PLANSZY - 1 && plansza[i + 1, y + 1] != '.') return false;

            }
        }
        else
        {
            if (y + rozmiar > ROZMIAR_PLANSZY) return false;
            for (int i = y; i < y + rozmiar; i++)
            {
                if (x >= ROZMIAR_PLANSZY || plansza[x, i] != '.' || SprawdzenieSasiedztwa(x, i)) return false;
                if (i > 0 && x > 0 && plansza[x - 1, i - 1] != '.') return false;
                if (i > 0 && plansza[x, i - 1] != '.') return false;
                if (i > 0 && x < ROZMIAR_PLANSZY - 1 && plansza[x + 1, i - 1] != '.') return false;
                if (x > 0 && plansza[x - 1, i] != '.') return false;
                if (x < ROZMIAR_PLANSZY - 1 && plansza[x + 1, i] != '.') return false;
                if (i < ROZMIAR_PLANSZY - 1 && x > 0 && plansza[x - 1, i + 1] != '.') return false;
                if (i < ROZMIAR_PLANSZY - 1 && plansza[x, i + 1] != '.') return false;
                if (i < ROZMIAR_PLANSZY - 1 && x < ROZMIAR_PLANSZY - 1 && plansza[x + 1, i + 1] != '.') return false;
            }
        }
        return true;
    }

    private bool SprawdzenieSasiedztwa(int x, int y)
    {
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < ROZMIAR_PLANSZY && j >= 0 && j < ROZMIAR_PLANSZY && plansza[i, j] == 'S') return true;
            }
        }
        return false;

    }

    private void UmiescStatek(int x, int y, int rozmiar, bool poziomo)
    {
        if (poziomo)
        {
            for (int i = x; i < x + rozmiar; i++)
            {
                plansza[i, y] = 'S';
            }
        }
        else
        {
            for (int i = y; i < y + rozmiar; i++)
            {
                plansza[x, i] = 'S';
            }
        }
    }

    public void WyswietlPlansze()
    {
        Console.WriteLine("  " + string.Join(" ", Enumerable.Range(0, ROZMIAR_PLANSZY)));
        for (int i = 0; i < ROZMIAR_PLANSZY; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < ROZMIAR_PLANSZY; j++)
            {
                if(plansza[i, j] == 'X' || plansza[i,j] == 'O')
                    Console.Write(plansza[i, j] + " ");
                else
                    Console.Write("? ");
            }
            Console.WriteLine();
        }
    }

    private class Statek
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Rozmiar { get; set; }
        public bool Poziomo { get; set; }

        public Statek(int x, int y, int rozmiar, bool poziomo)
        {
            X = x;
            Y = y;
            Rozmiar = rozmiar;
            Poziomo = poziomo;
        }
    }

   
}