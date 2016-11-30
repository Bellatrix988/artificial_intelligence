using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson2_Yurova.FoundSolution;

namespace Lesson2_Yurova
{


    class Program
    {

        static void Main(string[] args)
        {
            List<Item> resultState = new List<Item> { Item.Wolf, Item.Goat, Item.Cabbage };

            State StartState = new State(resultState, Item.Nothing, new List<Item>(), null);
            State GoalState = new State(new List<Item>(), Item.Nothing, resultState, null);
            State second = new State(resultState, Item.Nothing, new List<Item>(), StartState);

            List<Item> te = new List<Item> { Item.Wolf, Item.Goat, Item.Cabbage };

            var main = new FoundSolution();
            Console.WriteLine("BFS: \n{0}", main.BFS(StartState, GoalState));
            Console.WriteLine("DFS: \n{0}", main.DFS(StartState, GoalState));
            Console.WriteLine("IDS: \n{0}", main.IDS(StartState, GoalState));

        }
    }
}
