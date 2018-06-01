﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
namespace Sortowanie.Helper
{
    public partial class TNode
    {

        //     TNode root; Space to skip horizontally between siblings
        // and vertically between generations.
        private const float Hoffset =25;
        private const float Voffset = 25;
        // The node's center after arranging.
        private PointF Center;

        // Drawing properties.
        public Font MyFont = new Font("Times New Roman", 12);
        public Pen MyPen = Pens.Black;
        public Brush FontBrush = Brushes.Black;
        public Brush BgBrush = Brushes.White;


        public void Arrange(Graphics gr, ref float xmin, ref float ymin)
        {
            // See how big this node is.
            SizeF my_size = new SizeF(27.2317677F, 29.7187462F);

            // Recursively arrange our children,
            // allowing room for this node.
            float x = xmin;
            float biggest_ymin = ymin + my_size.Height;
            float subtree_ymin = ymin + my_size.Height + Voffset;
            foreach (TNode child in Children)
            {
                // Arrange this child's subtree.
                float child_ymin = subtree_ymin;
                child.Arrange(gr, ref x, ref child_ymin);

                // See if this increases the biggest ymin value.
                if (biggest_ymin < child_ymin) biggest_ymin = child_ymin;

                // Allow room before the next sibling.
                x += Hoffset;
            }

            // Remove the spacing after the last child.
            if (Children.Count > 0) x -= Hoffset;

            // See if this node is wider than the subtree under it.
            float subtree_width = x - xmin;
            if (my_size.Width > subtree_width)
            {
                // Center the subtree under this node.
                // Make the children rearrange themselves
                // moved to center their subtrees.
                x = xmin + (my_size.Width - subtree_width) / 2;
                foreach (TNode child in Children)
                {
                    // Arrange this child's subtree.
                    child.Arrange(gr, ref x, ref subtree_ymin);

                    // Allow room before the next sibling.
                    x += Hoffset;
                }

                // The subtree's width is this node's width.
                subtree_width = my_size.Width;
            }

            // Set this node's center position.
            Center = new PointF(
                xmin + subtree_width / 2,
                ymin + my_size.Height  / 2);

            // Increase xmin to allow room for
            // the subtree before returning.
            xmin += subtree_width;

            // Set the return value for ymin.
            ymin = biggest_ymin;
        }

        // Draw the subtree rooted at this node
        // with the given upper left corner.
        public void DrawTree(Graphics gr, ref float x, float y)
        {
            // Arrange the tree.
            Arrange(gr, ref x, ref y);

            // Draw the tree.
            DrawTree(gr);
        }

        // Draw the subtree rooted at this node.
        public void DrawTree(Graphics gr)
        {
            // Draw the links.
            DrawSubtreeLinks(gr);

            // Draw the nodes.
            DrawSubtreeNodes(gr);
        }

        // Draw the links for the subtree rooted at this node.
        private void DrawSubtreeLinks(Graphics gr)
        {
            foreach (TNode child in Children)
            {
                // Draw the link between this node this child.
                AdjustableArrowCap myArrow = new AdjustableArrowCap(15,15, false);
                Pen capPen = new Pen(System.Drawing.Color.Black);
                capPen.CustomEndCap = myArrow;
                //gr.DrawLine(capPen, Center, child.Center);
                gr.DrawLine(capPen, Center.X, Center.Y, child.Center.X , child.Center.Y - 15);
                // Recursively make the child draw its subtree nodes.
                child.DrawSubtreeLinks(gr);
            }

        }

        // Draw the nodes for the subtree rooted at this node.
        private void DrawSubtreeNodes(Graphics gr)
        {
            // Draw this node.
            Draw(Center.X, Center.Y, gr, MyPen, BgBrush, FontBrush, MyFont);

            // Recursively make the child draw its subtree nodes.
            foreach (TNode child in Children)
            {
                child.DrawSubtreeNodes(gr);
            }
        }

        // Return the TreeNode at this point (or null if there isn't one there).
        public TNode NodeAtPoint(Graphics gr, PointF target_pt)
        {
            // See if the point is under this node.
            if (IsAtPoint(gr, MyFont, Center, target_pt)) return this;

            // See if the point is under a node in the subtree.
            foreach (TNode child in Children)
            {
                TNode hit_node = child.NodeAtPoint(gr, target_pt);
                if (hit_node != null) return hit_node;
            }

            return null;
        }


        // Return the size of the string plus a 10 pixel margin.
        public SizeF GetSize(Graphics gr, Font font)
        {
            return gr.MeasureString(Label, font) + new SizeF(10, 10);
        }

        // Draw the object centered at (x, y).
        void Draw(float x, float y, Graphics gr, Pen pen, Brush bg_brush, Brush text_brush, Font font)
        {
            // Fill and draw an ellipse at our location.
            SizeF my_size = GetSize(gr, font);
            RectangleF rect = new RectangleF(
                x - my_size.Width / 2,
                y - my_size.Height / 2,
                my_size.Width, my_size.Height);
            gr.FillEllipse(bg_brush, rect);
            gr.DrawEllipse(pen, rect);

            // Draw the text.
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                gr.DrawString(Label, font, text_brush, x, y, string_format);
            }
        }

        // Return true if the node is above this point.
        // Note: The equation for an ellipse with half
        // width w and half height h centered at the origin is:
        //      x*x/w/w + y*y/h/h <= 1.
        bool IsAtPoint(Graphics gr, Font font, PointF center_pt, PointF target_pt)
        {
            // Get our size.
            SizeF my_size = GetSize(gr, font);

            // translate so we can assume the
            // ellipse is centered at the origin.
            target_pt.X -= center_pt.X;
            target_pt.Y -= center_pt.Y;

            // Determine whether the target point is under our ellipse.
            float w = my_size.Width / 2;
            float h = my_size.Height / 2;
            return
                target_pt.X * target_pt.X / w / w +
                target_pt.Y * target_pt.Y / h / h
                <= 1;
        }
    }
}


