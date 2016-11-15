using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_Yurova
{
   public class State<T>
    {
        public  Value { get; }
        public State<T> Parent;
        public string Operation;

        internal State(T v, State<T> p,string op)
        {
            this.Value = v;
            this.Parent = p;
            this.Operation = op;
        } 


    }
}
