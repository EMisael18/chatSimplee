using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.ComponentModel;
namespace ChatSimple
{
    public partial class Form1 : Form
    {
        private TcpClient cliente;
        private StreamReader reader;
        private StreamWriter writer;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnIniciarServidor_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta aplicacion " +
                "es el Servidor?", "Sistema", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    int port = int.Parse(txtPuerto.Text);
                    TcpListener server = new TcpListener(IPAddress.Any, port);
                    server.Start();
                    string ip = getIP();
                    rtbHistorial.AppendText("Servidor iniciado en la IP y puerto: " 
                        + ip +":" + port + "\n");

                    //Esperars que un cliente se conecte de manera asincrona
                    cliente = await server.AcceptTcpClientAsync();
                    rtbHistorial.AppendText("Cliente conectado!\n");

                    ConfigurarStreams();
                    _ = RecibirMensajes();
                }
                else
                {
                    string ip = txtIP.Text;
                    int port = int.Parse(txtPuerto.Text);

                    cliente = new TcpClient();
                    rtbHistorial.AppendText("Conectando al servidor...\n");

                    await cliente.ConnectAsync(ip, port);
                    rtbHistorial.AppendText("Conectado\n");

                    ConfigurarStreams();
                    _ = RecibirMensajes();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

        }

        private string getIP()
        {
            string hostName = Dns.GetHostName();
            string myIP = "";
            IPHostEntry host = Dns.GetHostEntry(hostName);

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) // Filtra IPv4
                {
                    myIP = ip.ToString();
                    break;
                }
            }
            return myIP;
        }
        private void ConfigurarStreams()
        {
            NetworkStream stream = cliente.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
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
                            rtbHistorial.AppendText("Extraño: "
                                + mensajeRecibido + "\n");
                        });
                    }

                }
            }
            catch (Exception)
            {
                rtbHistorial.Invoke((MethodInvoker)delegate
                {
                    rtbHistorial.AppendText("Cliente Desconectado \n");
                });
            }
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            if (cliente != 
                null && cliente.Connected && 
                !string.IsNullOrWhiteSpace(txtMensaje.Text))
            {
                try { 
                    string mensaje= txtMensaje.Text;
                    await writer.WriteLineAsync(mensaje);

                    rtbHistorial.AppendText("Yo: " + mensaje + "\n");
                    txtMensaje.Clear();
                }
                catch (Exception ex) {
                    MessageBox.Show("Error:" +
                    ex.ToString()); }
            }
            else
                MessageBox.Show("No hay clientes conectados","Sistema",
                    MessageBoxButtons .OK, MessageBoxIcon.Warning);
        }
    }
}
