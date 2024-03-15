using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Transmission : Entity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }


        public Transmission()
        {
            Models = new HashSet<Model>();
        }

        public Transmission(Guid id,string name)
        {
                Id = id;
                 Name = name;
        }

    }
}
