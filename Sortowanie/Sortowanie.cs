using Sortowanie.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sortowanie.Helper.TNode;

namespace Sortowanie
{
    public class Sortowanie
    {
        private Stack<TNode> stack = new Stack<TNode>();
        List<List<TNode>> list = new List<List<TNode>>();
        public void dfs(TNode root)
        {
            int time = 0;
            init(root);
        }

        private void recursiveDfs(TNode node)
        {

        }


        public void init (TNode node)
        {
            node.Parent = null;
            node.Color = NodeColor.White;
            node.start = 0;
            node.finish = 0;
            foreach (TNode child in node.Children)
            {
                init(child);
            }
        }

        public void start(int n, int e, List<int[]> l)
        {
            for(int x = 1; x <= n; x++)
            {
              //  list.Add(new TNode(x));
            }
        }
    }
}
