using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICRUDeable
    {

        object add(object obj);

        object get(object obj);

        List<object> getAll(object obj);

        object put(object obj);

        object delete(object obj);



    }
}
