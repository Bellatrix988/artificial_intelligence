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
       
        int countOper = 0;
        int maxStep = 100000;

        /// <summary>
        /// проверка на то, можно ли объектам оставаться вместе        
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
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

        #region BFS

        public string BFS(State StartNode, State GoalState)
        {
            var strResult = new StringBuilder("\n"); // строка результата
            var q = new Queue<State>();
            q.Enqueue(StartNode);
            var current = _BFS(q, new List<State>(q), GoalState);
            while (current.Parent != null)
            {
                strResult.AppendFormat("{0} ", current.Print());
                //countOper++;
                current = current.Parent;
            }
            strResult.AppendFormat("{0}", current.Print());
            return strResult.ToString();
        }

        private Queue<State> _BuildChild(State current, List<State> listState)
        {

            Queue<State> queueState = new Queue<State>();

            //если оставшиеся на левом берегу могут съесть друг друга, то рассматриваем другой вариант
            if (isEaten(current.left) && current.boat != Item.Nothing)
                return queueState;// continue;
            else
            {
                if(current.boat != Item.Nothing)
                {
                    var rightSide = new List<Item>(current.right);
                    rightSide.Add(current.boat);
                    var AddedState = new State(current.left, Item.Nothing, rightSide, current);
                    if (listState.Contains(AddedState))
                    {
                        var leftSide = new List<Item>(current.left);
                        leftSide.Add(current.boat);
                        AddedState = new State(leftSide, Item.Nothing, current.right, current);
                    }
                    queueState.Enqueue(AddedState);
                    return queueState;
                }
            }

            //если на правом берегу возможны потери объекта
            if ((current.right.Count > 1) && (isEaten(current.right)))
            {
                foreach (var item in current.right)
                {
                    var cur = new List<Item>(current.right);
                    cur.Remove(item);
                    var AddedState = new State(current.left, item, cur, current);
                    if (listState.Contains(AddedState) || countOper >= maxStep)
                        break;
                    queueState.Enqueue(AddedState);
                }
            }
            else
            {
                foreach (var item in current.left)
                {
                    var cur = new List<Item>(current.left);
                    cur.Remove(item);
                    var AddedState = new State(cur, item, current.right, current);
                    if (listState.Contains(AddedState) || countOper >= maxStep)
                        break;
                    queueState.Enqueue(AddedState);
                }
            }

            return queueState;
        }

        private State _BFS(Queue<State> queueState, List<State> listState, State goalState)
        {
            while (queueState.Count != 0)
            {
                var current = queueState.Dequeue();     //Извлекли текущее состояние

                //если на правом берегу все животные
                if (current.Equals(goalState))
                    return current;

                ///получаем потомков
                var ChildCurrent = _BuildChild(current, listState);

                foreach(var child in ChildCurrent)
                    if (!listState.Contains(child))
                    {
                        queueState.Enqueue(child);
                        listState.Add(child);
                    }
            }
            return new State();
        }

        #endregion

        #region  DFS

        public string DFS(State StartNode, State GoalState)
        {
            var strResult = new StringBuilder("\n"); // строка результата
            var q = new Stack<State>();
            q.Push(StartNode);
            var current = _DFS(q, new List<State>(q), GoalState);
            while (current.Parent != null)
            {
                strResult.AppendFormat("{0} ", current.Print());
                current = current.Parent;
            }
            strResult.AppendFormat("{0}", current.Print());
            return strResult.ToString();
        }

        private State _DFS(Stack<State> queueState, List<State> listState, State goalState)
        {
            while (queueState.Count != 0)
            {
                var current = queueState.Pop();     //Извлекли текущее состояние

                //если на правом берегу все животные
                if (current.Equals(goalState))
                    return current;

                ///получаем потомков
                var ChildCurrent = _BuildChild(current, listState);

                foreach (var child in ChildCurrent)
                    if (!listState.Contains(child))
                    {
                        queueState.Push(child);
                        listState.Add(child);
                    }
            }
            return new State();
        }

        #endregion

        #region IDDFS

        public void DLS()
        {

        }

        #endregion

    }
}
