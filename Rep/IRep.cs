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
    interface IRep<T>
    {
        ObservableCollection<T> GetAll();
        T GetById(int id);
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
