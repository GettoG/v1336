using System.Collections.Generic;
using v1336.Model;

namespace v1336.Rep
{
    public abstract class AbstractRep<T> : IRep where T : class, IDbObject
    {
      
        IDbObject IRep.GetById(int id)
        {
            return GetById(id);
        }

        void IRep.Add(IDbObject obj)
        {
            Add(obj as T);
        }

        void IRep.Update(IDbObject obj)
        {
            Update(obj as T);
        }

        void IRep.Delete(IDbObject obj)
        {
            Delete(obj as T);
        }

        IEnumerable<IDbObject> IRep.GetAll()
        {
            return GetAll();
        }
       

        public abstract IEnumerable<T> GetAll();
        public abstract T GetById(int id);
        public abstract void Add(T obj);
        public abstract void Update(T obj);
        public abstract void Delete(T obj);
    }
}
