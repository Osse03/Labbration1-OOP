using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schemssystem_modell
{
    public class Schema
    {
        public string SchemaNamn { get; set; }
        public List<SchemaRad> SchemaRader { get; set; }

        public List<Kurs> Kurs { get; set; }
        public Utibildning Utibildning { get; set; }

        public List<Person> Person { get; set; }

        
        public Schema()
        {
            SchemaRader = new List<SchemaRad>();
            
        }
    }
}
