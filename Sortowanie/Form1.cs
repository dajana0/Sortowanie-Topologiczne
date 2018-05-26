using Sortowanie.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sortowanie
{
    public partial class Form1 : Form
    {
        TNode root;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            root = new TNode(1);
            TNode c1 = new TNode(2);
            TNode c2 = new TNode(3);
            TNode c3 = new TNode(4);
            TNode c4 = new TNode(5);
            TNode c5 = new TNode(6);
            ArrangeTree();
            root.AddChild(c1);
            c1.AddChild(root);
           // c1.AddChild(c2);
           // root.AddChild(c2);
        }

        private void start(string fileText)
        {
            string[] lines = fileText.Split(new char[] { '\r', '\n' },StringSplitOptions.RemoveEmptyEntries);
            string[] firstLine = lines[0].Split(' ');
            //n e
            int n = int.Parse(firstLine[0]);
            int e = int.Parse(firstLine[1]);
            //rest
            Dictionary<TNode, List<TNode>> dict = initDictionary(n);
            for (int i = 1; i <= e; i++)
            {
                string[] nextLine = lines[i].Split(' ');
                TNode key = dict.Keys.Where(x => x.Label == nextLine[0]).FirstOrDefault();
                TNode value  = dict.Keys.Where(x => x.Label == nextLine[1]).FirstOrDefault();
                dict[key].Add(value);
            }
            Sortowanie sortowanie = new Sortowanie();
            Stack<TNode>  result = sortowanie.start(n, e, dict);
            var s = "";
            while(result.Count != 0)
            {
                TNode node = result.Pop();
                s += "node: " + node.Label + " czas zakończenia: " + node.finish + Environment.NewLine;
            }

        }

        private Dictionary<TNode, List<TNode>> initDictionary(int n)
        {
            Dictionary<TNode, List<TNode>> result = new Dictionary<TNode, List<TNode>>();
            for(int i = 0; i<n; i++)
            {
                result.Add(new TNode(i), new List<TNode>());
            }
            return result;
        }

        private void ArrangeTree()
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                float xmin = 0, ymin = 0;
                root.Arrange(gr, ref xmin, ref ymin);

                // Arrange the tree again to center it horizontally.
                xmin = (this.ClientSize.Width - xmin) / 2;
                ymin = 10;
                root.Arrange(gr, ref xmin, ref ymin);
            }

            picTree.Refresh();
        }

        private void picTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            root.DrawTree(e.Graphics);
        }

        private void picTree_Resize(object sender, EventArgs e)
        {
            ArrangeTree();
        }

        private TNode SelectedNode;

        private void picTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            // Find the node under the mouse.
            FindNodeUnderMouse(e.Location);

            // If there is a node under the mouse,
            // display the context menu.
            if (SelectedNode != null)
            {
                // Don't let the user delete the root node.
                // (The TreeNode class can't do that.)
                usuńWęzełToolStripMenuItem.Enabled = (SelectedNode != root);

                // Display the context menu.
                contextMenuStrip1.Show(this, e.Location);
            }
        }

        private void FindNodeUnderMouse(PointF pt)
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                SelectedNode = root.NodeAtPoint(gr, pt);
            }
        }

        private void dodajWęzełToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NodeTextDialog dlg = new NodeTextDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(dlg.txtNodeText.Text)) return;
                SelectedNode.AddChild(int.Parse(dlg.txtNodeText.Text));

                // Rearrange the tree to show the new node.
                ArrangeTree();
            }
        }

        private void usuńWęzełToolStripMenuItem_Click(object sender, EventArgs e)
        {
            root.RemoveChildInRoot(SelectedNode);

            // Rearrange the tree to show the new structure.
            ArrangeTree();
        }

        private void btPlik_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string text = "";
            openFileDialog1.InitialDirectory = "c:\\Users\\dajan\\Desktop";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                       
                        using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                        {
                            text = sr.ReadToEnd();//all text wil be saved in text enters are also saved
                            start(text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
