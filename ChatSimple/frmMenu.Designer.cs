namespace ChatSimple
{
    partial class frmMenu
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
            menuStrip1 = new MenuStrip();
            cREARSERVIDORToolStripMenuItem = new ToolStripMenuItem();
            uNIRSEASERVIDORToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cREARSERVIDORToolStripMenuItem, uNIRSEASERVIDORToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cREARSERVIDORToolStripMenuItem
            // 
            cREARSERVIDORToolStripMenuItem.Name = "cREARSERVIDORToolStripMenuItem";
            cREARSERVIDORToolStripMenuItem.Size = new Size(141, 24);
            cREARSERVIDORToolStripMenuItem.Text = "CREAR SERVIDOR";
            cREARSERVIDORToolStripMenuItem.Click += cREARSERVIDORToolStripMenuItem_Click;
            // 
            // uNIRSEASERVIDORToolStripMenuItem
            // 
            uNIRSEASERVIDORToolStripMenuItem.Name = "uNIRSEASERVIDORToolStripMenuItem";
            uNIRSEASERVIDORToolStripMenuItem.Size = new Size(160, 24);
            uNIRSEASERVIDORToolStripMenuItem.Text = "UNIRSE A SERVIDOR";
            uNIRSEASERVIDORToolStripMenuItem.Click += uNIRSEASERVIDORToolStripMenuItem_Click;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMenu";
            Text = "frmMenu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cREARSERVIDORToolStripMenuItem;
        private ToolStripMenuItem uNIRSEASERVIDORToolStripMenuItem;
    }
}