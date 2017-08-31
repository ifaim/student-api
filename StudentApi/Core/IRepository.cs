using System;
using System.Collections.Generic;

namespace StudentApi.Core
{
    public interface IRepository <T> where T: IEntityBase
    {
        IEnumerable<T> Get();
        T FindById(int id);
        T Save(T item);
        T Update(int id, T item);
        bool Delete(int id);
    }
}
