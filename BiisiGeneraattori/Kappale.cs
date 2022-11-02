using System;
using System.Formats.Asn1;
using System.Globalization;
using System;
using System.Xml.Linq;
using System.IO;
using System.Reflection.Emit;
using System.Formats.Asn1;
using System.Data;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Drawing;

namespace BiisiGeneraattori
{
    public class Kappale
    {
        public void printAll()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ";",
            };

            using var streamReader = File.OpenText("kappalelista.csv");
            using var csvReader = new CsvReader(streamReader, csvConfig);

            while (csvReader.Read())
            {
                // var Pos = csvReader.GetField(0);
                var Artist = csvReader.GetField(1);
                var Biisi = csvReader.GetField(2);
                var Youtube = csvReader.GetField(3);
                // tulostaa listan
                Console.WriteLine($"Artisti: {Artist} -- Kappale: {Biisi} -- Link to Youtube: {Youtube}");
            }
        }
        public void searchWord()
        {
            while (true)
            {
                Console.WriteLine("Anna jokin sana, etsitään kappaleet listalta! [ Q ] = Quit.");
                Console.WriteLine("Hakusanasi: ");
                string NameCheck = Console.ReadLine();
                string[] names = File.ReadAllLines("kappalelista.csv");
                foreach (string x in names)
                {
                    if (x.Contains(NameCheck))
                    {
                        string[] pieces = x.Split(";");
                        Console.WriteLine("[ " + NameCheck + " ] Löytyy seuraavat kappaleet -> Artisti ja kappale: " + pieces[1] + " - " + pieces[2] + " -> Youtube linkki: " + pieces[3]);

                        //Console.WriteLine("[ " + NameCheck + " ] Löytyy seuraavat kappaleet -> [" + x + "] ");
                    }
                }

                if (NameCheck == "Q")
                {
                    break;
                }
            }
        }

        public void ShuffleAlbum()
        {
            Console.WriteLine("Olen kappaleiden arpoja!");
            // MSDN siteltä löydetty random generaattori
            int iLineCount = File.ReadAllLines("kappalelista.csv").Length;
            System.Random RandNum = new System.Random();
            int iRandomNumber = RandNum.Next(0, iLineCount);
            int iCounter = 0;
            string sName = string.Empty;

            using (StreamReader oReader = new StreamReader("kappalelista.csv"))

            {
                string sLine = string.Empty;
                while (!oReader.EndOfStream)
                {
                    sLine = oReader.ReadLine();
                    iCounter++;
                    if (iCounter == iRandomNumber)
                    {
                        string[] palaset = sLine.Split(';');
                        Console.WriteLine($"Artisti: {palaset[1]} -- Kappale: {palaset[2]} -- Linkkisi Youtubeen: {palaset[3]}");
                        break;
                    }
                }



            }
        }

        public void AddKappale()
        {
            Console.WriteLine("Lisää uusi kappale!");
            List<string> newLines = new List<string>();

            Console.WriteLine("Anna artistin nimi: ");
            string AddArtisti = Console.ReadLine();

            Console.WriteLine($"Anna {AddArtisti}:n kappaleen nimi: ");
            string AddKappale = Console.ReadLine();

            Console.WriteLine($"Anna [{AddArtisti}] - [{AddKappale}] linkki Youtubeen seuraavaksi:");
            string AddYoutubeLink = Console.ReadLine();



            Console.WriteLine($"Lisätäänkö [{AddArtisti}] - [{AddKappale}] varmasti kappaletietokantaan?");

            while (true)
            {
                Console.WriteLine("[ 1 ] - Jatka [ 0 ] - Lopeta");
                string question = Console.ReadLine();

                if (question == "1")
                {

                    // huom add edessä pitää olla järjestysnumero, muuten failaa haku
                    // Järjestystä voi muuttaa valitse {} sisään haettava taulu!

                    newLines.Add($"99;{AddArtisti};{AddKappale};{AddYoutubeLink}");

                    File.AppendAllLines("kappalelista.csv", newLines);

                    Console.WriteLine("Onneksi olkoon!");
                    Console.WriteLine($"Lisätty {AddArtisti} - {AddKappale} onnistuneesti Biisigeneraattoriin!");
            

                }

                else if (question == "0")
                {
                    break;
                }


            }

        }

    }
}

