using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1336.Model
{
    public class OrderRow
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int NomenclatureId { get; set; }
        public Nomenclature Nomenclature { get; set; }
        [Required]
        public double Quantity { get; set; }

        ///////////////////////////////////////////////////////////////////////
        public string DepartmentsStr
        {
            get
            {
                if (Nomenclature?.Departments == null || Nomenclature.Departments.Count == 0)
                {
                    return "";
                }
                string res = Nomenclature.Departments[0].ToString();
                for (int i = 1; i < Nomenclature.Departments.Count; i++)
                {
                    res += ", " + Nomenclature.Departments[i];
                }
                return res;
            }
        }
    }
}
