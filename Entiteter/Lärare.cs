
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schemssystem_modell
{
    public class Lärare : Person
    {
        public string LärareID { get; set; }
        public int TelefonNr { get; set; }
        public string Signatur { get; set; }




        public Lärare(string lärareID, string förNamn, string efterNamn, string epost, int telefonNr, string signatur)
        {
            this.LärareID = lärareID;
            this.FörNamn = förNamn;
            this.EfterNamn = efterNamn;
            this.Epost = epost;
            this.TelefonNr = telefonNr;
            this.Signatur = signatur;
        }
        public static Lärare LogIn(List<Lärare> lärare)
        {
            while (true) // Loopa tills inloggningen är korrekt
            {
                Console.Clear();
                Console.Write("\nLärareID: ");
                string enterName = Console.ReadLine().ToUpper();
                Console.Write("Förnamn: ");
                string enteredPincode = Console.ReadLine();

                // Kontrollera att inmatningen inte är null eller tom
                if (!string.IsNullOrEmpty(enterName) && !string.IsNullOrEmpty(enteredPincode))
                {
                    // Sök efter läraren i listan
                    Lärare loggedInAdmin = lärare.FirstOrDefault(a => a.LärareID == enterName && a.FörNamn == enteredPincode);

                    if (loggedInAdmin != null) // Om läraren hittas
                    {
                        Console.Clear();
                        Console.WriteLine($"\nInloggning lyckad, välkommen {loggedInAdmin.FörNamn.ToUpper()}!");
                        Console.WriteLine("\nInformation hämtas...");
                        Thread.Sleep(2000); // Simulera väntetid
                        return loggedInAdmin; // Avsluta loopen och returnera läraren
                    }
                    else // Felaktiga inloggningsuppgifter
                    {
                        Console.WriteLine("\nFelaktiga inloggningsuppgifter. Försök igen.");
                        Console.WriteLine("Tryck på Enter för att försöka igen.");
                        Console.ReadLine(); // Vänta på att användaren trycker Enter innan vi försöker igen
                    }
                }
                else
                {
                    // Hantera tom eller ogiltig inmatning
                    Console.WriteLine("\nInloggning misslyckades. Ange giltigt LärareID och Förnamn.");
                    Console.WriteLine("Tryck på Enter för att försöka igen.");
                    Console.ReadLine();
                }
            }
        }

    }
}