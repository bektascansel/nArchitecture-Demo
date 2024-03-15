using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic
{
    //sıralama 
    //yardımcı class
    public class Sort
    {
        public string Field { get; set; }
        //direction a-z mi z-a mı
        public string Dir {  get; set; }

        public Sort() { 
             
            Field=string.Empty;
            Dir=string.Empty;
        
        }

        public Sort(string field,string dir)
        {

            Field = field;
            Dir = dir;
      

        }

    }
}
