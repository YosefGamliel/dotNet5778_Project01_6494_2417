using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface Idal
    {
        void add(object obj);
        void remove(object obj);
        void update(object obj);
        void getList(object obj);
    }
}
