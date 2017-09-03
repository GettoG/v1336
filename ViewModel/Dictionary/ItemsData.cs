using System;
using System.Windows;
using v1336.Rep;

namespace v1336.ViewModel
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
            var constructor = WindowType.GetConstructor( new Type[]{ typeof(ItemsListVM), typeof(int) });
            Window res = constructor.Invoke(new object[]{ parentWindowMV, id }) as Window;
            return res;
        }
    }
}
