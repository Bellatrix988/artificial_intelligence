using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_Yurova
{
    public class TreeNode
    {
        public State<int> HeadNode;
        public TreeNode(int firstNum)
        {
            this.HeadNode = new State<int>(firstNum, null, "");
        }
    }
}
