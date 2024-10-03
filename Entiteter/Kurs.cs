
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schemssystem_modell
{
    public class Kurs
    {
        public string KursNamn { get; set; }

        public string Akronym { get; set; }


        public Schema Schema { get; set; }

        public List<KursTillfälle> KursTillfälles { get; set; }
        public Utibildning Utibildning { get; set; }


        


    }
}
