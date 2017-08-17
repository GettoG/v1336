using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using v1336.Model;

namespace v1336.Rep
{
    public class DepartmentRep
    {
        private ObservableCollection<Department> _departments;

        public ObservableCollection<Department> AllDepartments
        {
            get
            {
                if (_departments == null)
                    _departments = GenerateDepartmentsRep();
                return _departments;
            }
        }

        private ObservableCollection<Department> GenerateDepartmentsRep()
        {
            ObservableCollection<Department> departments = new ObservableCollection<Department>();
            return departments;
        }
    }
}
