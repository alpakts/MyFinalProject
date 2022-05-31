using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constraint : generik kısıt
    //where T:class referans tip olmallı
    //Ientitiy Ientitiy oolmalı
    public interface IEntitiyRepository<T> where T:class,IEntity,new()
    {
                        // filtreleme yapmayı sağlar
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T  Entity);
        void Delete(T Entity);
        void Update(T Entity);
    }
}
