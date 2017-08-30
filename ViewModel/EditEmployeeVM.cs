using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using v1336.Rep;
using v1336.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using v1336.View;

namespace v1336.ViewModel
{
    class EditEmployeeVM : ViewModelBase
    {
        private EmployeeRep rep;
        public EditEmployeeVM()
        {
            rep = new EmployeeRep();
            Departments = new DepartmentRep().GetAll();
        }

        public List<Department> Departments { get; set; }
    }
}
