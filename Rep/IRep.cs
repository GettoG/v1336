using System.Collections.Generic;
using v1336.Model;

namespace v1336.Rep
{
    public interface IRep
    {
        IEnumerable<IDbObject> GetAll();
        IDbObject GetById(int id);
        void Add(IDbObject obj);
        void Update(IDbObject obj);
        void Delete(IDbObject obj);
    }
}
