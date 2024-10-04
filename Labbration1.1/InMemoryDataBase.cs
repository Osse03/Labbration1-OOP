
using Schemssystem_modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schemasystem_funktionalliet
{
    public class InMemoryDatabase
    {
        public List<Person> Personer { get; set; } = new List<Person>();
        public List<Kurs> Kurser { get; set; } = new List<Kurs>();
        public List<Schema> Schemar { get; set; } = new List<Schema>();
        public List<SchemaRad> SchemaRader { get; set; } = new List<SchemaRad>();
        public List<Lärare> Lärarer { get; set; } = new List<Lärare>();
        public List<KursTillfälle> KursTillfäller { get; set; } = new List<KursTillfälle>();
        public List<Lokal> Lokaler { get; set; } = new List<Lokal>();
        public List<Utibildning> Utibildninger { get; set; } = new List<Utibildning>();


        public List<Lärare> HämtaLärare()
        {
            List<Lärare> Lärarer = new List<Lärare>()
            {
                new Lärare ("V123", "Varto", "Kaka", "varto.kaka@hotmail.com", 072458448, "VK123"),
                new Lärare ("O123", "Osama", "Alhusasin","osama.alhussain@hotmail.com", 0724584765, "OA123")
               

            };

            return Lärarer;
        }
        public List<Schema> HämtaSchemar()
        {
            List<Schema> Schemar = new List<Schema>()
            {

            };
           
            return Schemar;
        }
        //  method that returns a list ofSchemaRader
        public List<SchemaRad> HämtaSchemaRader()
        {
            List<SchemaRad> SchemaRader = new List<SchemaRad>()
            {
 
            };

           
            return SchemaRader;
        }

        public List<Kurs> HämtaKurser()
        {
            List<Kurs> Kurser = new List<Kurs>()
            {

            };
           
            return Kurser;
        }

        public List<Utibildning> HämtaUtbildningar()
        {
            List<Utibildning> Utibildninger = new List<Utibildning>()
            {
                new Utibildning ("Systemvetare","SSY")

            };

            return Utibildninger;
        }
        public List<KursTillfälle> HämtaKursTillfällen()
        {
            List<KursTillfälle> KursTillfäller = new List<KursTillfälle>()
            {

            };
           

            return KursTillfäller;

        }
        public List<Lokal> HämtaLokaler()
        {
            List<Lokal> Lokaler = new List<Lokal>()
            {
   

            };

           
            return Lokaler;
        }




        public static void WelcomeMenu()
        {
            Console.Beep();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n         Welcome to School System" +
            "\n         ----------------------------" +
            "\n                 _ _.-'`-._ _\r\n                ;.'________'.;\r\n     _________n.[____________].n_________\r\n    |\"\"_\"\"_\"\"_\"\"||==||==||==||\"\"_\"\"_\"\"_\"\"]\r\n    |\"\"\"\"\"\"\"\"\"\"\"||..||..||..||\"\"\"\"\"\"\"\"\"\"\"|\r\n    |LI LI LI LI||LI||LI||LI||LI LI LI LI|\r\n    |.. .. .. ..||..||..||..||.. .. .. ..|\r\n    |LI LI LI LI||LI||LI||LI||LI LI LI LI|\r\n ,,;;,;;;,;;;,;;;,;;;,;;;,;;;,;;,;;;,;;;,;;,,\r\n;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;");

            Console.WriteLine("\nTryck enter för att logga in!");
            Console.ReadKey();
        }

    }
}
