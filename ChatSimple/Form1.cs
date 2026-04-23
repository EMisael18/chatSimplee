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
        string nombreUsuario = "";

        private List<StreamWriter> clientesConectados = new List<StreamWriter>();
        private readonly object lockClientes = new object();

        private bool esServidor = false;

        Conexion db = new Conexion();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnIniciarServidor_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta aplicacion es el Servidor?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    esServidor = true;

                    int puerto = int.Parse(txtPuerto.Text);
                    TcpListener listener = new TcpListener(IPAddress.Any, puerto);
                    listener.Start();

                    rtbHistorial.AppendText("Servidor iniciado en: " + getIP() + ":" + puerto + "\r\n");

                    while (true)
                    {
                        TcpClient nuevoCliente = await listener.AcceptTcpClientAsync();
                        _ = ManejarCliente(nuevoCliente);
                    }
                }
                else
                {
                    // VALIDAR NOMBRE
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("Debes escribir un nombre.");
                        return;
                    }

                    nombreUsuario = txtNombre.Text;

                    string ip = txtIP.Text;
                    int port = int.Parse(txtPuerto.Text);

                    cliente = new TcpClient();
                    rtbHistorial.AppendText("Conectando...\r\n");

                    await cliente.ConnectAsync(ip, port);
                    rtbHistorial.AppendText("Conectado al chat\r\n");

                    NetworkStream stream = cliente.GetStream();
                    reader = new StreamReader(stream);
                    writer = new StreamWriter(stream) { AutoFlush = true };

                    // ENVIAR NOMBRE AL SERVIDOR
                    await writer.WriteLineAsync(nombreUsuario);

                    _ = RecibirMensajes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private async Task ManejarCliente(TcpClient cliente)
        {
            NetworkStream stream = cliente.GetStream();
            StreamReader clientReader = new StreamReader(stream);
            StreamWriter clientWriter = new StreamWriter(stream) { AutoFlush = true };

            // LEER NOMBRE DEL CLIENTE
            string nombreCliente = await clientReader.ReadLineAsync();

            lock (lockClientes) { clientesConectados.Add(clientWriter); }

            // MENSAJE DE ENTRADA
            rtbHistorial.Invoke((MethodInvoker)delegate {
                rtbHistorial.AppendText(nombreCliente + " se unió al chat\r\n");
            });

            DifundirMensaje(nombreCliente + " se unió al chat");

            try
            {
                while (cliente.Connected)
                {
                    string mensajeRecibido = await clientReader.ReadLineAsync();

                    if (mensajeRecibido != null)
                    {
                        string horaActual = DateTime.Now.ToString("HH:mm");
                        string MensajeFinal = "[" + horaActual + "] " + nombreCliente + ": " + mensajeRecibido;

                        rtbHistorial.Invoke((MethodInvoker)delegate {
                            rtbHistorial.AppendText(MensajeFinal + "\r\n");
                        });

                        
                        DifundirMensaje(MensajeFinal);

                        
                        db.GuardarMensaje(nombreCliente, mensajeRecibido);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error con un cliente.");
            }
            finally
            {
                lock (lockClientes) { clientesConectados.Remove(clientWriter); }

                rtbHistorial.Invoke((MethodInvoker)delegate {
                    rtbHistorial.AppendText(nombreCliente + " salió del chat\r\n");
                });

                DifundirMensaje(nombreCliente + " salió del chat");

                cliente.Close();
            }
        }

        private async void DifundirMensaje(string mensaje)
        {
            List<StreamWriter> copiaClientes;

            lock (lockClientes) { copiaClientes = new List<StreamWriter>(clientesConectados); }

            foreach (var clientWriter in copiaClientes)
            {
                try
                {
                    await clientWriter.WriteLineAsync(mensaje);
                }
                catch { }
            }
        }

        private string getIP()
        {
            string hostName = Dns.GetHostName();
            string myIP = "";
            IPHostEntry host = Dns.GetHostEntry(hostName);

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    myIP = ip.ToString();
                    break;
                }
            }
            return myIP;
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
                            rtbHistorial.AppendText(mensajeRecibido + "\n");
                        });
                    }
                }
            }
            catch
            {
                rtbHistorial.Invoke((MethodInvoker)delegate
                {
                    rtbHistorial.AppendText("Desconectado\n");
                });
            }
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            string mensaje = txtMensaje.Text;
            if (string.IsNullOrWhiteSpace(mensaje)) return;

            try
            {
                if (esServidor)
                {
                    string hora = DateTime.Now.ToString("HH:mm");
                    string formatoServer = "[" + hora + "] Server: " + mensaje;

                    rtbHistorial.AppendText(formatoServer + "\r\n");
                    DifundirMensaje(formatoServer);
                    db.GuardarMensaje("Server", mensaje);
                }
                else if (cliente != null && cliente.Connected)
                {
                    await writer.WriteLineAsync(mensaje);
                }

                txtMensaje.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}