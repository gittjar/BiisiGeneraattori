

namespace BiisiGeneraattori
{
    public class Program
    {
       

        public static void Main(string[] args)
        {
            //lisätty edustaväri
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Biisigeneraattori v.1.0");
            Console.ForegroundColor = ConsoleColor.Green;

            

            while (true)
            {
                Console.WriteLine(" Komennot:");
                Console.WriteLine(" [ 1 ] - Kappalelista\n [ 2 ] - Etsi hakusanalla\n [ 3 ] - Valitse satunnainen kappale" +
                    "\n [ 4 ] - Lisää kappale\n [ 5 ] - Poista kappale\n [ 6 ] - Contact\n [ 0 ] - Lopeta");
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
                    Kappale PoistaKappale = new Kappale();
                    PoistaKappale.RemoveKappale();
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }
                else if (question == "6")
                   {
                       Kappale OtaYhteys = new Kappale();
                       OtaYhteys.ContactForm();
                       Console.WriteLine("");
                       Console.WriteLine("Press any key to continue!");
                       Console.ReadKey();
                   } 







                else if (question == "0")
                {
                    Console.WriteLine("You go exit. Goodbye. See you later!");
                    Console.WriteLine("Press enter to quit.");
                    break;
                }

            }








           
            Console.ReadLine();


        }

    }
}
