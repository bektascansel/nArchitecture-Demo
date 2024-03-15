﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{

    //biz direk sql query ifadesi geçmek istersek diye oluşturuldu.Bazen link ile yazmak zor oluyor
    public interface IQuery<T>
    {

        IQueryable<T> Query();
    }
}
