using System;


namespace BiisiGeneraattori
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Biisigeneraattori v.1.0");
            //lisätty edustaväri
            Console.ForegroundColor = ConsoleColor.Green;

            while (true)
            {
                Console.WriteLine(" Komennot:");
                Console.WriteLine(" [ 1 ] - Kappalelista\n [ 2 ] - Etsi hakusanalla\n [ 3 ] - Valitse satunnainen kappale" +
                    "\n [ 4 ] - Lisää kappale\n [ 5 ] - Poista kappale\n [ 0 ] - Lopeta");
                string question = Console.ReadLine();

                if (question == "1")
                {

                    Kappale KaikkiBiisit = new Kappale();
                    // metodin kutsu Kappale -luokasta
                    KaikkiBiisit.printAll();
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }
                else if (question == "2")
                {
                    Kappale HakuSana = new Kappale();
                    HakuSana.searchWord();
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }

                else if (question == "3")
                {
                    Kappale SatunnainenKappale = new Kappale();
                    SatunnainenKappale.ShuffleAlbum();
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }
                else if (question == "4")
                {
                    Kappale LisaaKappale = new Kappale();
                    LisaaKappale.AddKappale();
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }
                else if (question == "5")
                {
                    Program poista = new Program();
                   // poista.RemoveAlbum();
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }


                else if (question == "0")
                {
                    Console.WriteLine("You go exit! Goodbye.");
                    Console.WriteLine("Press enter to quit.");
                    break;
                }
              /*  else
                {
                    Console.WriteLine();
                    Console.WriteLine("You go exit!");
                    Console.WriteLine("Press enter to quit.");
                    break;
                }*/

            }
           /* Console.WriteLine("paina Enter lopetaaksesi ohjelma.");*/
            Console.ReadLine();


        }




    }
}
