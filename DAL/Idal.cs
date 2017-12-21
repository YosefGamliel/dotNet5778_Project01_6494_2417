using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface Idal
    {
        void add(object obj);
        void remove(object obj);
        void update(object obj);
        void getList(object obj);
    }
}
