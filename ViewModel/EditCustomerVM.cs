using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using v1336.Rep;

namespace v1336.ViewModel
{
    class EditCustomerVM : ViewModelBase
    {
        private CustomerRep rep;
        public EditCustomerVM()
        {
            rep = new CustomerRep();
        }
    }
}
