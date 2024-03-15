using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic
{
    //yardımcı class
    public class Filter
    {
        //filtre hangi alan üzerinde çalışacak mesela yakıt tipi
        //Vites tipi
        public string Field {  get; set; }

        //bu fieldin degeri
        //otomatik
        public string? Value { get; set; }

        //operator ne olacak
        //eşittir
        public string  Operator { get; set; }
        //and or için logic
        public string? Logic { get; set; }

        //bir filtereye başka filtreler uygulamak istiyoruz.
        //filtere içerisinde ayrı filtre verilebilir
        public IEnumerable<Filter>? Filters { get; set;}


        public Filter() { 
        
          Field=string.Empty; 
            
          Operator=string.Empty;
        
        }

        //yardımcı constructorlar
        public Filter(string field, string @operator)
        {
            Field=field;
            Operator = @operator;
        }


    }
}
