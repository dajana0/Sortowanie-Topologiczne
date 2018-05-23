namespace Sortowanie
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picTree = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajWęzełToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńWęzełToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTree
            // 
            this.picTree.Location = new System.Drawing.Point(51, 70);
            this.picTree.Name = "picTree";
            this.picTree.Size = new System.Drawing.Size(522, 309);
            this.picTree.TabIndex = 3;
            this.picTree.TabStop = false;
            this.picTree.Paint += new System.Windows.Forms.PaintEventHandler(this.picTree_Paint);
            this.picTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTree_MouseDown);
            this.picTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTree_MouseMove);
            this.picTree.Resize += new System.EventHandler(this.picTree_Resize);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajWęzełToolStripMenuItem,
            this.usuńWęzełToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 48);
            // 
            // dodajWęzełToolStripMenuItem
            // 
            this.dodajWęzełToolStripMenuItem.Name = "dodajWęzełToolStripMenuItem";
            this.dodajWęzełToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.dodajWęzełToolStripMenuItem.Text = "Dodaj węzeł";
            this.dodajWęzełToolStripMenuItem.Click += new System.EventHandler(this.dodajWęzełToolStripMenuItem_Click);
            // 
            // usuńWęzełToolStripMenuItem
            // 
            this.usuńWęzełToolStripMenuItem.Name = "usuńWęzełToolStripMenuItem";
            this.usuńWęzełToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.usuńWęzełToolStripMenuItem.Text = "Usuń węzeł";
            this.usuńWęzełToolStripMenuItem.Click += new System.EventHandler(this.usuńWęzełToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 450);
            this.Controls.Add(this.picTree);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picTree;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodajWęzełToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńWęzełToolStripMenuItem;
    }
}

