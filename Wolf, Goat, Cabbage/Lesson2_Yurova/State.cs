using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson2_Yurova.FoundSolution;

namespace Lesson2_Yurova
{
/// <summary>
/// Состояние в дереве
/// </summary>
    public class State
    {
        public List<FoundSolution.Item> right { get; set; }
        public List<FoundSolution.Item> left { get; set; }
        public FoundSolution.Item boat { get; set; }
        public State Parent;

        internal State(List<FoundSolution.Item> lNew, FoundSolution.Item bNew, List<FoundSolution.Item> rNew, State p) 
        {
            this.left = lNew;
            this.boat = bNew;
            this.right = rNew;
            this.Parent = p;
        }

        internal State()
        {
            this.left = new List<Item>();
            this.right = new List<Item>();
            this.Parent = null;
            this.boat = Item.Nothing;
        }

        internal State(State s) 
        {
            this.left = new List<FoundSolution.Item>(s.left);
            this.boat = s.boat;
            this.right = new List<FoundSolution.Item>(s.right);
            this.Parent = s.Parent;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            State st = obj as State;
            if (st as State == null)
                return false;
            return (new HashSet<Item>(st.right).SetEquals(this.right)) && (new HashSet<Item>(st.left).SetEquals(this.left)) && (st.boat == this.boat) ; // && (st.Parent != this.Parent);
        }

        //функция печати узла
        internal String Print()
        {
            StringBuilder str = new StringBuilder(" #[ ");
            foreach (var item in left)
            {
                str.Append(item.ToString() + " ");
            }
            str.Append("], [ ");
            str.Append(boat.ToString());
            str.Append("], [ ");
            foreach (var item in right)
            {
                str.Append(item.ToString() + " ");
            }
            str.Append("]#\n ");
            return str.ToString();
        }


    }
}
