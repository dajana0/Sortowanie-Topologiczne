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
        private Dictionary<TNode, List<TNode>> graf;
        private int time = 0;

        private void recursiveDfs(TNode node)
        {
            node.start = time++;
            node.Color = NodeColor.Gray;
            foreach (var item in graf[node])
            {
                if(item.Color == NodeColor.White)
                {
                    item.Parent = node;
                    item.Parent.AddChild(node);
                    recursiveDfs(item);
                }
            }
            node.Color = NodeColor.Black;
            node.finish = time++;
            stack.Push(node);
        }

        public void dfs()
        {
             
            foreach (var element in graf)
            {
                if(element.Key.Color == NodeColor.White)
                {
                    recursiveDfs(element.Key);
                }
            }
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

        public void start(int n, int e, Dictionary<TNode, List<TNode>> graf)
        {
            this.graf = graf;
            dfs();

        }
    }
}
