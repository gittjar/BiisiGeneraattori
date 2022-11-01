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

                // Console.WriteLine($"{Row}# Albumi: {Artist} : {Album} --- Julkaistu: {Publish} --- Record Label: {Label}");
                Console.WriteLine($"Artisti: {Artist} -- Kappale: {Biisi} -- Link to Youtube: {Youtube}");
            }
        }
    }
}