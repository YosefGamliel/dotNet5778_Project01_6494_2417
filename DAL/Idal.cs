using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface Idal
    {
        void add(object obj);
        void remove(object obj);
        void update(object obj);
        List<object> getList();
    }
}
