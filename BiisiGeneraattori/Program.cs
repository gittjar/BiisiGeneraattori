using System;


namespace BiisiGeneraattori
{
    public class Program
    {
       


        public static void Main(string[] args)
        {
            Console.WriteLine("Biisigeneraattori v.1.0");


            while (true)
            {
                Console.WriteLine(" [ 1 ] = Kappalelista.\n [ 2 ] = Valitse satunnainen albumi." +
                    "\n [ 3 ] = Lisää albumi.\n [ 4 ] = Poista albumi.\n [ 0 ] = Lopeta.");
                string question = Console.ReadLine();



                if (question == "1")
                {

                    Kappale albumit = new Kappale();
                    albumit.printAll();
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }
                else if (question == "2")
                {
                    Program sekoitus = new Program();
                  //  sekoitus.ShuffleAlbum();
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }
                else if (question == "3")
                {
                    Program lisaa = new Program();
                 //   lisaa.AddAlbum();
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }
                else if (question == "4")
                {
                    Program poista = new Program();
                   // poista.RemoveAlbum();
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }


                else if (question == "0")
                {
                    Console.WriteLine("You go exit!");
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You go exit!");
                    Console.WriteLine("Press enter to quit.");
                    break;
                }

            }
            Console.WriteLine("paina Enter lopetaaksesi ohjelma.");
            Console.ReadLine();


        }




    }
}
