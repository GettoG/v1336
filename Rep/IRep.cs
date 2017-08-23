using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using v1336.Model;

namespace v1336.Rep
{
    public interface IRep
    {
        ObservableCollection<IDbObject> GetAll();
        IDbObject GetById(int id);
        void Add(IDbObject obj);
        void Update(IDbObject obj);
        void Delete(IDbObject obj);
    }
}
