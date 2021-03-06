﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie.Helper
{

    public partial class TNode
    {
        public enum NodeColor { White, Gray, Black };
        public string Label
        {
            get
            {
                return label.ToString();
            }
        }
        public int label { get; set; }
        public List<TNode> Children { get; set; }
       // public TNode Parent { get; set; }

        public NodeColor Color { get; set; }
        public int start { get; set; }
        public int finish { get; set; }
        public TNode(int label)
        {
            Children = new List<TNode>();
            this.label = label;
        }

        public TNode GetChild(int label)
        {
            return Children.Where(x => x.label == label).FirstOrDefault();
        }
        public TNode FindChild(int label)
        {
            if (this.label == label)
            {
                return this;
            }
           // if (Parent != null && Parent.label == label)
            //{
            //    return Parent;
            //}
            foreach (TNode child in Children)
            {
                var res = child.FindChild(label);
                if (res != null)
                    return res;
            }
            return null;
        }
        public TNode AddChild(int label)
        {
            var node = new TNode(label);
            Children.Add(node);
            return node;
        }
        public TNode AddChild(TNode child)
        {
            // child.Parent = this;
            Children.Add(child);
            return this;

        }
        public void RemoveChild(TNode node)
        {

            Children.RemoveAll(x => x.label == node.label);
        }

        public void RemoveChildInRoot(TNode node)
        {
            foreach (TNode child in Children)
            {
                if (child == node)
                {
                    RemoveChild(node);
                    return;
                }
                child.RemoveChildInRoot(node);
            }

        }

        public static int CountVertices(TNode node)
        {
            int counter = 1;
            foreach (var child in node.Children)
            {
                counter += CountVertices(child);
            }
            return counter;
        }

        public TNode FindLowestLeaf()
        {

            if (Children.Count == 0) return this;

            TNode currentNode = GetLowestNode(this, null);
            //sprawdzenie dla dzieci
            for (var x = 0; x < Children.Count; x++)
            {
                TNode childLowestNode = GetLowestNode(Children[x], currentNode);
                if (childLowestNode != null)
                {
                    if (childLowestNode.label < currentNode.label)
                    {
                        currentNode = childLowestNode;
                    }
                }
            }
            return currentNode;


        }
        private TNode GetLowestNode(TNode node, TNode currentLowest)
        {
            if (currentLowest == null || (node.label < currentLowest.label))
            {
                if (( node.Children.Count == 0))
                    return node;
            }
            TNode res = null;
            foreach (var child in node.Children)
            {

                res = GetLowestNode(child, currentLowest);

                if (currentLowest == null || (res != null && currentLowest.label > res.label))
                {
                    currentLowest = res;
                }
            }
            return currentLowest;
        }

        public TNode RemoveNodeFormTree(TNode node)
        {
            TNode current = node;
            foreach (var child in current.Children)
            {
                if (child.label == node.label)
                {
                    current.Children.RemoveAll(x => x.label == node.label);
                }
                RemoveNodeFormTree(child);

            }
            return current;
        }
        public override int GetHashCode()
        {
            return label.GetHashCode();
        }
    }
}