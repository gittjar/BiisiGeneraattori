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
                Console.WriteLine("Anna jokin sana, etsitään kappaleet listalta! Q = Quit.");
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
    }

}