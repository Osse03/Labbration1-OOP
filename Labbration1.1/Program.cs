using Schemssystem_modell;

namespace schemasystem_funktionalliet
{

    internal class Program
    {
        public static InMemoryDatabase Database = new InMemoryDatabase();
        static List<Lärare> LärarList = Database.HämtaLärare();

        static List<Schema> ListOfSchema = Database.HämtaSchemar();
        static List<Kurs> ListOfKurser = Database.HämtaKurser();
        static List<SchemaRad> ListOfSchemaRad = Database.HämtaSchemaRader();
        static List<Lokal> ListOfLokal = Database.HämtaLokaler();
        static List<KursTillfälle> ListOfKursTillfälle = Database.HämtaKursTillfällen();


        static Schema schema = new Schema();
        static Kurs kurs = new Kurs();
        static SchemaRad schemarad = new SchemaRad();
        static Lokal lokal = new Lokal();
        static KursTillfälle kurstillfälle = new KursTillfälle();

        static void Main(string[] args)
        {
            StartApp(Database);
        }


        public static void StartApp(InMemoryDatabase database)
        {
            List<Lärare> Teachers = LärarList;

            Console.BackgroundColor = ConsoleColor.Blue; 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            InMemoryDatabase.WelcomeMenu();
            Console.WriteLine("\nAre you a Lärare, Student eller systemadmin?" +
                "\n\n[1] Student" +
                "\n[2] Lärare" +
                "\n[3] Systemadmin"); 


            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Welcome student");
                    Console.WriteLine("---------------------------");
                    ShowAllSchema(ListOfSchema, ListOfSchemaRad);
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
                    break;
            }
            Console.ReadKey();


        }
        public static void LärareMenu(InMemoryDatabase database)
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
                        SkapaSchema(schema, schemarad);

                        break;
                    
                    case "2":
                        Console.Clear();
                        ShowAllSchema(ListOfSchema,ListOfSchemaRad);
                        break;
                    case "3":
                        Console.WriteLine("Tack för din anvädning :)");
                        FortsättKöra = false;

                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        public static void SkapaSchema(Schema newSchema,SchemaRad schemaRad)
        {
            Console.WriteLine("Ange namn på schema: ");
            newSchema.SchemaNamn = Console.ReadLine();

            Console.WriteLine($"Schemat {newSchema.SchemaNamn} skapat.");


            Console.WriteLine("Ange namn på kursen: ");
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



            ListOfSchemaRad.Add(schemaRad);



            ListOfSchema.Add(newSchema);


        }

                     

        public static void ShowAllSchema(List<Schema> schemas,List<SchemaRad> schemaRads)
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

                    // Skriv ut kurs-tillfällets detaljer
                    Console.WriteLine($"\tKursTillfälle Start: {schemaRad.KursTillfäller.StartPeriod}, Slut: {schemaRad.KursTillfäller.SlutPeriod}");
                }

                // Lägg till en tom rad för att separera olika scheman
                Console.WriteLine();
            }
        }


        
    }
}
