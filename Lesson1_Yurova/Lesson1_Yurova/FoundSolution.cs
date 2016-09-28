using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_Yurova
{
    public class FoundSolution
    {
        long maxStep = 100000;

        public int countOper = 0;


        public string StartFound(int firstNum, int lastNum, params Func<int,int>[] operation)
        {
            var strResult = new StringBuilder();
            var tree = new TreeNode(firstNum);
            var queueState = new Queue<State<int>>();
            var listState = new List<int>();

            queueState.Enqueue(tree.HeadNode);
            while(queueState.Count != 0)
            {
                var current = queueState.Dequeue();
                listState.Add(current.Value);

                if(current.Value == lastNum)
                {
                    while(current.Parent != null)
                    {
                        strResult.AppendFormat("{0} <- {1} ", current.Value, current.Operation);
                        countOper++;
                        current = current.Parent;
                    }
                    strResult.AppendFormat("{0}", current.Value);

                    return strResult.ToString();
                }

                foreach(var op in operation)
                {
                    var AddedState = op(current.Value);
                    if (listState.Contains(AddedState) || countOper >= maxStep)
                        break;

                    queueState.Enqueue(new State<int>(AddedState, current, op.Method.Name));
                }
            }

            return "";
        }


    }
}
