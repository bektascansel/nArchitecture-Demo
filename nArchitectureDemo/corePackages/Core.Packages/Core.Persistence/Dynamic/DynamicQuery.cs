using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic
{
    public class DynamicQuery
    {
        //sıralama degerimiz 
        public IEnumerable<Sort>? Sort { get; set; }

        //filter zaten kendi içerisinde filter listesi alır onun için liste yapmadık
        public Filter? Filter { get; set; }


        public DynamicQuery()
        {

        }

        public DynamicQuery(IEnumerable<Sort>? sort, Filter? filter)
        {
            Filter = filter;
            Sort = sort;
        }


    }
}


