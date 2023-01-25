using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
// Add EASendMail namespace
using EASendMail;

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
                var Pos = csvReader.GetField(0);
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
                Console.WriteLine("Anna jokin sana, etsitään kappaleet listalta! [ q! ] = Quit.");
                Console.WriteLine("Hakusanasi: ");
                string NameCheck = Console.ReadLine();
                string[] names = File.ReadAllLines("kappalelista.csv");
                foreach (string x in names)
                {
                    if (x.Contains(NameCheck))
                    {
                        string[] pieces = x.Split(";");
                        Console.WriteLine(" [ " + NameCheck + " ] Löytyy seuraavat kappaleet -> Artisti ja kappale: " + pieces[1] + " - " + pieces[2] + " -> Youtube linkki: " + pieces[3]);

                        //Console.WriteLine("[ " + NameCheck + " ] Löytyy seuraavat kappaleet -> [" + x + "] ");
                    }
                }

                if (NameCheck == "q!")
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
                        Console.WriteLine($"Artisti: {palaset[1]} • Kappale: {palaset[2]}\nLinkkisi Youtubeen: {palaset[3]}");
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
                    // Id numero pidetään piilossa kaikissa tuloksissa!

                    newLines.Add($"99;{AddArtisti};{AddKappale};{AddYoutubeLink}");

                    File.AppendAllLines("kappalelista.csv", newLines);

                    Console.WriteLine("Onneksi olkoon!");
                    Console.WriteLine($"Lisätty {AddArtisti} - {AddKappale} onnistuneesti Biisigeneraattoriin!");
                    break;

                }

                else if (question == "0")
                {
                    break;
                }


            }

        }

        public void RemoveKappale()
        {
            Console.WriteLine("Poistetaan kappale!");
            var file = new List<string>(System.IO.File.ReadAllLines("kappalelista.csv"));
            Console.WriteLine("Anna rivinumero, joka poistetaan: ");

            int rowremove = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Oletko varma? Paina Enter jatkaaksesi tai [Q] - quit.");
            string confirmRemove = Console.ReadLine();

            if (confirmRemove == "Q")
            {
                Console.WriteLine("Poistutaan.");
                
            }
            else
            {
                file.RemoveAt(rowremove);
                File.WriteAllLines("kappalelista.csv", file.ToArray());
                Console.WriteLine("Poistettu listasta onnistuneesti rivinumero: " + rowremove);
            }
        }

        public void ContactForm()
        {
            Console.WriteLine("Anna palautetta. ( Tarkista koodista ensin mailiasetukset !!! ennen kuin lähetät !!! )");

            Console.WriteLine("Etunimi tai nimimerkki: ");
            string YourName = Console.ReadLine();

            Console.WriteLine("Anna viestisi: ");
            string FeedBack = Console.ReadLine();
            Console.WriteLine("Press Enter ja lähetä email!");
            Console.ReadKey();

            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                // tämä voi olla jotakin muutakin, ei näy viestissä
                oMail.From = "etunimi.sukunimi@gmail.com";

                // Set recipient email address
                // Vastaanottajan email-osoite
                oMail.To = "firstname.lastname@gmail.com";

                // Set email subject
                oMail.Subject = "Palautelomake saapunut!";

                //string fileLogo = "Logo.png";
                // Add image attachment from local disk
                // se pitää olla bin/debug/net6.0 kansiossa !!
                Attachment resource = oMail.AddAttachment("Logo.png");
                Attachment resource2 = oMail.AddAttachment("Kuva2.png");

                // Specifies the attachment as an embedded image
                // contentid can be any string.

                // string contentID = "test001@host";
                resource.ContentID = "logo_object_1";
                resource2.ContentID = "logo_object_2";

                // Set email body
                // oMail.TextBody = "Nimi: " + YourName + " Antoi seuraavan palautteen: " + FeedBack;
                oMail.HtmlBody = "<body style=\"background-color:yellow;\">" +
                    "<img src=\"cid:logo_object_2\">" +
                    "<h1> Asiakaspalaute BiisiGeneraattorista! </h1>" + "<br>" +
                    "<p>Lähettäjän nimi tai nimimerkki: </p>" + YourName + "<br>" +
                    "<p>Asiakaspalaute: </p>" + FeedBack + "<br>" +
                    "<img src=\"cid:logo_object_1\">";


                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");

                // Gmail user authentication
                // For example: your email is "test@gmail.com", then the user should be the same
                oServer.User = "firstname.lastname@gmail.com";

                // Create app password in Google account
                // https://support.google.com/accounts/answer/185833?hl=en
                oServer.Password = "set-your-password-here";

                // If you want to use direct SSL 465 port,
                // please add this line, otherwise TLS will be used.
                // oServer.Port = 465;

                // set 587 TLS port;
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }
    }
    }
