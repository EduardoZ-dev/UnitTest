﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public interface IBaseService<T> where T : class
    {
        int Create(T entity);

        bool Update(int id, T entity);

        bool Delete(int id);

        T? Get(int id);

        List<T> GetAll(
            string key = "", 
            string opera="=",
            string value = "");
    }
}
