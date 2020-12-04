using System;

namespace pole
{
    /// <summary>
    /// ----------------------------------------------------------------------------
    /// 
    //                              Koukni na radky 43-48
    /// 
    /// ----------------------------------------------------------------------------
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Nacteme velikost pole od uzivatele, nezapomente na int.Parse(), 
            // protoze Console.ReadLine() je string, ktery nelze ulozit do int
            Console.WriteLine("Zadej velikost pole");
            int array_size = int.Parse(Console.ReadLine());

            
            // Deklarace pole, array_size je velikost pole, kterou jsme si o 3 radky vys nacetli
            int[] arr = new int[array_size];


            // Cyklus pro nacteni pole
            for(int i = 0; i < arr.Length; i++)
            {
                // Nacitani do pole, ve slozenych zavorkach je promenna (i + 1), takze se vypise:
                // "Zadej 1. hodnotu: "
                // "Zadej 2. hodnotu: "
                // Atd.

                Console.Write("Zadej {0}. hodnotu: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }

            // Vypis pole pres vlastni metodu pred serazenim
            Console.WriteLine("Pole na zacatku: ");
            VypisPole(arr);


            // Volam metodu, ktera seradi pole a vrati ho, nezapomenout ze pole se predava pres odkaz, 
            // to znamena zmena v cyklu je zaroven zmena mimo cyklus
            // Tridici algoritmy (Odkomentuj ten, ktery chces pouzit):

            // 1. BubbleSort(arr);
            // 2. SelectionSort(arr);


            // Vypis pole pres vlastni metodu po serazeni
            Console.WriteLine("Serazene pole: ");
            VypisPole(arr);


            // Nezapomen na tohle, jinak te Skalka znici
            Console.ReadLine();
        }


        /// <summary>
        /// Vypise pole
        /// </summary>
        /// <param name="arr"> Pole, ktere chceme vypsat </param>
        static void VypisPole(int[] arr)
        {
            // Vypis pole
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ", ");
            }


            // Tohle je jen pro peknejsi formatovani
            Console.WriteLine("\n------------------");
        }


        /// <summary>
        /// Metoda, ktera si bere jako parametr pole integeru, ktere seradi vzestupne a pak vrati.
        /// Funguje tak, ze porovnavame 2 sousedni indexy pole, jestli je druhy index vetsi nez prvni, prohodime, jinak nechame byt.
        /// </summary>
        /// <param name="arr"> Pole, ktere chceme seradit </param>
        /// <returns> Serazene pole </returns>
        static int[] BubbleSort(int[] arr)
        {
            // Odecitame jednicku u arr.Length proto, protoze bereme 2 sousedici indexy a na konci bychom dostali "IndexOutOfRange" error
            for (int a = 0; a < arr.Length - 1; a++)
            {
                for (int b = 0; b < arr.Length - 1; b++)
                {
                    if (arr[b] > arr[b + 1])  // Koukej hlavne po tom znamenku ">", je vetsi nez
                    {
                        // Prohozeni promennych
                        int pomoc = arr[b];
                        arr[b] = arr[b + 1];
                        arr[b + 1] = pomoc;
                    }
                }
            }

            // Vratim serazene pole
            return arr;
        }


        /// <summary>
        /// Metoda, ktera si bere jako parametr pole integeru, ktere seradi vzestupne a vrati.
        /// Funguje tak, ze hleda nejvetsi index v poli a ten prohodi s poslednim indexem v hledane oblasti, 
        /// vse za hledanou oblasti je uz serazene.
        /// Po kazdem pruchodu se hledana oblast zmensi o jeden index, serazena oblast se o jeden zvetsi.
        /// </summary>
        /// <param name="arr"> Pole, ktere chceme seradit </param>
        /// <returns></returns>
        static int[] SelectionSort(int[] arr)
        {
            // Vnejsi tridici cyklus
            for (int a = arr.Length; a > 0; a--)
            {
                // Nastavujeme nulty "pivotni" index v poli, abychom zjistili nejvetsi index v poli
                int indexOfBiggestNumber = 0;


                // Zaciname od jednicky, protoze nulty index uz mame o 3 radky vys ulozeny, tudiz nema smysl porovnavat samo se sebou
                for (int b = 1; b < a; b++)
                {
                    // Ziskame index nejvetsiho cisla v poli
                    if(arr[indexOfBiggestNumber] < arr[b])
                    {
                        indexOfBiggestNumber = b;
                    }
                }

                // Prohodime nejvyssi index v poli s poslednim indexem v poli
                // arr[a - 1] je posledni index v hledane oblasti, odecitam jednicku jinak hodi "IndexOutOfRange" error
                int pomoc = arr[indexOfBiggestNumber];
                arr[indexOfBiggestNumber] = arr[a - 1];
                arr[a - 1] = pomoc;
            }

            // Vratime pole
            return arr;
        }
    }
}
