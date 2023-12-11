using System;

class Program
{
    static char[,] labirynt1; 

    static void Main()
    {
        Console.WriteLine("Witaj w programie Labirynt!");

        UtworzLabirynt(); 
        WyswietlLabirynt(); 
        ModyfikujLabirynt(); 
        WyswietlLabirynt();
        ZapiszLabirynt(); 
        Console.WriteLine("Dziękujemy za skorzystanie z programu Labirynt!");
    }

    static void UtworzLabirynt()
    {
        Console.Write("Podaj liczbę wierszy: ");
        int liczbaWierszy = Convert.ToInt32(Console.ReadLine());

        Console.Write("Podaj liczbę kolumn: ");
        int liczbaKolumn = Convert.ToInt32(Console.ReadLine());

        labirynt1 = new char[liczbaWierszy, liczbaKolumn];

        
        for (int i = 0; i < liczbaWierszy; i++)
        {
            for (int j = 0; j < liczbaKolumn; j++)
            {
                labirynt1[i, j] = ' ';
            }
        }
    }

    static void WyswietlLabirynt()
    {
        Console.WriteLine("Aktualny labirynt:");

        for (int i = 0; i < labirynt1.GetLength(0); i++)
        {
            for (int j = 0; j < labirynt1.GetLength(1); j++)
            {
                Console.Write($"[{labirynt1[i, j]}]");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void ModyfikujLabirynt()
    {
        Console.WriteLine("Modyfikuj labirynt:");

        do
        {
            Console.Write("Podaj wiersz (0 - {0}): ", labirynt1.GetLength(0) - 1);
            int wiersz = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj kolumnę (0 - {0}): ", labirynt1.GetLength(1) - 1);
            int kolumna = Convert.ToInt32(Console.ReadLine());

            Console.Write("Wybierz stan (0 - Brak, 1 - Ściana, 2 - Ścieżka): ");
            int stan = Convert.ToInt32(Console.ReadLine());

            if (wiersz >= 0 && wiersz < labirynt1.GetLength(0) &&
                kolumna >= 0 && kolumna < labirynt1.GetLength(1) &&
                stan >= 0 && stan <= 2)
            {
                switch (stan)
                {
                    case 0:
                        labirynt1[wiersz, kolumna] = ' ';
                        break;
                    case 1:
                        labirynt1[wiersz, kolumna] = '#';
                        break;
                    case 2:
                        labirynt1[wiersz, kolumna] = '.';
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowe dane. Spróbuj ponownie.");
            }

            Console.Write("Czy chcesz kontynuować modyfikację? (Tak/Nie): ");
        } while (Console.ReadLine().ToUpper() == "Tak");
    }

    static void ZapiszLabirynt()
    {
        Console.Write("Podaj nazwę pliku do zapisu: ");
        string nazwaPliku = Console.ReadLine();

        try
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(nazwaPliku))
            {
                for (int i = 0; i < labirynt1.GetLength(0); i++)
                {
                    for (int j = 0; j < labirynt1.GetLength(1); j++)
                    {
                        sw.Write(labirynt1[i, j]);
                    }
                    sw.WriteLine();
                }
            }

            Console.WriteLine($"Labirynt został zapisany do pliku: {nazwaPliku}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas zapisu do pliku: {ex.Message}");
        }
    }
}
