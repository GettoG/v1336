using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v1336.Model
{
    public interface IDbObject
    {
        int Id { get; set; }
        string ToString();
    }
}
