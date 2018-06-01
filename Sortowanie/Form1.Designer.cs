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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajWęzełToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńWęzełToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btPlik = new System.Windows.Forms.Button();
            this.lbTakNie = new System.Windows.Forms.Label();
            this.lbSort = new System.Windows.Forms.Label();
            this.picTree = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).BeginInit();
            this.SuspendLayout();
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
            // btPlik
            // 
            this.btPlik.Location = new System.Drawing.Point(130, 33);
            this.btPlik.Name = "btPlik";
            this.btPlik.Size = new System.Drawing.Size(75, 23);
            this.btPlik.TabIndex = 4;
            this.btPlik.Text = "Plik";
            this.btPlik.UseVisualStyleBackColor = true;
            this.btPlik.Click += new System.EventHandler(this.btPlik_Click);
            // 
            // lbTakNie
            // 
            this.lbTakNie.AutoSize = true;
            this.lbTakNie.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTakNie.Location = new System.Drawing.Point(167, 82);
            this.lbTakNie.Name = "lbTakNie";
            this.lbTakNie.Size = new System.Drawing.Size(0, 25);
            this.lbTakNie.TabIndex = 5;
            // 
            // lbSort
            // 
            this.lbSort.AutoSize = true;
            this.lbSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSort.Location = new System.Drawing.Point(27, 136);
            this.lbSort.Name = "lbSort";
            this.lbSort.Size = new System.Drawing.Size(0, 18);
            this.lbSort.TabIndex = 6;
            // 
            // picTree
            // 
            this.picTree.Location = new System.Drawing.Point(12, 12);
            this.picTree.Name = "picTree";
            this.picTree.Size = new System.Drawing.Size(15, 12);
            this.picTree.TabIndex = 7;
            this.picTree.TabStop = false;
            this.picTree.Resize += new System.EventHandler(this.picTree_Resize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 388);
            this.Controls.Add(this.picTree);
            this.Controls.Add(this.lbSort);
            this.Controls.Add(this.lbTakNie);
            this.Controls.Add(this.btPlik);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodajWęzełToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńWęzełToolStripMenuItem;
        private System.Windows.Forms.Button btPlik;
        private System.Windows.Forms.Label lbTakNie;
        private System.Windows.Forms.Label lbSort;
        private System.Windows.Forms.PictureBox picTree;
    }
}

