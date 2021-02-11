namespace Funzioni
{
    public struct Bicicletta
    {
        public string matricola;
        public string marca;
        public string categoria;
        public string telaio;
        public decimal prezzo;
        public decimal potenza;
        public decimal speed;
        public int autonomia;
        public int ruote;
    }

    internal class MyLibrary
    {
        public static void OrdinamentoRuote(Bicicletta[] eleBici, int num)
        {
            Bicicletta tmp;
            int x = default;
            int y = default;

            while (x < num)
            {
                y = x + 1;
                while (y < num)
                {
                    if (eleBici[x].ruote > eleBici[y].ruote)
                    {
                        tmp = eleBici[x];
                        eleBici[x] = eleBici[y];
                        eleBici[y] = tmp;
                    }
                    y = y + 1;
                }
                x = x + 1;
            }
        }

        public static void OrdinamentoCate(Bicicletta[] eleBici, int num)
        {
            Bicicletta tmp;
            int x = default;
            int y = default;

            while (x < num)
            {
                y = x + 1;
                while (y < num)
                {
                    if (string.Compare(eleBici[x].categoria, eleBici[y].categoria) > 0)
                    {
                        tmp = eleBici[x];
                        eleBici[x] = eleBici[y];
                        eleBici[y] = tmp;
                    }
                    y = y + 1;
                }
                x = x + 1;
            }
        }

        public static int Cerca(Bicicletta[] eleBici, int num, string dato)
        {
            int x = 0;

            while (x < num)
            {
                if (eleBici[x].matricola == dato)
                    return x;   // Trovato
                x = x + 1;
            }
            return -1;          // Non Trovato
        }

        public static void CancellaPerPotenza(Bicicletta[] eleBici, ref int num, decimal inputPotenza)
        {
            int x = 0;
            int y = 0;

            while (x < num)
            {
                if (eleBici[x].potenza <= inputPotenza)
                {
                    num--;
                    y = x;
                    while (y < num)
                    {
                        if (y != eleBici.Length - 1)
                        {
                            eleBici[y] = eleBici[y + 1];
                            y++;
                        }
                    }
                    x--;
                }
                x++;
            }
        }

        public static decimal ValoreCategoria(Bicicletta[] eleBici, int num, string cateScelta)
        {
            int x = 0;
            decimal totaleCate = default;

            while (x < num)
            {
                if (string.Compare(eleBici[x].categoria, cateScelta) == 0)
                {
                    totaleCate = eleBici[x].prezzo + totaleCate;
                }
            }
            x++;

            return totaleCate;
        }

        public static decimal PrezzoMassimo(Bicicletta[] eleBici, int num, string telaioScelto)
        {
            int x = default;
            int y = default;
            decimal biciMax = default;

            while (x < num)
            {
                if (string.Compare(eleBici[x].telaio, telaioScelto) == 0)
                {
                    if (eleBici[x].prezzo > eleBici[y].prezzo)
                    {
                        biciMax = eleBici[x].prezzo;
                    }
                }
                x++;
            }
            return biciMax;
        }

        public static decimal PrezzoMinimo(Bicicletta[] eleBici, int num, string telaioScelto)
        {
            int x = default;
            int y = default;
            decimal biciMin = default;

            while (x < num)
            {
                if (string.Compare(eleBici[x].telaio, telaioScelto) == 0)
                {
                    if (eleBici[x].prezzo < eleBici[y].prezzo)
                    {
                        biciMin = eleBici[x].prezzo;
                    }
                }
                x++;
            }
            return biciMin;
        }

        public static decimal MediaPrezzi(Bicicletta[] eleBici, int num, string telaioScelto)
        {
            int x = 0;
            int y = 0;
            decimal media = default;
            decimal totale = default;

            while (x < num)
            {
                if (string.Compare(eleBici[x].telaio, telaioScelto) == 0)
                {
                    totale = eleBici[x].prezzo + totale;
                    y = y + 1;
                }
                x = x + 1;
            }
            if (y != 0) media = totale / y;

            return media;
        }

        public static decimal MediaVelocità(Bicicletta[] eleBici, int num)
        {
            int x = 0;
            decimal mediaVelocità = default;

            while (x < num)
            {
                if (eleBici[x].speed > -1)
                {
                    mediaVelocità += eleBici[x].speed;
                }
                x++;
            }
            mediaVelocità /= x;

            return mediaVelocità;
        }

        public static decimal PotenzaMinima(Bicicletta[] eleBici, int num, decimal mediaPotenza)
        {
            int x = default;

            decimal potenzaMin = default;

            while (x < num)
            {
                if (eleBici[x].potenza < mediaPotenza)
                {
                    potenzaMin = eleBici[x].potenza;
                }
                x++;
            }
            return potenzaMin;
        }

        public static decimal PotenzaMax(Bicicletta[] eleBici, int num, decimal mediaPotenza)
        {
            int x = default;

            decimal potenzaMax = default;

            while (x < num)
            {
                if (eleBici[x].potenza > mediaPotenza)
                {
                    potenzaMax = eleBici[x].potenza;
                }
                x++;
            }
            return potenzaMax;
        }

        public static decimal MediaPotenza(Bicicletta[] eleBici, int num)
        {
            int x = 0;
            decimal mediaPotenza = default;

            while (x < num)
            {
                if (eleBici[x].potenza > -1)
                {
                    mediaPotenza += eleBici[x].potenza;
                }
                x++;
            }
            mediaPotenza /= x;

            return mediaPotenza;
        }
    }
}