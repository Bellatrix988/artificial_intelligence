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

            State first = new State(resultState, Item.Nothing, new List<Item>(), null);
            State second = new State(resultState, Item.Nothing, new List<Item>(), first);

            List<Item> te = new List<Item> { Item.Wolf, Item.Goat, Item.Cabbage };

            var main = new FoundSolution();
            //main.StartFound(first);
            Console.WriteLine(main.StartFound(first));
            Console.WriteLine(main.StartFoundDFS(first));
        }
    }
}
