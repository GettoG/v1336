using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using v1336.Rep;
using v1336.View.CRUD;

namespace v1336.ViewModel.CRUD
{
    public class ItemsData
    {
        public ItemsData() { }
        
        public ItemsData(string title, IRep rep, Type windowType)
        {
            Title = title;
            Rep = rep;
            WindowType = windowType;
        }

        public string Title { get; set; }
        public IRep Rep { get; set; }
        public Type WindowType { get; set; }

        public Window GetWindow(ItemsListVM parentWindowMV, int id)
        {
            var constructor = WindowType.GetConstructor(new Type[]{ typeof(ItemsListVM), typeof(int) });
            Window res = constructor.Invoke(new object[]{ parentWindowMV, id }) as Window;
            return res;
        }
    }
}
