using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_Yurova
{
    public class FoundSolution
    {
        //Волк, коза, капуста и никто
        public enum Item { Wolf, Goat, Cabbage, Nothing};
        //берег - левый и правый
        enum Side { Left, Rigth};
        int countOper = 0;
        int maxStep = 100000;

        //проверка на то, можно ли объектам оставаться вместе        
        bool isEaten(List<Item> vec)
        {
            if (vec.Contains(Item.Cabbage) && vec.Contains(Item.Wolf) && vec.Contains(Item.Wolf))
                return false;
            if (vec.Count == 0)
                return false;
            Item curr = vec[0];
            bool res = false;

            foreach (Item animal in vec)
            {
                if ((curr == Item.Wolf && animal == Item.Goat) || (curr == Item.Goat && animal == Item.Cabbage) || (animal == Item.Goat && curr == Item.Cabbage) || (curr == Item.Goat && animal == Item.Wolf))
                    res =  true;
                if ((curr == Item.Wolf && animal == Item.Cabbage) || (curr == Item.Cabbage && animal == Item.Wolf))
                    res =  false;
                curr = animal;

            }
            return res;
        }

        //Решение поиском в ширину
        public string StartFound(State firstState)
        {
            var strResult = new StringBuilder("\n"); // строка результата

            var queueState = new Queue<State>(); //рассматриваемые состояния

            var listState = new List<State>(); //просмотренные состояния

            queueState.Enqueue(firstState);
            while (queueState.Count != 0)
            {
                countOper++;
                var current = queueState.Dequeue();
                listState.Add(current);
               
                //если оставшиеся на левом берегу могут съесть друг друга, то рассматриваем другой вариант
                if(isEaten(current.left))
                {
                    continue;
                }
                else { 
                    //если в лодке кто-то есть, то его нужно пересадить на правый берег
                    if (current.boat != Item.Nothing)
                    {
                        var test = new State(current);
                        listState.Add(new State(current));

                        test.right.Add(test.boat);
                        test.boat = Item.Nothing;

                        if (listState.Contains(test))
                        {
                            //current.right.Remove(current.boat);
                            current.left.Add(current.boat);
                            current.boat = Item.Nothing;
                        }
                        else
                        {
                            //listState.Add(current);
                            current.right = new List<Item>(test.right);
                            current.boat = Item.Nothing;
                        }
                    }
                }

                //если на правом берегу все животные
                if (current.right.Count == 3)
                {
                    while (current.Parent != null)
                    {
                        strResult.AppendFormat("{0} ", current.Print());
                        countOper++;
                        current = current.Parent;
                    }
                    strResult.AppendFormat("{0}", current.Print());
                    return strResult.ToString();
                }

                //если на правом берегу возможны потери объекта
                if ((current.right.Count > 1) && (isEaten(current.right)))
                {
                    foreach (var op in current.right)
                    {
                        var cur = new List<Item>(current.right);
                        cur.Remove(op);
                        var AddedState = new State(current.left, op, cur, current);
                        if (listState.Contains(AddedState) || countOper >= maxStep)
                            break;
                        queueState.Enqueue(AddedState);
                    }
                }
                    else
                {
                    foreach (var op in current.left)
                    {
                        var cur = new List<Item>(current.left);
                        cur.Remove(op);
                        var AddedState = new State(cur, op, current.right, current);
                        if (listState.Contains(AddedState) || countOper >= maxStep)
                            break;
                        queueState.Enqueue(AddedState);
                    }
                }
            }

            return "";
        }

        //Решение поиском в глубину
        public string StartFoundDFS(State firstState) {

            var strResult = new StringBuilder("\n"); // строка результата
            var queueState = new Stack<State>(); //рассматриваемые состояния
            var listState = new List<State>(); //просмотренные состояния
            queueState.Push(firstState);
            while (queueState.Count != 0)
            {
                countOper++;
                var current = queueState.Pop();
                listState.Add(current);

                //если оставшиеся на левом берегу могут съесть друг друга, то рассматриваем другой вариант
                if (isEaten(current.left))
                {
                    continue;
                }
                else
                {
                    //если в лодке кто-то есть, то его нужно пересадить на правый берег
                    if (current.boat != Item.Nothing)
                    {
                        var test = new State(current);
                        listState.Add(new State(current));

                        test.right.Add(test.boat);
                        test.boat = Item.Nothing;

                        if (listState.Contains(test))
                        {
                            //current.right.Remove(current.boat);
                            current.left.Add(current.boat);
                            current.boat = Item.Nothing;
                        }
                        else
                        {
                            //listState.Add(current);
                            current.right = new List<Item>(test.right);
                            current.boat = Item.Nothing;
                        }
                    }
                }

                //если на правом берегу все животные
                if (current.right.Count == 3)
                {
                    while (current.Parent != null)
                    {
                        strResult.AppendFormat("{0} ", current.Print());
                        countOper++;
                        current = current.Parent;
                    }
                    strResult.AppendFormat("{0}", current.Print());
                    return strResult.ToString();
                }

                //если на правом берегу возможны потери объекта
                if ((current.right.Count > 1) && (isEaten(current.right)))
                {
                    foreach (var op in current.right)
                    {
                        var cur = new List<Item>(current.right);
                        cur.Remove(op);
                        var AddedState = new State(current.left, op, cur, current);
                        if (listState.Contains(AddedState) || countOper >= maxStep)
                            break;
                        queueState.Push(AddedState);
                    }
                }
                else
                {
                    foreach (var op in current.left)
                    {
                        var cur = new List<Item>(current.left);
                        cur.Remove(op);
                        var AddedState = new State(cur, op, current.right, current);
                        if (listState.Contains(AddedState) || countOper >= maxStep)
                            break;
                        queueState.Push(AddedState);
                    }
                }
            }


            return "";
        }

        }
}
