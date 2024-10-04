namespace Schemssystem_modell
{
    public class Utibildning
    {
        public string UtbildningsNamn { get; set; }
        public string Akronym { get; set; }
        public List<Kurs> Kurser { get; set; }

        public Utibildning(string utbildningsNamn, string akronym) 
        {
            UtbildningsNamn = utbildningsNamn;
            Akronym = akronym;

        }

    }
}
