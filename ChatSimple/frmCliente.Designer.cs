namespace ChatSimple
{
    partial class frmCliente
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
            rtbHistorial = new RichTextBox();
            Mensaje = new Label();
            txtMensaje = new TextBox();
            txtNombre = new TextBox();
            label1 = new Label();
            btnConectar = new Button();
            label2 = new Label();
            btnEnviar = new Button();
            SuspendLayout();
            // 
            // rtbHistorial
            // 
            rtbHistorial.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbHistorial.Location = new Point(45, 138);
            rtbHistorial.Name = "rtbHistorial";
            rtbHistorial.Size = new Size(742, 267);
            rtbHistorial.TabIndex = 0;
            rtbHistorial.Text = "";
            // 
            // Mensaje
            // 
            Mensaje.AutoSize = true;
            Mensaje.Font = new Font("Showcard Gothic", 12F);
            Mensaje.Location = new Point(58, 408);
            Mensaje.Name = "Mensaje";
            Mensaje.Size = new Size(95, 26);
            Mensaje.TabIndex = 1;
            Mensaje.Text = "Mensaje";
            // 
            // txtMensaje
            // 
            txtMensaje.Font = new Font("Showcard Gothic", 12F);
            txtMensaje.Location = new Point(58, 443);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(551, 32);
            txtMensaje.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Showcard Gothic", 12F);
            txtNombre.Location = new Point(58, 40);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(368, 32);
            txtNombre.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 12F);
            label1.Location = new Point(72, 16);
            label1.Name = "label1";
            label1.Size = new Size(95, 26);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // btnConectar
            // 
            btnConectar.Font = new Font("Showcard Gothic", 12F);
            btnConectar.Location = new Point(573, 31);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(177, 51);
            btnConectar.TabIndex = 5;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 12F);
            label2.Location = new Point(45, 99);
            label2.Name = "label2";
            label2.Size = new Size(117, 26);
            label2.TabIndex = 6;
            label2.Text = "Historial";
            // 
            // btnEnviar
            // 
            btnEnviar.Font = new Font("Showcard Gothic", 12F);
            btnEnviar.Location = new Point(632, 438);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(119, 51);
            btnEnviar.TabIndex = 7;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click_1;
            // 
            // frmCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(822, 496);
            Controls.Add(btnEnviar);
            Controls.Add(label2);
            Controls.Add(btnConectar);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(txtMensaje);
            Controls.Add(Mensaje);
            Controls.Add(rtbHistorial);
            Name = "frmCliente";
            Text = "frmCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbHistorial;
        private Label Mensaje;
        private TextBox txtMensaje;
        private TextBox txtNombre;
        private Label label1;
        private Button btnConectar;
        private Label label2;
        private Button btnEnviar;
    }
}