using Schemssystem_modell;

namespace schemasystem_funktionalliet
{

    internal class Program
    {
        public static InMemoryDatabase Database = new InMemoryDatabase();

        // Listor för att som innehåller objekt från sin moder klass som hämtas från database
        static List<Lärare> LärarList = Database.HämtaLärare();
        static List<Schema> ListOfSchema = Database.HämtaSchemar();
        static List<Kurs> ListOfKurser = Database.HämtaKurser();
        static List<SchemaRad> ListOfSchemaRad = Database.HämtaSchemaRader();
        static List<Lokal> ListOfLokal = Database.HämtaLokaler();
        static List<KursTillfälle> ListOfKursTillfälle = Database.HämtaKursTillfällen();

        //Objekt av klasserna 
        static Schema schema = new Schema();
        static Kurs kurs = new Kurs();
        static SchemaRad schemarad = new SchemaRad();
        static Lokal lokal = new Lokal();
        static KursTillfälle kurstillfälle = new KursTillfälle();

        static void Main(string[] args)
        {
            StartApp(Database);
        }


        public static void StartApp(InMemoryDatabase database) // metoden för att starta applikationen
        {
            List<Lärare> Teachers = LärarList;

            Console.BackgroundColor = ConsoleColor.Blue; 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            InMemoryDatabase.WelcomeMenu(); //kallar menyn med ascii koden
            Console.WriteLine("\nÄr du Lärare, Student eller systemadmin?" +
                "\n\n[1] Student" +
                "\n[2] Lärare" +
                "\n[3] Systemadmin"); // vi tänkte att ha student och systemadmin för framtida utvecklning 
                                      //och att det mest logisk att lägga till dem när vi skapade ett sånt metod

            string choice = Console.ReadLine();

            switch (choice)// vår fokus var på att lärare ska kunna skapa en hel schema med sin innehåll.
            {               
                case "1":
                    Console.Clear();

                    Console.WriteLine("Welcome student");
                    Console.WriteLine("OBS: Utvecklingen är inte färdigt");
                    Console.WriteLine("\nTryck på valfri knapp för att gå till start sidan");
                    Console.ReadKey();
                    StartApp(database);
                    break;  
                case "2":
                    Console.Clear();
                    Console.WriteLine("Welcome Lärare");
                    Lärare logginLärare = Lärare.LogIn(Teachers);
                    LärareMenu(database);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Welcome SystemAdmin");
                    Console.WriteLine("OBS: Utvecklingen är inte färdigt");
                    Console.WriteLine("\nTryck på valfri knapp för att gå till start sidan");
                    Console.ReadKey();
                    StartApp(database);
                    break;
            }
            Console.ReadKey();


        }
        public static void LärareMenu(InMemoryDatabase database) // Lärare menu efter hen har loggat in.
        {
            bool FortsättKöra = true;

            while (FortsättKöra)
            {

                Console.WriteLine("Welcome to school system");
                Console.WriteLine("1. Skapa Schema");
                Console.WriteLine("2. Vissa Upp Scehma");
                Console.WriteLine("3. Avsluta programmet ");

                //Switch case to choose the option
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        SkapaHelaSchema(schema, schemarad);

                        break;
                    
                    case "2":
                        Console.Clear();
                        VisaAllaSchema(ListOfSchema,ListOfSchemaRad);
                        break;
                    case "3":
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Tack för din anvädning :)");
                        Console.WriteLine("-------------------------");
                        FortsättKöra = false;

                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        public static void SkapaHelaSchema(Schema newSchema,SchemaRad schemaRad)//skapa objekt för att fylla data i.
        {
            // frågar användare sedan sparas det i sin egenskaper
            Console.WriteLine("Ange namn på schema: ");
            newSchema.SchemaNamn = Console.ReadLine();

            Console.WriteLine($"Schemat {newSchema.SchemaNamn} skapat.");

            Console.WriteLine("\n\nAnge namn på kursen: ");
            schemaRad.Kurs.KursNamn = Console.ReadLine();

            Console.WriteLine("Ange namn på kursens Akronym: ");
            schemaRad.Kurs.Akronym = Console.ReadLine();

            Console.WriteLine("Ange namn på moment: ");
            schemaRad.Moment = Console.ReadLine();

            Console.WriteLine("Ange start datum för schemaraden ÅÅÅ-MM-DD HH:MM: ");
            schemaRad.StartDatum = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ange start datum för schemaraden ÅÅÅ-MM-DD HH:MM: ");
            schemaRad.SlutDatum = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ange numret på Lokalen: ");
            schemaRad.Lokal.LokalNummer = Console.ReadLine();

            Console.WriteLine("Ange antal platser i Lokalen: ");
            schemaRad.Lokal.Plaster = int.Parse(Console.ReadLine());

            Console.WriteLine("Ange start datum för kursTillfället ÅÅÅ-MM-DD ");
            schemaRad.KursTillfäller.StartPeriod = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ange slut datum för kursTillfället ÅÅÅ-MM-DD ");
            schemaRad.KursTillfäller.SlutPeriod = DateTime.Parse(Console.ReadLine());


            // spara innehållet av data i listan
            ListOfSchemaRad.Add(schemaRad);
            ListOfSchema.Add(newSchema);

        }

                     

        public static void VisaAllaSchema(List<Schema> schemas,List<SchemaRad> schemaRads) // listor med scheman och schemarader

        {

            foreach (var schema in schemas)
            {
                // Skriv ut schemats namn
                Console.WriteLine($"Schema Namn: {schema.SchemaNamn}");

                // Iterera över varje schemarad i detta schema
                foreach (var schemaRad in schemaRads)
                {
                    // Skriv ut schemaradens detaljer
                    Console.WriteLine($"\tMoment: {schemaRad.Moment}");
                    Console.WriteLine($"\tStartdatum: {schemaRad.StartDatum}, Slutdatum: {schemaRad.SlutDatum}");

                    // Skriv ut kursens detaljer
                    Console.WriteLine($"\tKurs Namn: {schemaRad.Kurs.KursNamn}, Akronym: {schemaRad.Kurs.Akronym}");

                    // Skriv ut lokalens detaljer
                    Console.WriteLine($"\tLokal: {schemaRad.Lokal.LokalNummer}, Kapacitet: {schemaRad.Lokal.Plaster}");

                    // Skriv ut kurstillfällets detaljer
                    Console.WriteLine($"\tKursTillfälle Start: {schemaRad.KursTillfäller.StartPeriod}, Slut: {schemaRad.KursTillfäller.SlutPeriod}");
                }

                // Lägg till en tom rad för att separera olika scheman
                Console.WriteLine();
            }
        }


        
    }
}
