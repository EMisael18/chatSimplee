namespace ChatSimple
{
    partial class Form1
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
            txtIP = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPuerto = new TextBox();
            btnIniciarServidor = new Button();
            rtbHistorial = new RichTextBox();
            label3 = new Label();
            txtMensaje = new TextBox();
            label4 = new Label();
            btnEnviar = new Button();
            txtNombre = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtIP
            // 
            txtIP.Location = new Point(263, 38);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(211, 31);
            txtIP.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(263, 10);
            label1.Name = "label1";
            label1.Size = new Size(27, 25);
            label1.TabIndex = 1;
            label1.Text = "IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(494, 10);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 3;
            label2.Text = "Puerto";
            // 
            // txtPuerto
            // 
            txtPuerto.Location = new Point(494, 38);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(96, 31);
            txtPuerto.TabIndex = 2;
            // 
            // btnIniciarServidor
            // 
            btnIniciarServidor.Location = new Point(611, 35);
            btnIniciarServidor.Name = "btnIniciarServidor";
            btnIniciarServidor.Size = new Size(170, 34);
            btnIniciarServidor.TabIndex = 4;
            btnIniciarServidor.Text = "Iniciar Server";
            btnIniciarServidor.UseVisualStyleBackColor = true;
            btnIniciarServidor.Click += btnIniciarServidor_Click;
            // 
            // rtbHistorial
            // 
            rtbHistorial.Location = new Point(22, 119);
            rtbHistorial.Name = "rtbHistorial";
            rtbHistorial.Size = new Size(694, 235);
            rtbHistorial.TabIndex = 5;
            rtbHistorial.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 91);
            label3.Name = "label3";
            label3.Size = new Size(85, 25);
            label3.TabIndex = 6;
            label3.Text = "Mensajes";
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(22, 397);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(401, 31);
            txtMensaje.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 369);
            label4.Name = "label4";
            label4.Size = new Size(77, 25);
            label4.TabIndex = 8;
            label4.Text = "Mensaje";
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(446, 394);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(112, 34);
            btnEnviar.TabIndex = 9;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(54, 38);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(160, 31);
            txtNombre.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(73, 10);
            label5.Name = "label5";
            label5.Size = new Size(78, 25);
            label5.TabIndex = 11;
            label5.Text = "Nombre";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 448);
            Controls.Add(label5);
            Controls.Add(txtNombre);
            Controls.Add(btnEnviar);
            Controls.Add(label4);
            Controls.Add(txtMensaje);
            Controls.Add(label3);
            Controls.Add(rtbHistorial);
            Controls.Add(btnIniciarServidor);
            Controls.Add(label2);
            Controls.Add(txtPuerto);
            Controls.Add(label1);
            Controls.Add(txtIP);
            Name = "Form1";
            Text = "Chat Simple";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIP;
        private Label label1;
        private Label label2;
        private TextBox txtPuerto;
        private Button btnIniciarServidor;
        private RichTextBox rtbHistorial;
        private Label label3;
        private TextBox txtMensaje;
        private Label label4;
        private Button btnEnviar;
        private TextBox txtNombre;
        private Label label5;
    }
}
