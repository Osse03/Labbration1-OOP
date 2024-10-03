using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schemssystem_modell
{
    public class SchemaRad
    {
        public object kursTillfäller;

        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public string Moment { get; set; }
        public Kurs Kurs { get; set; }
        public Lokal Lokal { get; set; }
        public KursTillfälle KursTillfäller { get; set; }

        public SchemaRad()
        {
            KursTillfäller = new KursTillfälle();
            Kurs = new Kurs();
            Lokal = new Lokal();
        }

    }
}
