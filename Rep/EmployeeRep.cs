using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using v1336.Model;

namespace v1336.Rep
{
    public class EmployeeRep
    {
        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> AllEmployees
        {
            get
            {
                if (_employees == null)
                    _employees = GenerateEmployeeRep();
                return _employees;
            }
        }

        private ObservableCollection<Employee> GenerateEmployeeRep()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            return employees;
        }
    }
}
