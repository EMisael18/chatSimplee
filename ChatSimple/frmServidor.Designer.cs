namespace ChatSimple
{
    partial class frmServidor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            txtPuerto = new TextBox();
            btnIniciarServidor = new Button();
            rtbHistorial = new RichTextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold);
            label2.Location = new Point(147, 15);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(98, 26);
            label2.TabIndex = 3;
            label2.Text = "Puerto";
            // 
            // txtPuerto
            // 
            txtPuerto.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold);
            txtPuerto.Location = new Point(147, 43);
            txtPuerto.Margin = new Padding(2);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(98, 32);
            txtPuerto.TabIndex = 2;
            // 
            // btnIniciarServidor
            // 
            btnIniciarServidor.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarServidor.Location = new Point(396, 60);
            btnIniciarServidor.Margin = new Padding(2);
            btnIniciarServidor.Name = "btnIniciarServidor";
            btnIniciarServidor.Size = new Size(207, 41);
            btnIniciarServidor.TabIndex = 4;
            btnIniciarServidor.Text = "Iniciar Server";
            btnIniciarServidor.UseVisualStyleBackColor = true;
            btnIniciarServidor.Click += btnIniciarServidor_Click;
            // 
            // rtbHistorial
            // 
            rtbHistorial.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbHistorial.Location = new Point(11, 127);
            rtbHistorial.Margin = new Padding(2);
            rtbHistorial.Name = "rtbHistorial";
            rtbHistorial.Size = new Size(634, 276);
            rtbHistorial.TabIndex = 5;
            rtbHistorial.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold);
            label3.Location = new Point(30, 95);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(113, 26);
            label3.TabIndex = 6;
            label3.Text = "Mensajes";
            // 
            // frmServidor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            ClientSize = new Size(656, 426);
            Controls.Add(label3);
            Controls.Add(rtbHistorial);
            Controls.Add(btnIniciarServidor);
            Controls.Add(label2);
            Controls.Add(txtPuerto);
            Margin = new Padding(2);
            Name = "frmServidor";
            Text = "CREAR SERVIDOR";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtPuerto;
        private Button btnIniciarServidor;
        private RichTextBox rtbHistorial;
        private Label label3;
    }
}
