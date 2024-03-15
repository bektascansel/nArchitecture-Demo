using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand:Entity<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }



         
        //kullanım kolaylıklarını saglamak için 
        public Brand() { 
           
            Models=new HashSet<Model>();
        
        }

        public Brand(Guid id,string name):this()
        {
            Id = id;
            Name = name;
        }



    }
}
