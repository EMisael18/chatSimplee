using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatSimple
{
    public partial class frmCliente : Form
    {
        private TcpClient cliente;
        private StreamReader reader;
        private StreamWriter writer;
        string nombreUsuario = "";

        public frmCliente()
        {
            InitializeComponent();
        }

        private async void btnConectar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Escribe tu nombre antes de conectar.");
                return;
            }

            if (Conexion.Puerto == 0)
            {
                MessageBox.Show("Primero inicia el servidor.");
                return;
            }

            try
            {
                nombreUsuario = txtNombre.Text;

                cliente = new TcpClient();
                rtbHistorial.AppendText("Conectando......");

                await cliente.ConnectAsync("localhost", Conexion.Puerto);

                NetworkStream stream = cliente.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                await writer.WriteLineAsync(nombreUsuario);

                rtbHistorial.AppendText("Conectado\r\n");

                _ = RecibirMensajes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private async Task RecibirMensajes()
        {
            try
            {
                while (cliente != null && cliente.Connected)
                {
                    string mensajeRecibido = await reader.ReadLineAsync();

                    if (mensajeRecibido != null)
                    {
                        rtbHistorial.Invoke((MethodInvoker)delegate
                        {
                            rtbHistorial.AppendText(mensajeRecibido + "\r\n");
                        });
                    }
                }
            }
            catch
            {
                rtbHistorial.Invoke((MethodInvoker)delegate
                {
                    rtbHistorial.AppendText("Desconectado del servidor.\r\n");
                });
            }
        }



        private async void btnEnviar_Click_1(object sender, EventArgs e)
        {
            string mensaje = txtMensaje.Text;

            if (string.IsNullOrWhiteSpace(mensaje)) return;

            try
            {
                if (cliente != null && cliente.Connected)
                {
                    await writer.WriteLineAsync(mensaje);
                    txtMensaje.Clear();
                }
                else
                {
                    MessageBox.Show("No estás conectado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

       
    }
}